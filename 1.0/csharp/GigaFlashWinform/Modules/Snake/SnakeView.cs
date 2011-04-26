﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using gigaFlash.Delegates;

namespace gigaFlash.Modules
{
    public partial class SnakeView : Form, ISnakeView
    {
		#region Constructor
        public SnakeView()
        {
            InitializeComponent();
        }
		#endregion
		
		#region Members / Properties
		public event VoidDelegate StartFired;

        public event VoidDelegate StopFired;

        public bool RunSnakeButtonEnabled
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
            EventUtils.FireEvent(StartFired); 
        }

        private void HandleStopSnakeClicked(object sender, EventArgs e)
        {
            EventUtils.FireEvent(StopFired);
        }
        #endregion 
    }
}
