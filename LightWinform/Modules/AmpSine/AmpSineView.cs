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

namespace GigaFlashWinform.Modules
{
    public partial class AmpSineView : BaseForm, IAmpSineView
    {
        #region Constructor
        public AmpSineView()
        {
            if (this.Parent != null)
                this.StartPosition = FormStartPosition.CenterParent; 
            else 
                this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            Color1 = Color.Black;
            Color2 = ColorUtils.GetRandomColor();
            //EventUtils.FireTypedEvent(StartFired, Color2); 
        }
        #endregion

        #region Members / Properties
        protected Color mColor1 = Color.Black;
        public Color Color1
        {
            get { return mColor1; }
            set
            {
                mColor1 = value;
                button1.BackColor = value;
                EventUtils.FireTypedEvent(Color1Changed, Color1); 
            }
        }

        protected Color mColor2 = ColorUtils.GetRandomColor();
        public Color Color2
        {
            get { return mColor2; }
            set
            {
                mColor2 = value;
                button3.BackColor = value;
                EventUtils.FireTypedEvent(Color2Changed, Color2); 
            }
        }

        public event TypedDelegate<Color> StartFired;

        public event VoidDelegate StopFired;

        public event VoidDelegate TwinkleFired;

        public event TypedDelegate<int> SpeedChanged; 

        public bool RunButtonEnabled
        {
            get
            {
                return false;// mUniformButton.Enabled;
            }
            set
            {
                //mUniformButton.Enabled = value;
            }
        }

        public bool TwinkleButtonEnabled
        {
            get
            {
                return mTwinkleButton.Enabled; 
            }
            set
            {
                mTwinkleButton.Enabled = value; 
            }
        }

        public event TypedDelegate<Color> Color1Changed;

        public event TypedDelegate<Color> Color2Changed;

        #endregion

        #region Handlers
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            HandleStopButtonClicked(this, e); 
        }

        private void HandleStopButtonClicked(object sender, EventArgs e)
        {
            EventUtils.FireEvent(StopFired); 
        }

        private void mTwinkleButton_Click(object sender, EventArgs e)
        {
            EventUtils.FireEvent(TwinkleFired); 
        }

        private void mIntensityBar_ValueChanged(object sender, EventArgs e)
        {
            EventUtils.FireTypedEvent<int>(SpeedChanged, mIntensityBar.Value * 10); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                Color1 = cd.Color;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                Color2 = cd.Color;
            }
        }
        #endregion 
    
        #region IModuleView Members

        public new event VoidDelegate Disposing;

        

        #endregion


    }
}
