namespace GigaFlashWinform
{
    partial class LightSelector
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
            this.mUpdateButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.mRed = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mRedTextbox = new System.Windows.Forms.TextBox();
            this.mGreenTextbox = new System.Windows.Forms.TextBox();
            this.mBlueTextbox = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.mListbox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // mUpdateButton
            // 
            this.mUpdateButton.Location = new System.Drawing.Point(15, 99);
            this.mUpdateButton.Name = "mUpdateButton";
            this.mUpdateButton.Size = new System.Drawing.Size(75, 23);
            this.mUpdateButton.TabIndex = 0;
            this.mUpdateButton.Text = "Update";
            this.mUpdateButton.UseVisualStyleBackColor = true;
            this.mUpdateButton.Click += new System.EventHandler(this.HandleUpdateClicked);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 128);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.HandleClearClicked);
            // 
            // mRed
            // 
            this.mRed.AutoSize = true;
            this.mRed.Location = new System.Drawing.Point(12, 12);
            this.mRed.Name = "mRed";
            this.mRed.Size = new System.Drawing.Size(27, 13);
            this.mRed.TabIndex = 2;
            this.mRed.Text = "Red";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Green";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Blue";
            // 
            // mRedTextbox
            // 
            this.mRedTextbox.Location = new System.Drawing.Point(60, 9);
            this.mRedTextbox.Name = "mRedTextbox";
            this.mRedTextbox.ReadOnly = true;
            this.mRedTextbox.Size = new System.Drawing.Size(57, 20);
            this.mRedTextbox.TabIndex = 5;
            this.mRedTextbox.Text = "0";
            // 
            // mGreenTextbox
            // 
            this.mGreenTextbox.Location = new System.Drawing.Point(60, 32);
            this.mGreenTextbox.Name = "mGreenTextbox";
            this.mGreenTextbox.ReadOnly = true;
            this.mGreenTextbox.Size = new System.Drawing.Size(57, 20);
            this.mGreenTextbox.TabIndex = 6;
            this.mGreenTextbox.Text = "0";
            // 
            // mBlueTextbox
            // 
            this.mBlueTextbox.Location = new System.Drawing.Point(60, 58);
            this.mBlueTextbox.Name = "mBlueTextbox";
            this.mBlueTextbox.ReadOnly = true;
            this.mBlueTextbox.Size = new System.Drawing.Size(57, 20);
            this.mBlueTextbox.TabIndex = 7;
            this.mBlueTextbox.Text = "0";
            // 
            // colorDialog1
            // 
            this.colorDialog1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            // 
            // mListbox
            // 
            this.mListbox.FormattingEnabled = true;
            this.mListbox.Location = new System.Drawing.Point(141, 9);
            this.mListbox.Name = "mListbox";
            this.mListbox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.mListbox.Size = new System.Drawing.Size(192, 147);
            this.mListbox.TabIndex = 8;
            // 
            // LightSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(347, 167);
            this.Controls.Add(this.mListbox);
            this.Controls.Add(this.mBlueTextbox);
            this.Controls.Add(this.mGreenTextbox);
            this.Controls.Add(this.mRedTextbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mRed);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.mUpdateButton);
            this.Name = "LightSelector";
            this.Text = "Light Selector";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LightSelector_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button mUpdateButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label mRed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox mRedTextbox;
        private System.Windows.Forms.TextBox mGreenTextbox;
        private System.Windows.Forms.TextBox mBlueTextbox;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ListBox mListbox;
    }
}

