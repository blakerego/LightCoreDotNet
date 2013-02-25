using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gigaFlash.Modules;

namespace GigaFlashWinform.Modules
{
    public class SnakeViewFactory : IViewFactory<ISnakeView>
    {
        public ISnakeView Create()
        {
            return new SnakeView(); 
        }
    }
}
