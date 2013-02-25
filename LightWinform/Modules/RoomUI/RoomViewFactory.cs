using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gigaFlash;
using GigaFlashWinform.RoomUI;
using gigaFlash.Modules;

namespace GigaFlashWinform
{
    public class RoomViewFactory : IViewFactory<IRoom>
    {
        public IRoom Create()
        {
            return new Room(); 
        }
    }
}
