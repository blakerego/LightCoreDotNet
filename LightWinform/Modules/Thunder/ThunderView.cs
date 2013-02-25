using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using gigaFlash.Modules;

namespace GigaFlashWinform.Modules.Thunder
{
    public partial class ThunderView : ThreadedViewBase, IThunderView
    {
        public ThunderView()
        {
            InitializeComponent();
        }
    }
}
