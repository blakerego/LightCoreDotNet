namespace GigaFlashWinform.Modules
{
    partial class AmpSineView
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
            this.mTwinkleButton = new System.Windows.Forms.Button();
            this.mIntensityBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mIntensityBar)).BeginInit();
            this.SuspendLayout();
            // 
            // mTwinkleButton
            // 
            this.mTwinkleButton.BackColor = System.Drawing.Color.Black;
            this.mTwinkleButton.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mTwinkleButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mTwinkleButton.Location = new System.Drawing.Point(34, 161);
            this.mTwinkleButton.Name = "mTwinkleButton";
            this.mTwinkleButton.Size = new System.Drawing.Size(96, 23);
            this.mTwinkleButton.TabIndex = 2;
            this.mTwinkleButton.Text = "Twinkle";
            this.mTwinkleButton.UseVisualStyleBackColor = false;
            this.mTwinkleButton.Click += new System.EventHandler(this.mTwinkleButton_Click);
            // 
            // mIntensityBar
            // 
            this.mIntensityBar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.mIntensityBar.Location = new System.Drawing.Point(12, 48);
            this.mIntensityBar.Name = "mIntensityBar";
            this.mIntensityBar.Size = new System.Drawing.Size(148, 45);
            this.mIntensityBar.TabIndex = 12;
            this.mIntensityBar.Value = 5;
            this.mIntensityBar.ValueChanged += new System.EventHandler(this.mIntensityBar_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 19);
            this.label1.TabIndex = 13;
            this.label1.Text = "Speed";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(76, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 23);
            this.button1.TabIndex = 14;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Fade from:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(111, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "to:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(135, 99);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(25, 23);
            this.button3.TabIndex = 18;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // AmpSineView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(179, 140);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mIntensityBar);
            this.Controls.Add(this.mTwinkleButton);
            this.Name = "AmpSineView";
            this.Text = "Pulse";
            ((System.ComponentModel.ISupportInitialize)(this.mIntensityBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button mTwinkleButton;
        private System.Windows.Forms.TrackBar mIntensityBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
    }
}