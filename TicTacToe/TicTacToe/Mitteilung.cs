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
    /// <summary>
    /// Mitteilungsfenster, welches am Ende einer Partie aufgerufen wird, um zu erfragen, wie es weiter gehen soll.
    /// </summary>
    public partial class Mitteilung : Form
    {
        /// <summary>
        /// Konstruktor. Ruft ein neues Fenster mit dem Ergebnis als Nachricht auf.
        /// </summary>
        /// <param name="ergebnis">Ergebnis der Partie (Sieg oder Unentschieden).</param>
        public Mitteilung(string ergebnis)
        {
            InitializeComponent();
            LblNachricht.Text = ergebnis + ". Spiel fortsetzen?";
        }

        /// <summary>
        /// Auswahloption für das Beenden des Spiels.
        /// </summary>
        /// <param name="sender">Beenden Button.</param>
        /// <param name="e">Event Informationen.</param>
        private void BtnBeenden_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            Close();
        }
        /// <summary>
        /// Auswahloption für das Fortsetzen des Spiels.
        /// </summary>
        /// <param name="sender">Fortsetzen Button</param>
        /// <param name="e">Event Informationen.</param>
        private void BtnFortsetzen_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }
    }
}
