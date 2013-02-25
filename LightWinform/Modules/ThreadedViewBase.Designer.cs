namespace GigaFlashWinform.Modules
{
    partial class ThreadedViewBase
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        protected virtual void InitializeComponent()
        {
            this.mRunButton = new System.Windows.Forms.Button();
            this.mStopButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mRunButton
            // 
            this.mRunButton.Location = new System.Drawing.Point(12, 12);
            this.mRunButton.Name = "mRunButton";
            this.mRunButton.Size = new System.Drawing.Size(75, 23);
            this.mRunButton.TabIndex = 0;
            this.mRunButton.Text = "Run";
            this.mRunButton.UseVisualStyleBackColor = true;
            this.mRunButton.Click += new System.EventHandler(this.mRunButton_Click);
            // 
            // mStopButton
            // 
            this.mStopButton.Location = new System.Drawing.Point(93, 12);
            this.mStopButton.Name = "mStopButton";
            this.mStopButton.Size = new System.Drawing.Size(75, 23);
            this.mStopButton.TabIndex = 1;
            this.mStopButton.Text = "Stop";
            this.mStopButton.UseVisualStyleBackColor = true;
            this.mStopButton.Click += new System.EventHandler(this.mStopButton_Click);
            // 
            // ThreadedViewBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(189, 49);
            this.Controls.Add(this.mStopButton);
            this.Controls.Add(this.mRunButton);
            this.Name = "ThreadedViewBase";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button mRunButton;
        private System.Windows.Forms.Button mStopButton;
    }
}
