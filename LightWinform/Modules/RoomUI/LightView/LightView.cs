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
using GigaFlashWinform.Modules.RoomUI;
using gigaFlash.Modules;

namespace GigaFlashWinform.RoomUI
{
    public partial class LightView : UserControl, ILightView
    {
        #region Constructor 
        public LightView()
        {
            InitializeComponent();

            InitializeContextMenu();
            this.DoubleClick +=new EventHandler(HandleDoubleClickEvent);
            this.button1.DoubleClick += new EventHandler(HandleDoubleClickEvent);
        }
        #endregion 

        #region Methods / Handlers 
        public void IncreaseBrightness()
        {
            if (mLightIntensity <= 100 - mSensitivity)
            {
                for (int i = 0; i < mSensitivity; i++)
                {
                    mLightIntensity++;
                }
                this.BackColor = Color;
            }
        }

        public void DecreaseBrightness()
        {
            if (mLightIntensity >= mSensitivity)
            {
                for (int i = 0; i < mSensitivity; i++)
                {
                    mLightIntensity--;
                }
                this.BackColor = Color; 
            }
        }

        protected virtual void SaveColorClicked(object sender, EventArgs e)
        {
            ColorConfig colorconfig = new ColorConfig(); 
            colorconfig.Red = mColor.R;
            colorconfig.Green = mColor.G;
            colorconfig.Blue = mColor.B; 
            ColorSaveDialog cd = new ColorSaveDialog(); 
            if (cd.ShowDialog(this.ParentForm) == DialogResult.OK)
            {
                colorconfig.Name = cd.ColorName; 
                colorconfig.TotalUseCount = 1; 
                colorconfig.LastUseDate = DateTime.Now.ToString();
                EventUtils.FireTypedEvent(SaveFired, colorconfig);

                mCustomColors.Add(colorconfig);
                ReloadCustomColors();
            }
        }

        protected void InitializeContextMenu()
        {
            ContextMenu menu = new ContextMenu();

            #region Save Color
            MenuItem saveColorMenuItem = new MenuItem("Save Color");
            saveColorMenuItem.Click += new EventHandler(SaveColorClicked);
            menu.MenuItems.Add(saveColorMenuItem);
            #endregion 

            #region Load
            menu.MenuItems.Add(mLoadColorMenuItem);
            #endregion 

            #region Copy 
            MenuItem copyMenuItem = new MenuItem("Copy");
            copyMenuItem.Click += new EventHandler(HandleCopyFromContextMenu);
            menu.MenuItems.Add(copyMenuItem);
            #endregion 

            #region Paste
            MenuItem pasteMenuItem = new MenuItem("Paste");
            pasteMenuItem.Click += new EventHandler(HandlePasteFromContextMenu);
            menu.MenuItems.Add(pasteMenuItem);
            #endregion

            #region Run
            MenuItem runMenuItem = new MenuItem("Run");
            MenuItem sineItem = new MenuItem("Sine Fade");
            sineItem.Click += new EventHandler(HandleSineClicked);
            runMenuItem.MenuItems.Add(sineItem);

            MenuItem stopItem = new MenuItem("Stop");
            stopItem.Click += new EventHandler(HandleStopClicked);
            runMenuItem.MenuItems.Add(stopItem); 
            menu.MenuItems.Add(runMenuItem); 
            #endregion 

            button1.ContextMenu = menu;
        }

        void HandleStopClicked(object sender, EventArgs e)
        {
            EventUtils.FireTypedEvent(StopEventFired, this);
        }

        void HandleSineClicked(object sender, EventArgs e)
        {
            EventUtils.FireTypedEvent(SineEventFired, this); 
        }

        private void HandlePasteFromContextMenu(object sender, EventArgs e)
        {
            EventUtils.FireTypedEvent(PasteEventFired, this);
        }

        private void HandleCopyFromContextMenu(object sender, EventArgs e)
        {
            EventUtils.FireTypedEvent(CopyEventFired, this.Color);
        }

        protected void HandleDirectButtonClick(object sender, EventArgs e)
        {
            MouseEventArgs mousearg = e as MouseEventArgs;
            if (mousearg != null)
            {
                if (mousearg.Button == MouseButtons.Left)
                {
                    if (Control.ModifierKeys == Keys.Control)
                    {
                        EventUtils.FireTypedEvent(CtrlClickEvent, this);
                    }
                    else
                        EventUtils.FireTypedEvent(DirectClickEvent, this);
                }
                else if (mousearg.Button == MouseButtons.Right)
                {
                    // Need to re-create context menu. This ensures the custom color menu
                    // is up to date. 
                    InitializeContextMenu(); 
                }
            }
        }

        void HandleDoubleClickEvent(object sender, EventArgs e)
        {
            EventUtils.FireTypedEvent(DoubleClickEvent, this);             
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
                EventUtils.FireTypedEvent(CopyEventFired, this.Color);
            }
            else if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
            {
                EventUtils.FireTypedEvent(PasteEventFired, this);
            }
            base.OnKeyDown(e);
        }
        #endregion 

        #region Members / Properties
        protected bool mSelected; 
        public bool Selected
        {
            get
            {
                return mSelected;
            }
            set
            {
                mSelected = value;

                // button.Font.Bold is read-only. 
                // needed to re-instatiate the Font class to update 
                // whether or not the font button was selected.
                FontStyle fontstyle;
                if (value == true)
                    fontstyle = FontStyle.Underline;
                else
                    fontstyle = FontStyle.Regular; 
                button1.Font = 
                    new System.Drawing.Font(
                        button1.Font.FontFamily,
                        button1.Font.Size,
                        fontstyle,
                        System.Drawing.GraphicsUnit.Point, 
                        button1.Font.GdiCharSet)
                        ;
            }
        }

        protected Color mColor;
        public virtual Color Color
        {
            get
            {
                return Color.FromArgb(
                    mColor.R * mLightIntensity / 100,
                    mColor.G * mLightIntensity / 100, 
                    mColor.B * mLightIntensity / 100); 
            }
            set
            {
                mColor = value; 
                this.BackColor = Color;
                EventUtils.FireTypedEvent(ColorSet, this); 
            }
        }

        protected int mLightIntensity = 100;
        public int Intensity
        {
            get { return mLightIntensity; }
            set 
            { 
                mLightIntensity = value;
                this.BackColor = Color;
            }
        }

        public string LabelName
        {
            get { return button1.Text;  }
            set { button1.Text = value; }
        }

        protected int mSensitivity = 3;

        public event TypedDelegate<ILightView> ColorSet; 

        MenuItem mLoadColorMenuItem = new MenuItem("Load Color");

        protected Dictionary<string, Color> mCustomColorDictionary = new Dictionary<string,Color>();

        protected List<ColorConfig> mCustomColors = new List<ColorConfig>();
        public List<ColorConfig> CustomColors
        {
            get { return mCustomColors; }
            set 
            { 
                mCustomColors = value;
                ReloadCustomColors(); 
            } 
        }

        protected virtual void ReloadCustomColors()
        {
            foreach (ColorConfig colorConfig in mCustomColors)
            {
                Color c = Color.FromArgb(colorConfig.Red,
                    colorConfig.Green, colorConfig.Blue);
                if (!mCustomColorDictionary.ContainsKey(colorConfig.Name))
                {
                    mCustomColorDictionary[colorConfig.Name] = c;
                    MenuItem colorItem = new MenuItem(colorConfig.Name);
                    colorItem.Click += new EventHandler(colorItem_Click);
                    if (!mLoadColorMenuItem.MenuItems.Contains(colorItem))
                        mLoadColorMenuItem.MenuItems.Add(colorItem);
                }
            }
        }

        void colorItem_Click(object sender, EventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            Color = mCustomColorDictionary[mi.Text]; 
        }

        private void LightMenuClicked()
        {
        }

        /// <summary>
        /// Occurs when a user clicks on a light directly. 
        /// </summary>
        public event TypedDelegate<LightView> CtrlClickEvent;

        public event TypedDelegate<LightView> DirectClickEvent;

        public event TypedDelegate<LightView> DoubleClickEvent;

        public event TypedDelegate<ColorConfig> SaveFired;

        public event TypedDelegate<Color> CopyEventFired;

        public event TypedDelegate<LightView> PasteEventFired;

        public event TypedDelegate<LightView> SineEventFired;

        public event TypedDelegate<LightView> StopEventFired; 
        #endregion



    }
}
