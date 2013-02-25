using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using gigaFlash;
using gigaFlash.Mainform;
using System.IO;
using gigaFlash.ConfigObjects;

namespace GigaFlashWinform.UserAccess
{
    public partial class LoginScreen : BaseForm
    {
        public LoginScreen(MainFormView pParentMFV)
        {
            mParentForm = pParentMFV; 
            InitializeComponent();
        }

        private void HandleCancelClicked(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void HandleOKClicked(object sender, EventArgs e)
        {
            MainFormView mainform = this.ParentMainForm;
            string loadPath = "" ; 
            if (!mCreateNewUserCheckbox.Checked)
            {
                
                string[] paths = Directory.GetFiles(UserPrefObj.ConfigPath);
                bool usernameFound = false;
                
                foreach (string path in paths)
                {
                    string nameWithExt = Path.GetFileName(path);
                    string configName = nameWithExt.Remove(nameWithExt.Length - 4);
                    if (configName == textBox1.Text)
                    {
                        usernameFound = true;
                        loadPath = path;
                    }
                }
                if (usernameFound)
                {
                    UserPrefObj prefObj = GrandConfigSerializer<UserPrefObj>.FromXML(
                        loadPath, ConfigOrientation.fromDisk);
                    if (prefObj != null) 
                        mainform.LoadPreferences(prefObj); 
                }
                else
                {
                    
                }

            }

            if (mainform != null)
            {
                mainform.CurrentUser = textBox1.Text; 
            }
            this.Close(); 
        }

        protected MainFormView mParentForm;

        public MainFormView ParentMainForm
        {
            get { return mParentForm; } 
        }

        private void HandleKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HandleOKClicked(sender, e); 
            }
        }
    }
}
