using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using gigaFlash;
using gigaFlash.Delegates;
using gigaFlash.ConfigObjects;
using gigaFlash.Modules;

namespace GigaFlashWinform.RoomUI
{
    public partial class Room : UserControl, IRoom
    {
        #region Constructor
        public Room()
        {
            InitializeComponent();
            this.MouseWheel += new MouseEventHandler(OnMouseWheel);
            this.Click += new EventHandler(OnRoomClickEvent);
            this.button1.DoubleClick += new EventHandler(RoomDoubleClickEvent);
		}

		#endregion

		/// <summary>
        /// Meant to be run after events are hooked up from the presenter.
        /// </summary>
        public void PostInitializiation()
        {
            UpdateRoom(ColorUtils.GetRandomColor(),
                RoomIntensity); 
        }

        #region Public Methods
        public void UpdateRoom(Color c)
        {
            UpdateRoom(c, 100); 
        }

        public void UpdateRoom(Color c, int intensity)
        {
            foreach (LightView lv in mLightViews)
            {
                lv.Color = c;
                lv.Intensity = intensity; 
            }

            Color adjustedColor = Color.FromArgb(
                    c.R * intensity / 100,
                    c.G * intensity / 100,
                    c.B * intensity / 100); 

            // -1 updates all lights. 
            EventUtils.FireDualTypedEvent(LightUpdate, -1, adjustedColor); 
        }
        #endregion 

        #region Handlers / Helpers
        public void InitializeRoom()
        {
            AddLight(lightView1);
            AddLight(lightView2);
            AddLight(lightView3);
            AddLight(lightView4);
            AddLight(lightView5);
            AddLight(lightView6);
            AddLight(lightView10);
            //AddLight(lightView7);
            //AddLight(lightView8);
            //AddLight(lightView9);
        }

        protected void AddLight(LightView pView)
        {
            pView.DirectClickEvent += new TypedDelegate<LightView>(OnDirectLightClick);
            pView.SaveFired += 
                new TypedDelegate<gigaFlash.ConfigObjects.ColorConfig>(HandleColorSaveFired);
            pView.ColorSet += new TypedDelegate<ILightView>(OnColorSet);
            pView.CopyEventFired += new TypedDelegate<Color>(HandleCopyEvent);
            pView.PasteEventFired += new TypedDelegate<LightView>(HandlePasteEvent);
            pView.DoubleClickEvent += new TypedDelegate<LightView>(HandleDoubleClickOnLight);
            pView.CtrlClickEvent += new TypedDelegate<LightView>(OnCtrlClickEvent);
            pView.SineEventFired += new TypedDelegate<LightView>(OnSineEvent);
            pView.StopEventFired += new TypedDelegate<LightView>(HandleStopEventClicked);
            mLightViews.Add(pView);

			EventUtils.FireTypedEvent(LightViewAdded, pView); 
        }

        void HandleStopEventClicked(LightView value)
        {
            List<int> indices = new List<int>();
            foreach (LightView lv in SelectedLights)
            {
                indices.Add(mLightViews.IndexOf(lv));
            }
            EventUtils.FireTypedEvent(StopEventFired, indices);
        }

        void OnSineEvent(LightView value)
        {
            List<int> indices = new List<int>(); 
            foreach(LightView lv in SelectedLights) 
            {
                indices.Add(mLightViews.IndexOf(lv));
            }
            EventUtils.FireTypedEvent(SineEventFired, indices); 
        }


        void HandleCopyEvent(Color value)
        {
            mCopiedColor = value; 
        }

        void HandlePasteEvent(LightView pLight)
        {
            foreach (LightView light in SelectedLights)
            {
                light.Color = mCopiedColor;
            }
        }

        void OnColorSet(ILightView value)
        {

            LightView lv = value as LightView;
            EventUtils.FireDualTypedEvent(
                LightUpdate,
                mLightViews.IndexOf(lv),
                lv.Color); 

        }

        public void LoadPreferences(UserPrefObj pPrefObj)
        {
            foreach (LightView lightView in mLightViews)
            {
                lightView.CustomColors = pPrefObj.Colors; 
            }
        }

        protected virtual void HandleColorSaveFired(ColorConfig value)
        {
            EventUtils.FireTypedEvent(ColorSaveFired, value); 
        }

        /// <summary>
        /// Clear the previous light selections.
        /// The light that has been clicked on is now selected.
        /// </summary>
        /// <param name="pSelectedLight"></param>
        protected virtual void OnDirectLightClick(LightView pSelectedLight)
        {
            SelectLight(pSelectedLight);
            mColorModeSelected = true;
            mHoverIndex = mLightViews.IndexOf(pSelectedLight); 
        }

        /// <summary>
        /// Clear previous light selections.
        /// The light that has been clicked on is now selected.
        /// Change the light to a random color. 
        /// </summary>
        /// <param name="value"></param>
        protected virtual void HandleDoubleClickOnLight(LightView pSelectedLight)
        {
            SelectLight(pSelectedLight);
            mColorModeSelected = true;
            InitializeSelectedLight(pSelectedLight); 
        }

        /// <summary>
        /// Adds the current value to the selected list without modifying the 
        /// existing selection
        /// </summary>
        /// <param name="value"></param>
        void OnCtrlClickEvent(LightView value)
        {
            mColorModeSelected = true; 
            value.Selected = true; 
        }

        /// <summary>
        /// Clears previous light selections.
        /// pLight will be set to selected. 
        /// </summary>
        /// <param name="pLight"></param>
        protected void SelectLight(LightView pSelectedLight)
        {
            foreach (LightView lv in mLightViews)
            {
                if (lv != pSelectedLight)
                {
                    lv.Selected = false;
                }
            }
            pSelectedLight.Selected = true; 
        }

        protected void OnMouseWheel(object sender, MouseEventArgs e)
        {
            if (mColorModeSelected)
            {
                // Send value to the focused light
                LightView currentLight = mLightViews[mHoverIndex];
                if (e.Delta < 0)
                {
                    foreach (LightView light in SelectedLights)
                    {
                        light.IncreaseBrightness();
                        EventUtils.FireDualTypedEvent(LightUpdate, 
                            mLightViews.IndexOf(light), 
                            light.Color);

                    }
                }
                else if (e.Delta > 0)
                {
                    foreach (LightView light in SelectedLights)
                    {
                        light.DecreaseBrightness();
                        EventUtils.FireDualTypedEvent(LightUpdate,
                            mLightViews.IndexOf(light),
                            light.Color);
                    }
                }
            }
            else
            {
                // Move focus around the room.
                mLightViews[mHoverIndex].Selected = false;
                if (e.Delta < 0)
                    mHoverIndex++;
                else
                    if (mHoverIndex == 0)
                        mHoverIndex += mLightViews.Count - 1;
                    else
                        mHoverIndex--;

                mHoverIndex = mHoverIndex % (mLightViews.Count);
                mLightViews[mHoverIndex].Selected = true;
            }
        }

        protected void OnRoomClickEvent(object sender, EventArgs e)
        {
            // Toggles the mode selection. 
            mColorModeSelected = !mColorModeSelected;

            // Chooses random color if in color mode. 
            if (mColorModeSelected)
            {
                InitializeSelectedLight(mLightViews[mHoverIndex]); 
            }
        }

        void RoomDoubleClickEvent(object sender, EventArgs e)
        {
            Color color = ColorUtils.GetRandomColor(); 
            EventUtils.FireDualTypedEvent(LightUpdate,
                -1,
                color);
            foreach (LightView lv in mLightViews)
            {
                lv.Intensity = RoomIntensity;  
                lv.Color = color;
            }

        }

        protected void InitializeSelectedLight(LightView pSelectedLight)
        {
            mHoverIndex = mLightViews.IndexOf(pSelectedLight); 
            Color curColor = ColorUtils.GetRandomColor();
            pSelectedLight.Color = curColor;
            EventUtils.FireDualTypedEvent(LightUpdate,
                mHoverIndex, 
                curColor);  
        }

        private void HandleSetRoomColorClicked(object sender, EventArgs e)
        {
            ColorDialog d = new ColorDialog();
            if (DialogResult.OK == d.ShowDialog())
            {
                Color color = d.Color;
                EventUtils.FireDualTypedEvent(LightUpdate,
                    -1,
                    color);
                foreach (LightView lv in mLightViews)
                {
                    lv.Intensity = 100;
                    lv.Color = color;
                }
            }
        }

        private void HandleBrightnessValueChanged(object sender, EventArgs e)
        {
            foreach (LightView lv in mLightViews)
            {
                lv.Intensity = RoomIntensity;
                EventUtils.FireDualTypedEvent(LightUpdate, 
                    mLightViews.IndexOf(lv), 
                    lv.Color); 
            }
        }

        #endregion

        #region Members / Properties
		public event TypedDelegate<gigaFlash.Modules.ILightView> LightViewAdded;

        public event TypedDelegate<List<int>> SineEventFired;

        public event TypedDelegate<List<int>> StopEventFired; 

        protected Color mCopiedColor = Color.Black; 

        protected List<LightView> mLightViews = new List<LightView>();

        protected int mHoverIndex = 0;

        public event DualTypedDelegate<int, Color> LightUpdate;

        protected bool mColorModeSelected = false;

        public new event VoidDelegate Disposing;

        public event TypedDelegate<ColorConfig> ColorSaveFired; 

        public int RoomIntensity
        {
            get { return mIntensityBar.Value * 10; }

            
            set
            {
                mIntensityBar.Value = value / 10; 
            }
        }

        public List<LightView> SelectedLights
        {
            get
            {
                List<LightView> selectedLights = new List<LightView>();
                foreach (LightView light in mLightViews)
                {
                    if (light.Selected == true)
                        selectedLights.Add(light); 
                }
                return selectedLights; 
            }
            set
            {
                if (value != null)
                {
                    foreach (LightView light in mLightViews)
                    {
                        if (value.Contains(light))
                            light.Selected = true;
                        else
                            light.Selected = false;
                    }
                }
            }
        }
        #endregion

        #region Dispose
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            //EventUtils.FireDualTypedEvent(LightUpdate, -1, Color.Black); 
            EventUtils.FireEvent(Disposing); 
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion



	}
}
