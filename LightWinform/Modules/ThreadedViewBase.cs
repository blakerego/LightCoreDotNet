using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using gigaFlash.Modules;
using gigaFlash.Delegates;

namespace GigaFlashWinform.Modules
{
    public partial class ThreadedViewBase : BaseForm, IThreadedView
    {
        #region Constructor
        public ThreadedViewBase()
        {
            InitializeComponent();
        }
        #endregion 

        #region IThreadedView Members

        public bool RunButtonEnabled
        {
            get
            {
                return mRunButton.Enabled; 
            }
            set
            {
                mRunButton.Enabled = value; 
            }
        }

        public event TypedDelegate<Color> StartFired;

        public event VoidDelegate StopFired;

        public event VoidDelegate Disposing; 

        #endregion

        #region Handlers
        private void mRunButton_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                EventUtils.FireTypedEvent(StartFired, cd.Color);
            }
        }

        private void mStopButton_Click(object sender, EventArgs e)
        {
            EventUtils.FireEvent(StopFired); 
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
