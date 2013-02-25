using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GigaFlashWinform.Modules.RoomUI
{
    public partial class ColorSaveDialog : BaseForm
    {
        public ColorSaveDialog()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        public String ColorName
        {
            get { return textBox1.Text; } 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK; 
            this.Close(); 
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false; 
            }
        }
    }
}
