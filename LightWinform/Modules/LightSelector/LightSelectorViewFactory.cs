using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gigaFlash.Modules;
using gigaFlash;

namespace GigaFlashWinform.Modules
{
    public class LightSelectorViewFactory : IViewFactory<ILightSelectorView>
    {
        ILightSelectorView IViewFactory<ILightSelectorView>.Create()
        {
            return new LightSelector(); 
        }
    }
}
