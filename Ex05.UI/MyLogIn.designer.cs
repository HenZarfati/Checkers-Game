namespace Interface
{
    partial class MyLogIn
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
			this.m_LabelBoradSize = new System.Windows.Forms.Label();
			this.m_RadioButton6X6 = new System.Windows.Forms.RadioButton();
			this.m_RdioButtom8X8 = new System.Windows.Forms.RadioButton();
			this.m_RadioButton10X10 = new System.Windows.Forms.RadioButton();
			this.m_LabelPlayers = new System.Windows.Forms.Label();
			this.m_LabelPlayer1 = new System.Windows.Forms.Label();
			this.m_LabelPlayer2 = new System.Windows.Forms.Label();
			this.m_CheckBoxPlayer2 = new System.Windows.Forms.CheckBox();
			this.m_TextBoxPlayer1 = new System.Windows.Forms.TextBox();
			this.m_TextBoxPlayer2 = new System.Windows.Forms.TextBox();
			this.m_ButtonDone = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// m_LabelBoradSize
			// 
			this.m_LabelBoradSize.AutoSize = true;
			this.m_LabelBoradSize.Location = new System.Drawing.Point(34, 31);
			this.m_LabelBoradSize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.m_LabelBoradSize.Name = "m_LabelBoradSize";
			this.m_LabelBoradSize.Size = new System.Drawing.Size(77, 17);
			this.m_LabelBoradSize.TabIndex = 0;
			this.m_LabelBoradSize.Text = "BoardSize:";
			// 
			// m_RadioButton6X6
			// 
			this.m_RadioButton6X6.AutoSize = true;
			this.m_RadioButton6X6.Location = new System.Drawing.Point(60, 60);
			this.m_RadioButton6X6.Margin = new System.Windows.Forms.Padding(2);
			this.m_RadioButton6X6.Name = "m_RadioButton6X6";
			this.m_RadioButton6X6.Size = new System.Drawing.Size(54, 21);
			this.m_RadioButton6X6.TabIndex = 1;
			this.m_RadioButton6X6.TabStop = true;
			this.m_RadioButton6X6.Text = "6X6";
			this.m_RadioButton6X6.UseVisualStyleBackColor = true;
			// 
			// m_RdioButtom8X8
			// 
			this.m_RdioButtom8X8.AutoSize = true;
			this.m_RdioButtom8X8.Location = new System.Drawing.Point(136, 60);
			this.m_RdioButtom8X8.Margin = new System.Windows.Forms.Padding(2);
			this.m_RdioButtom8X8.Name = "m_RdioButtom8X8";
			this.m_RdioButtom8X8.Size = new System.Drawing.Size(54, 21);
			this.m_RdioButtom8X8.TabIndex = 2;
			this.m_RdioButtom8X8.TabStop = true;
			this.m_RdioButtom8X8.Text = "8X8";
			this.m_RdioButtom8X8.UseVisualStyleBackColor = true;
			// 
			// m_RadioButton10X10
			// 
			this.m_RadioButton10X10.AutoSize = true;
			this.m_RadioButton10X10.Location = new System.Drawing.Point(211, 60);
			this.m_RadioButton10X10.Margin = new System.Windows.Forms.Padding(2);
			this.m_RadioButton10X10.Name = "m_RadioButton10X10";
			this.m_RadioButton10X10.Size = new System.Drawing.Size(70, 21);
			this.m_RadioButton10X10.TabIndex = 3;
			this.m_RadioButton10X10.TabStop = true;
			this.m_RadioButton10X10.Text = "10X10";
			this.m_RadioButton10X10.UseVisualStyleBackColor = true;
			// 
			// m_LabelPlayers
			// 
			this.m_LabelPlayers.AutoSize = true;
			this.m_LabelPlayers.Location = new System.Drawing.Point(34, 93);
			this.m_LabelPlayers.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.m_LabelPlayers.Name = "m_LabelPlayers";
			this.m_LabelPlayers.Size = new System.Drawing.Size(59, 17);
			this.m_LabelPlayers.TabIndex = 4;
			this.m_LabelPlayers.Text = "Players:";
			// 
			// m_LabelPlayer1
			// 
			this.m_LabelPlayer1.AutoSize = true;
			this.m_LabelPlayer1.Location = new System.Drawing.Point(47, 122);
			this.m_LabelPlayer1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.m_LabelPlayer1.Name = "m_LabelPlayer1";
			this.m_LabelPlayer1.Size = new System.Drawing.Size(64, 17);
			this.m_LabelPlayer1.TabIndex = 5;
			this.m_LabelPlayer1.Text = "Player 1:";
			// 
			// m_LabelPlayer2
			// 
			this.m_LabelPlayer2.AutoSize = true;
			this.m_LabelPlayer2.Location = new System.Drawing.Point(79, 155);
			this.m_LabelPlayer2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.m_LabelPlayer2.Name = "m_LabelPlayer2";
			this.m_LabelPlayer2.Size = new System.Drawing.Size(64, 17);
			this.m_LabelPlayer2.TabIndex = 6;
			this.m_LabelPlayer2.Text = "Player 2:";
			// 
			// m_CheckBoxPlayer2
			// 
			this.m_CheckBoxPlayer2.AutoSize = true;
			this.m_CheckBoxPlayer2.Location = new System.Drawing.Point(50, 153);
			this.m_CheckBoxPlayer2.Margin = new System.Windows.Forms.Padding(2);
			this.m_CheckBoxPlayer2.Name = "m_CheckBoxPlayer2";
			this.m_CheckBoxPlayer2.Size = new System.Drawing.Size(18, 17);
			this.m_CheckBoxPlayer2.TabIndex = 7;
			this.m_CheckBoxPlayer2.UseVisualStyleBackColor = true;
			this.m_CheckBoxPlayer2.Click += new System.EventHandler(this.m_Player2CheckBox_Click);
			// 
			// m_TextBoxPlayer1
			// 
			this.m_TextBoxPlayer1.Location = new System.Drawing.Point(168, 121);
			this.m_TextBoxPlayer1.Margin = new System.Windows.Forms.Padding(2);
			this.m_TextBoxPlayer1.Name = "m_TextBoxPlayer1";
			this.m_TextBoxPlayer1.Size = new System.Drawing.Size(124, 22);
			this.m_TextBoxPlayer1.TabIndex = 8;
			// 
			// m_TextBoxPlayer2
			// 
			this.m_TextBoxPlayer2.Enabled = false;
			this.m_TextBoxPlayer2.Location = new System.Drawing.Point(168, 152);
			this.m_TextBoxPlayer2.Margin = new System.Windows.Forms.Padding(2);
			this.m_TextBoxPlayer2.Name = "m_TextBoxPlayer2";
			this.m_TextBoxPlayer2.Size = new System.Drawing.Size(124, 22);
			this.m_TextBoxPlayer2.TabIndex = 9;
			this.m_TextBoxPlayer2.Text = "[Computer]";
			// 
			// m_ButtonDone
			// 
			this.m_ButtonDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.m_ButtonDone.Location = new System.Drawing.Point(210, 205);
			this.m_ButtonDone.Margin = new System.Windows.Forms.Padding(2);
			this.m_ButtonDone.Name = "m_ButtonDone";
			this.m_ButtonDone.Size = new System.Drawing.Size(83, 35);
			this.m_ButtonDone.TabIndex = 10;
			this.m_ButtonDone.Text = "Done";
			this.m_ButtonDone.UseVisualStyleBackColor = true;
			this.m_ButtonDone.Click += new System.EventHandler(this.m_ButtonDone_Click);
			// 
			// MyLogIn
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(299, 246);
			this.Controls.Add(this.m_ButtonDone);
			this.Controls.Add(this.m_TextBoxPlayer2);
			this.Controls.Add(this.m_TextBoxPlayer1);
			this.Controls.Add(this.m_CheckBoxPlayer2);
			this.Controls.Add(this.m_LabelPlayer2);
			this.Controls.Add(this.m_LabelPlayer1);
			this.Controls.Add(this.m_LabelPlayers);
			this.Controls.Add(this.m_RadioButton10X10);
			this.Controls.Add(this.m_RdioButtom8X8);
			this.Controls.Add(this.m_RadioButton6X6);
			this.Controls.Add(this.m_LabelBoradSize);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "MyLogIn";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Text = "GameSettings";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_LabelBoradSize;
        private System.Windows.Forms.RadioButton m_RadioButton6X6;
        private System.Windows.Forms.RadioButton m_RdioButtom8X8;
        private System.Windows.Forms.RadioButton m_RadioButton10X10;
        private System.Windows.Forms.Label m_LabelPlayers;
        private System.Windows.Forms.Label m_LabelPlayer1;
        private System.Windows.Forms.Label m_LabelPlayer2;
        private System.Windows.Forms.CheckBox m_CheckBoxPlayer2;
        private System.Windows.Forms.TextBox m_TextBoxPlayer1;
        private System.Windows.Forms.TextBox m_TextBoxPlayer2;
        private System.Windows.Forms.Button m_ButtonDone;
    }
}