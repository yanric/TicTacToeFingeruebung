namespace TicTacToe
{
    partial class Mitteilung
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
            this.BtnFortsetzen = new System.Windows.Forms.Button();
            this.BtnBeenden = new System.Windows.Forms.Button();
            this.LblNachricht = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnFortsetzen
            // 
            this.BtnFortsetzen.Location = new System.Drawing.Point(171, 82);
            this.BtnFortsetzen.Name = "BtnFortsetzen";
            this.BtnFortsetzen.Size = new System.Drawing.Size(89, 23);
            this.BtnFortsetzen.TabIndex = 0;
            this.BtnFortsetzen.Text = "Fortsetzen";
            this.BtnFortsetzen.UseVisualStyleBackColor = true;
            this.BtnFortsetzen.Click += new System.EventHandler(this.BtnFortsetzen_Click);
            // 
            // BtnBeenden
            // 
            this.BtnBeenden.Location = new System.Drawing.Point(12, 82);
            this.BtnBeenden.Name = "BtnBeenden";
            this.BtnBeenden.Size = new System.Drawing.Size(89, 23);
            this.BtnBeenden.TabIndex = 1;
            this.BtnBeenden.Text = "Beenden";
            this.BtnBeenden.UseVisualStyleBackColor = true;
            this.BtnBeenden.Click += new System.EventHandler(this.BtnBeenden_Click);
            // 
            // LblNachricht
            // 
            this.LblNachricht.Location = new System.Drawing.Point(12, 22);
            this.LblNachricht.Name = "LblNachricht";
            this.LblNachricht.Size = new System.Drawing.Size(248, 23);
            this.LblNachricht.TabIndex = 2;
            this.LblNachricht.Text = "label1";
            this.LblNachricht.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Mitteilung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 114);
            this.Controls.Add(this.LblNachricht);
            this.Controls.Add(this.BtnBeenden);
            this.Controls.Add(this.BtnFortsetzen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Mitteilung";
            this.Text = "Mitteilung";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnFortsetzen;
        private System.Windows.Forms.Button BtnBeenden;
        private System.Windows.Forms.Label LblNachricht;
    }
}