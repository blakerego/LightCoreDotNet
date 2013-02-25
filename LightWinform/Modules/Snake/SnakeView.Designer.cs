namespace GigaFlashWinform
{
    partial class SnakeView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mSnakeButton = new System.Windows.Forms.Button();
            this.mStopButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.mIntensityBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.mIntensityBar)).BeginInit();
            this.SuspendLayout();
            // 
            // mSnakeButton
            // 
            this.mSnakeButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.mSnakeButton.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mSnakeButton.ForeColor = System.Drawing.Color.Snow;
            this.mSnakeButton.Location = new System.Drawing.Point(22, 89);
            this.mSnakeButton.Name = "mSnakeButton";
            this.mSnakeButton.Size = new System.Drawing.Size(75, 23);
            this.mSnakeButton.TabIndex = 3;
            this.mSnakeButton.Text = "Snake!";
            this.mSnakeButton.UseVisualStyleBackColor = false;
            this.mSnakeButton.Click += new System.EventHandler(this.HandleRunSnakeClicked);
            // 
            // mStopButton
            // 
            this.mStopButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.mStopButton.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mStopButton.ForeColor = System.Drawing.Color.Snow;
            this.mStopButton.Location = new System.Drawing.Point(103, 89);
            this.mStopButton.Name = "mStopButton";
            this.mStopButton.Size = new System.Drawing.Size(75, 23);
            this.mStopButton.TabIndex = 4;
            this.mStopButton.Text = "Stop";
            this.mStopButton.UseVisualStyleBackColor = false;
            this.mStopButton.Click += new System.EventHandler(this.HandleStopSnakeClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(74, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 19);
            this.label1.TabIndex = 15;
            this.label1.Text = "Speed";
            // 
            // mIntensityBar
            // 
            this.mIntensityBar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.mIntensityBar.Location = new System.Drawing.Point(22, 29);
            this.mIntensityBar.Name = "mIntensityBar";
            this.mIntensityBar.Size = new System.Drawing.Size(156, 45);
            this.mIntensityBar.TabIndex = 14;
            this.mIntensityBar.Value = 5;
            this.mIntensityBar.ValueChanged += new System.EventHandler(this.mIntensityBar_ValueChanged);
            // 
            // SnakeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 137);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mIntensityBar);
            this.Controls.Add(this.mStopButton);
            this.Controls.Add(this.mSnakeButton);
            this.Name = "SnakeView";
            this.Text = "Snake!";
            ((System.ComponentModel.ISupportInitialize)(this.mIntensityBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button mSnakeButton;
        private System.Windows.Forms.Button mStopButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar mIntensityBar;
    }
}