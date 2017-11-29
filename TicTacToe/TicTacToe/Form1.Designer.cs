namespace TicTacToe
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.Btn0x0 = new System.Windows.Forms.Button();
            this.Btn0x1 = new System.Windows.Forms.Button();
            this.Btn0x2 = new System.Windows.Forms.Button();
            this.Btn1x0 = new System.Windows.Forms.Button();
            this.Btn1x1 = new System.Windows.Forms.Button();
            this.Btn1x2 = new System.Windows.Forms.Button();
            this.Btn2x0 = new System.Windows.Forms.Button();
            this.Btn2x1 = new System.Windows.Forms.Button();
            this.Btn2x2 = new System.Windows.Forms.Button();
            this.LblSpieler1 = new System.Windows.Forms.Label();
            this.LblSpieler2 = new System.Windows.Forms.Label();
            this.MtxtBoxSpieler1 = new System.Windows.Forms.MaskedTextBox();
            this.MtxtBoxSpieler2 = new System.Windows.Forms.MaskedTextBox();
            this.CoBoxSpieler1 = new System.Windows.Forms.ComboBox();
            this.CoBoxSpieler2 = new System.Windows.Forms.ComboBox();
            this.BtnSpielStarten = new System.Windows.Forms.Button();
            this.LblSpieler1Punkte = new System.Windows.Forms.Label();
            this.LblSpieler2Punkte = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Btn0x0
            // 
            this.Btn0x0.Enabled = false;
            this.Btn0x0.Location = new System.Drawing.Point(8, 12);
            this.Btn0x0.Name = "Btn0x0";
            this.Btn0x0.Size = new System.Drawing.Size(75, 75);
            this.Btn0x0.TabIndex = 0;
            this.Btn0x0.UseVisualStyleBackColor = true;
            this.Btn0x0.Click += new System.EventHandler(this.Spielfeld_Click);
            // 
            // Btn0x1
            // 
            this.Btn0x1.Enabled = false;
            this.Btn0x1.Location = new System.Drawing.Point(89, 12);
            this.Btn0x1.Name = "Btn0x1";
            this.Btn0x1.Size = new System.Drawing.Size(75, 75);
            this.Btn0x1.TabIndex = 1;
            this.Btn0x1.UseVisualStyleBackColor = true;
            this.Btn0x1.Click += new System.EventHandler(this.Spielfeld_Click);
            // 
            // Btn0x2
            // 
            this.Btn0x2.Enabled = false;
            this.Btn0x2.Location = new System.Drawing.Point(170, 12);
            this.Btn0x2.Name = "Btn0x2";
            this.Btn0x2.Size = new System.Drawing.Size(75, 75);
            this.Btn0x2.TabIndex = 2;
            this.Btn0x2.UseVisualStyleBackColor = true;
            this.Btn0x2.Click += new System.EventHandler(this.Spielfeld_Click);
            // 
            // Btn1x0
            // 
            this.Btn1x0.Enabled = false;
            this.Btn1x0.Location = new System.Drawing.Point(8, 93);
            this.Btn1x0.Name = "Btn1x0";
            this.Btn1x0.Size = new System.Drawing.Size(75, 75);
            this.Btn1x0.TabIndex = 3;
            this.Btn1x0.UseVisualStyleBackColor = true;
            this.Btn1x0.Click += new System.EventHandler(this.Spielfeld_Click);
            // 
            // Btn1x1
            // 
            this.Btn1x1.Enabled = false;
            this.Btn1x1.Location = new System.Drawing.Point(89, 93);
            this.Btn1x1.Name = "Btn1x1";
            this.Btn1x1.Size = new System.Drawing.Size(75, 75);
            this.Btn1x1.TabIndex = 4;
            this.Btn1x1.UseVisualStyleBackColor = true;
            this.Btn1x1.Click += new System.EventHandler(this.Spielfeld_Click);
            // 
            // Btn1x2
            // 
            this.Btn1x2.Enabled = false;
            this.Btn1x2.Location = new System.Drawing.Point(170, 93);
            this.Btn1x2.Name = "Btn1x2";
            this.Btn1x2.Size = new System.Drawing.Size(75, 75);
            this.Btn1x2.TabIndex = 5;
            this.Btn1x2.UseVisualStyleBackColor = true;
            this.Btn1x2.Click += new System.EventHandler(this.Spielfeld_Click);
            // 
            // Btn2x0
            // 
            this.Btn2x0.Enabled = false;
            this.Btn2x0.Location = new System.Drawing.Point(8, 174);
            this.Btn2x0.Name = "Btn2x0";
            this.Btn2x0.Size = new System.Drawing.Size(75, 75);
            this.Btn2x0.TabIndex = 6;
            this.Btn2x0.UseVisualStyleBackColor = true;
            this.Btn2x0.Click += new System.EventHandler(this.Spielfeld_Click);
            // 
            // Btn2x1
            // 
            this.Btn2x1.Enabled = false;
            this.Btn2x1.Location = new System.Drawing.Point(89, 174);
            this.Btn2x1.Name = "Btn2x1";
            this.Btn2x1.Size = new System.Drawing.Size(75, 75);
            this.Btn2x1.TabIndex = 7;
            this.Btn2x1.UseVisualStyleBackColor = true;
            this.Btn2x1.Click += new System.EventHandler(this.Spielfeld_Click);
            // 
            // Btn2x2
            // 
            this.Btn2x2.Enabled = false;
            this.Btn2x2.Location = new System.Drawing.Point(170, 174);
            this.Btn2x2.Name = "Btn2x2";
            this.Btn2x2.Size = new System.Drawing.Size(75, 75);
            this.Btn2x2.TabIndex = 8;
            this.Btn2x2.UseVisualStyleBackColor = true;
            this.Btn2x2.Click += new System.EventHandler(this.Spielfeld_Click);
            // 
            // LblSpieler1
            // 
            this.LblSpieler1.AutoSize = true;
            this.LblSpieler1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblSpieler1.Location = new System.Drawing.Point(251, 12);
            this.LblSpieler1.Name = "LblSpieler1";
            this.LblSpieler1.Size = new System.Drawing.Size(66, 19);
            this.LblSpieler1.TabIndex = 9;
            this.LblSpieler1.Text = "Spieler 1";
            // 
            // LblSpieler2
            // 
            this.LblSpieler2.AutoSize = true;
            this.LblSpieler2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblSpieler2.Location = new System.Drawing.Point(402, 12);
            this.LblSpieler2.Name = "LblSpieler2";
            this.LblSpieler2.Size = new System.Drawing.Size(66, 19);
            this.LblSpieler2.TabIndex = 10;
            this.LblSpieler2.Text = "Spieler 2";
            // 
            // MtxtBoxSpieler1
            // 
            this.MtxtBoxSpieler1.Location = new System.Drawing.Point(251, 65);
            this.MtxtBoxSpieler1.Mask = "a";
            this.MtxtBoxSpieler1.Name = "MtxtBoxSpieler1";
            this.MtxtBoxSpieler1.Size = new System.Drawing.Size(65, 22);
            this.MtxtBoxSpieler1.TabIndex = 11;
            this.MtxtBoxSpieler1.Text = "X";
            // 
            // MtxtBoxSpieler2
            // 
            this.MtxtBoxSpieler2.Location = new System.Drawing.Point(403, 65);
            this.MtxtBoxSpieler2.Mask = "a";
            this.MtxtBoxSpieler2.Name = "MtxtBoxSpieler2";
            this.MtxtBoxSpieler2.Size = new System.Drawing.Size(65, 22);
            this.MtxtBoxSpieler2.TabIndex = 12;
            this.MtxtBoxSpieler2.Text = "O";
            // 
            // CoBoxSpieler1
            // 
            this.CoBoxSpieler1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CoBoxSpieler1.FormattingEnabled = true;
            this.CoBoxSpieler1.Location = new System.Drawing.Point(251, 93);
            this.CoBoxSpieler1.Name = "CoBoxSpieler1";
            this.CoBoxSpieler1.Size = new System.Drawing.Size(89, 24);
            this.CoBoxSpieler1.TabIndex = 13;
            // 
            // CoBoxSpieler2
            // 
            this.CoBoxSpieler2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CoBoxSpieler2.FormattingEnabled = true;
            this.CoBoxSpieler2.Location = new System.Drawing.Point(379, 93);
            this.CoBoxSpieler2.Name = "CoBoxSpieler2";
            this.CoBoxSpieler2.Size = new System.Drawing.Size(89, 24);
            this.CoBoxSpieler2.TabIndex = 14;
            // 
            // BtnSpielStarten
            // 
            this.BtnSpielStarten.Location = new System.Drawing.Point(287, 123);
            this.BtnSpielStarten.Name = "BtnSpielStarten";
            this.BtnSpielStarten.Size = new System.Drawing.Size(146, 36);
            this.BtnSpielStarten.TabIndex = 15;
            this.BtnSpielStarten.Text = "Neues Spiel starten";
            this.BtnSpielStarten.UseVisualStyleBackColor = true;
            this.BtnSpielStarten.Click += new System.EventHandler(this.BtnSpielStarten_Click);
            // 
            // LblSpieler1Punkte
            // 
            this.LblSpieler1Punkte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblSpieler1Punkte.Location = new System.Drawing.Point(251, 31);
            this.LblSpieler1Punkte.Name = "LblSpieler1Punkte";
            this.LblSpieler1Punkte.Size = new System.Drawing.Size(66, 31);
            this.LblSpieler1Punkte.TabIndex = 16;
            this.LblSpieler1Punkte.Text = "0";
            this.LblSpieler1Punkte.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblSpieler2Punkte
            // 
            this.LblSpieler2Punkte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblSpieler2Punkte.Location = new System.Drawing.Point(402, 31);
            this.LblSpieler2Punkte.Name = "LblSpieler2Punkte";
            this.LblSpieler2Punkte.Size = new System.Drawing.Size(66, 31);
            this.LblSpieler2Punkte.TabIndex = 17;
            this.LblSpieler2Punkte.Text = "0";
            this.LblSpieler2Punkte.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 263);
            this.Controls.Add(this.LblSpieler2Punkte);
            this.Controls.Add(this.LblSpieler1Punkte);
            this.Controls.Add(this.BtnSpielStarten);
            this.Controls.Add(this.CoBoxSpieler2);
            this.Controls.Add(this.CoBoxSpieler1);
            this.Controls.Add(this.MtxtBoxSpieler2);
            this.Controls.Add(this.MtxtBoxSpieler1);
            this.Controls.Add(this.LblSpieler2);
            this.Controls.Add(this.LblSpieler1);
            this.Controls.Add(this.Btn2x2);
            this.Controls.Add(this.Btn2x1);
            this.Controls.Add(this.Btn2x0);
            this.Controls.Add(this.Btn1x2);
            this.Controls.Add(this.Btn1x1);
            this.Controls.Add(this.Btn1x0);
            this.Controls.Add(this.Btn0x2);
            this.Controls.Add(this.Btn0x1);
            this.Controls.Add(this.Btn0x0);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn0x0;
        private System.Windows.Forms.Button Btn0x1;
        private System.Windows.Forms.Button Btn0x2;
        private System.Windows.Forms.Button Btn1x0;
        private System.Windows.Forms.Button Btn1x1;
        private System.Windows.Forms.Button Btn1x2;
        private System.Windows.Forms.Button Btn2x0;
        private System.Windows.Forms.Button Btn2x1;
        private System.Windows.Forms.Button Btn2x2;
        private System.Windows.Forms.Label LblSpieler1;
        private System.Windows.Forms.Label LblSpieler2;
        private System.Windows.Forms.MaskedTextBox MtxtBoxSpieler1;
        private System.Windows.Forms.MaskedTextBox MtxtBoxSpieler2;
        private System.Windows.Forms.ComboBox CoBoxSpieler1;
        private System.Windows.Forms.ComboBox CoBoxSpieler2;
        private System.Windows.Forms.Button BtnSpielStarten;
        private System.Windows.Forms.Label LblSpieler1Punkte;
        private System.Windows.Forms.Label LblSpieler2Punkte;
    }
}

