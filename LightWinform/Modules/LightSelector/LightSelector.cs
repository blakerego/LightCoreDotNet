using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using gigaFlash.Modules;
using gigaFlash.Delegates;
using gigaFlash;

namespace GigaFlashWinform
{
    public partial class LightSelector : BaseForm, ILightSelectorView
    {
        #region Constructor
        public LightSelector()
        {
            InitializeComponent();
            mState = new LightState(10);

            int counter = 1; 
            foreach (Light l in mState.Lights)
            {
                mListbox.Items.Add("Light" + counter.ToString());
                counter++;
            }
            mObjectCollection = mListbox.Items; 

        }
        #endregion

        #region Handlers 
        private void HandleUpdateClicked(object sender, EventArgs e)
        {
            DialogResult r = colorDialog1.ShowDialog(this);
            if (r == DialogResult.OK)
            {
                EventUtils.FireTypedEvent(UpdateColorFired, colorDialog1.Color); 
            }
        }

        private void HandleClearClicked(object sender, EventArgs e)
        {
            EventUtils.FireEvent(ClearClicked); 
        }

        private void LightSelector_FormClosed(object sender, FormClosedEventArgs e)
        {
            EventUtils.FireEvent(ClearClicked);
        }
        #endregion

        #region Members / Properties
        protected LightState mState;

        protected ListBox.ObjectCollection mObjectCollection;

        public event TypedDelegate<Color> UpdateColorFired;

        public event VoidDelegate ClearClicked; 

        public Color Color
        {
            get
            {
                return colorDialog1.Color; 
            }
            set
            {
                mRedTextbox.Text = "0";
                mGreenTextbox.Text = "0";
                mBlueTextbox.Text = "0";
            }
        }

        public List<Object> SelectedItems
        {
            get
            {
                List<Object> selecteditems = new List<object>(); 
                foreach (Object obj in mListbox.SelectedItems)
                {
                    selecteditems.Add(obj); 
                }
                return selecteditems; 
            }
            set
            {
                mListbox.SelectedItems.Clear(); 
                foreach (Object obj in value)
                {
                    mListbox.SelectedItems.Add(obj); 
                }
            }
        }

        public List<Object> Items
        {
            get
            {
                List<Object> items = new List<object>();
                foreach (Object obj in mListbox.Items)
                {
                    items.Add(obj);
                }
                return items; 
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
            mState.Clear();

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion


        #region IModuleView Members

        public new event VoidDelegate Disposing;

        #endregion
    }
}
