using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using gigaFlash.Mainform;
using gigaFlash.Delegates;
using System.Management;
using System.IO;
using System.Media;
using gigaFlash;
using GigaFlashWinform.UserAccess;
using gigaFlash.ConfigObjects;

namespace GigaFlashWinform
{
    public partial class MainFormView : BaseForm, IMainformView
    {
        #region Constructor 
        public MainFormView()
        {
            InitializeComponent();
            InitializeMenus();
        }
        #endregion 

        #region Setup 
        protected void InitializeMenus()
        {
            mMenuStrip = new MenuStrip();
            this.Controls.Add(mMenuStrip);

            #region File Menu
            mFileMenuItem = new ToolStripMenuItem("&File");
            mMenuStrip.Items.Add(mFileMenuItem);

            ToolStripMenuItem changeLogin = new ToolStripMenuItem("Change username / login");
            changeLogin.Click += new EventHandler(ChangeLoginClicked);
            mFileMenuItem.DropDownItems.Add(changeLogin); 

            //Create the New menu Items and add it to the FileMenu above. We are also going to create the click event for the item.
            mSaveMenuItem = new ToolStripMenuItem("Save Room");
            //SaveMenuItem.Click += new EventHandler(New_Click);
            if (String.IsNullOrEmpty(mCurrentUser))
                mSaveMenuItem.Enabled = false; 
            mFileMenuItem.DropDownItems.Add(mSaveMenuItem);
            #endregion 

            #region Insert Menu
            ToolStripMenuItem InsertMenuItem = new ToolStripMenuItem("&Run");
            mMenuStrip.Items.Add(InsertMenuItem);

            ToolStripMenuItem SnakeMenuItem = new ToolStripMenuItem("Snake");
            SnakeMenuItem.Click += new EventHandler(HandleSnakeModuleClicked);
            InsertMenuItem.DropDownItems.Add(SnakeMenuItem);
            
            ToolStripMenuItem LightSelectorMenuItem = new ToolStripMenuItem("Light Selector");
            LightSelectorMenuItem.Click += new EventHandler(HandleLightSelectorClicked);
            InsertMenuItem.DropDownItems.Add(LightSelectorMenuItem);

            ToolStripMenuItem SineMenuItem = new ToolStripMenuItem("Pulse");
            SineMenuItem.Click += new EventHandler(mAmpSineButton_Click);
            InsertMenuItem.DropDownItems.Add(SineMenuItem);
            #endregion 
        }

        public void LoadPreferences(UserPrefObj pPreferences)
        {
            mRoom.LoadPreferences(pPreferences);
            EventUtils.FireTypedEvent(PreferencesLoaded, pPreferences); 
        }
        #endregion 

        #region Members / Properties
        protected MenuStrip mMenuStrip;
        ToolStripMenuItem mFileMenuItem;
        ToolStripMenuItem mSaveMenuItem;

        public event TypedDelegate<UserPrefObj> PreferencesLoaded; 

        public Control Control
        {
            get
            {
                return this;
            }
        }

        
        public IRoom RoomView
        {
            get { return mRoom; } 
        }

        protected string mCurrentUser;
        public string CurrentUser
        {
            get { return mCurrentUser; }
            set 
            { 
                mCurrentUser = value;
                if (mSaveMenuItem != null)
                {
                    mSaveMenuItem.Enabled = true; 
                }
            } 
        }

        public event VoidDelegate LightSelectorClicked;

        public event VoidDelegate SnakeModuleClicked;

        public event VoidDelegate AmpSineClicked;

        public event VoidDelegate ThunderClicked;

        public event VoidDelegate MoveLightLeftEvent;

        public event VoidDelegate MoveLightRightEvent;

        public event VoidDelegate ClickEventFired;
        #endregion

        #region Handlers
        private void HandleLightSelectorClicked(object sender, EventArgs e)
        {
            EventUtils.FireEvent(LightSelectorClicked);
        }

        private void HandleSnakeModuleClicked(object sender, EventArgs e)
        {
            EventUtils.FireEvent(SnakeModuleClicked); 
        }

        private void mAmpSineButton_Click(object sender, EventArgs e)
        {
            EventUtils.FireEvent(AmpSineClicked); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //BassWv.LoadMe("C:\\svn\\batcave\\abslabs\\wav\\Dura.wav");
        }

        private void mThunderButton_Click(object sender, EventArgs e)
        {
            EventUtils.FireEvent(ThunderClicked); 
        }

        private void ChangeLoginClicked(object sender, EventArgs e)
        {
            LoginScreen ls = new LoginScreen(this);
            ls.StartPosition = FormStartPosition.CenterParent;
            ls.ShowDialog(this); 
        }

        protected virtual void MainFormView_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                int scrollDiff = e.NewValue - e.OldValue;
                if (scrollDiff > 0)
                {
                    EventUtils.FireEvent(MoveLightRightEvent);
                }
                else
                {
                    EventUtils.FireEvent(MoveLightLeftEvent); 
                }
            }
        }

        private void MainFormView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                EventUtils.FireEvent(MoveLightLeftEvent); 
            }
            else if (e.KeyCode == Keys.Right)
            {
                EventUtils.FireEvent(MoveLightRightEvent); 
            }

        }

        void MainFormView_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                EventUtils.FireEvent(MoveLightLeftEvent);
            }
            else if (e.Delta < 0)
            {
                EventUtils.FireEvent(MoveLightRightEvent); 
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            EventUtils.FireEvent(ClickEventFired);
        }


        private void MainFormView_Load(object sender, EventArgs e)
        {
            this.BringToFront();
            this.Focus();
            //this.KeyPreview = true;
            //this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            //this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.MainFormView_Scroll);
            //this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainFormView_KeyDown);
            //this.Click += new EventHandler(textBox1_Click);
            //this.splitContainer1.Click += new EventHandler(textBox1_Click);
            //this.MouseWheel += new MouseEventHandler(MainFormView_MouseWheel);
        }

        private void HandleClearClicked(object sender, EventArgs e)
        {
            mRoom.RoomIntensity = 0; 
        }

        #endregion
    }
}
