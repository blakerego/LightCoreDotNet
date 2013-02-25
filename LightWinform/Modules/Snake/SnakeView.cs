using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using gigaFlash.Delegates;
using gigaFlash.Modules;

namespace GigaFlashWinform
{
    public partial class SnakeView : BaseForm, ISnakeView
    {
        #region Constructor
        public SnakeView()
        {
            InitializeComponent();
        }
        #endregion

        #region Members / Properties
        public event TypedDelegate<Color> StartFired;

        public event VoidDelegate StopFired;

        public new event VoidDelegate Disposing;

        public bool RunButtonEnabled
        {
            get
            {
                return mSnakeButton.Enabled;
            }
            set
            {
                mSnakeButton.Enabled = value;
            }
        }
        #endregion

        #region Handlers
        private void HandleRunSnakeClicked(object sender, EventArgs e)
        {
            ColorDialog d = new ColorDialog();
            if (d.ShowDialog() == DialogResult.OK)
            {
                EventUtils.FireTypedEvent(StartFired, d.Color);
            }
        }

        private void HandleStopSnakeClicked(object sender, EventArgs e)
        {
            EventUtils.FireEvent(StopFired);
        }

        private void mIntensityBar_ValueChanged(object sender, EventArgs e)
        {
            EventUtils.FireTypedEvent(SpeedChanged, mIntensityBar.Value * 10); 
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            EventUtils.FireEvent(Disposing); 
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion


        #region IThreadedView Members


        public event TypedDelegate<int> SpeedChanged;

        #endregion


    }
}
