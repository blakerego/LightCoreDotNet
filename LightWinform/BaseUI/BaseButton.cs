using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using gigaFlash.Delegates;

namespace GigaFlashWinform
{
    /// <summary>
    /// Need this class to capture the double click event. 
    /// The standard Button does not have a double click event. 
    /// </summary>
    public partial class BaseButton : Button
    {
        public BaseButton()
        {
            InitializeComponent();
            SetStyle(ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, true);
        }
    }
}
