using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Mitteilung : Form
    {
        public Mitteilung(string ergebnis)
        {
            InitializeComponent();
            LblNachricht.Text = ergebnis + ". Spiel fortsetzen?";
        }

        private void BtnBeenden_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void BtnFortsetzen_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
    }
}
