using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using gigaFlash.Mainform;
using gigaFlash;
using gigaFlash.Modules;
using GigaFlashWinform.Modules;
using GigaFlashWinform.UserAccess;

namespace GigaFlashWinform
{
    static class MainEntryPoint
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Loading specific UI Modules. 
            ModuleCatalog.Instance.Add(ModuleOptions.LightSelector, new LightSelectorViewFactory());
            ModuleCatalog.Instance.Add(ModuleOptions.Snake, new SnakeViewFactory());
            ModuleCatalog.Instance.Add(ModuleOptions.AmpSine, new AmpSineViewFactory());
            ModuleCatalog.Instance.Add(ModuleOptions.Thunder, new ThunderViewFactory());
            ModuleCatalog.Instance.Add(ModuleOptions.Room, new RoomViewFactory()); 


            LightState state = new LightState(11);
            MainFormView view = new MainFormView();
            view.StartPosition = FormStartPosition.CenterScreen; 
            MainFormPresenter pres = new MainFormPresenter(view, state);

            LoginScreen login = new LoginScreen(view);
            login.StartPosition = FormStartPosition.CenterScreen; 
            login.ShowDialog(view);

            Application.Run(view);
        }

    }
}
