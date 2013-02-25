namespace GigaFlashWinform
{
    partial class MainFormView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormView));
            this.button1 = new System.Windows.Forms.Button();
            this.mRoom = new GigaFlashWinform.RoomUI.Room();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(453, 33);
            this.button1.TabIndex = 3;
            this.button1.Text = "Clear All";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.HandleClearClicked);
            // 
            // mRoom
            // 
            this.mRoom.BackColor = System.Drawing.Color.White;
            this.mRoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mRoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mRoom.Location = new System.Drawing.Point(0, 0);
            this.mRoom.Name = "mRoom";
            this.mRoom.RoomIntensity = 100;
            this.mRoom.Size = new System.Drawing.Size(453, 296);
            this.mRoom.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.mRoom);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Size = new System.Drawing.Size(453, 333);
            this.splitContainer1.SplitterDistance = 296;
            this.splitContainer1.TabIndex = 4;
            // 
            // MainFormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 333);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.Name = "MainFormView";
            this.Text = "Home Light Control";
            this.Load += new System.EventHandler(this.MainFormView_Load);
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.MainFormView_Scroll);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainFormView_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GigaFlashWinform.RoomUI.Room mRoom;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}