using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gigaFlash.Modules;
using GigaFlashWinform.Modules.Thunder;

namespace GigaFlashWinform.Modules
{
    public class ThunderViewFactory : IViewFactory<IThunderView>
    {
        public IThunderView Create()
        {
            return new ThunderView(); 
        }
    }
}
