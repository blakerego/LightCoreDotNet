using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gigaFlash.Modules;
using GigaFlashWinform.Modules; 

namespace GigaFlashWinform
{
    public class AmpSineViewFactory : IViewFactory<IAmpSineView>
    {
        public IAmpSineView Create()
        {
            return new AmpSineView(); 
        }
    }
}
