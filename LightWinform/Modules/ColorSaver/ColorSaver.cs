using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using gigaFlash.Delegates;
using gigaFlash; 

namespace GigaFlashWinform.ColorSaver
{
    public partial class ColorSaver : BaseForm, IColorSaverView
    {
        #region Constructor
        public ColorSaver()
        {
            InitializeComponent();
        }
        #endregion

        #region Handlers
        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog d = new ColorDialog();
            if (d.ShowDialog(this) == DialogResult.OK)
            {
                if (d.Color != null) 
                    EventUtils.FireTypedEvent(ColorSaveRequested, d.Color); 
            }
        }
        #endregion 

        #region Members / Properties
        public event TypedDelegate<Color> ColorSaveRequested; 
        #endregion 
    }
}
