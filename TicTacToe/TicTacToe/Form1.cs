using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    /// <summary>
    /// Zentrale Oberfläche.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// String Array mit den verschiedenen Spielmodi, die für jeden Spieler gewählt werden können.
        /// </summary>
        private string[] spielmodi = { "Mensch", "KI Leicht", "KI Schwer" };

        /// <summary>
        /// Aktueller Spielmodus von Spieler 1.
        /// </summary>
        SpielLogik.Spielmodi spieler1Modus;

        /// <summary>
        /// Aktueller Spielmodus von Spieler 2.
        /// </summary>
        SpielLogik.Spielmodi spieler2Modus;

        /// <summary>
        /// Symbol von Spieler 1 auf dem Spielfeld.
        /// </summary>
        private string spieler1Symbol;

        /// <summary>
        /// Symbol von Spieler 2 auf dem Spielfeld.
        /// </summary>
        private string spieler2Symbol;

        /// <summary>
        /// SpielLogik Objekt, das von dieser Oberfläche verwendet wird.
        /// </summary>
        private SpielLogik sl = new SpielLogik();

        /// <summary>
        /// Array mit den Buttons, die das Spielfeld bilden, um diese über Indizes anzusprechen.
        /// </summary>
        private Button[,] buttons;

        /// <summary>
        /// SpielStatus Objekt, das von der SpielLogik zurückgegeben und angezeigt wird.
        /// </summary>
        private SpielStatus status;

        /// <summary>
        /// Farbenobjekte um den aktiven Spieler und die Sieg Felder zu markieren.
        /// </summary>
        private Color markiert = Color.FromArgb(0, 204, 102);
        private Color nichtMarkiert = SystemColors.Control;

        /// <summary>
        /// Repräsentation der Antwortmöglichkeiten des Dialogs am Ende einer Partie sowie für die Situation, dass die Partie noch läuft.
        /// </summary>
        private enum AnzeigeErgebnis {Fortsetzen, Beenden, Unbestimmt};

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Vorbereiten der ComboBoxen
            CoBoxSpieler1.Items.AddRange(spielmodi);
            CoBoxSpieler2.Items.AddRange(spielmodi);
            CoBoxSpieler1.SelectedIndex = 0;
            CoBoxSpieler2.SelectedIndex = 0;

            //Button Array anlegen
            buttons=new [,]{ { Btn0x0, Btn0x1, Btn0x2 }, { Btn1x0, Btn1x1, Btn1x2 }, { Btn2x0, Btn2x1, Btn2x2 } };

        }

        /// <summary>
        /// Methode, die die Oberflächenelemente gemäß des aktuellen SpielStatus Objekts anpasst.
        /// </summary>
        /// <returns>Gibt an, ob die Partie noch läuft, oder wie nach dem Ende einer Partie weiter verfahren werden soll.</returns>
        private AnzeigeErgebnis Anzeigen()
        {
            SpielfeldAktualisieren();
            SpielerAktualisieren();

            if (status.GetSiegFelder()!=null)
            {
                return SiegerAktualisieren();        
            }

            if (status.GetUnentschieden()&& status.GetSiegFelder()==null)
            {
                return Unentschieden();
            }
            return AnzeigeErgebnis.Unbestimmt;
        }

        /// <summary>
        /// Startet eine neue Partie.
        /// </summary>
        private void SpielStarten()
        {
            status = sl.InitSpiel(spieler1Modus, spieler2Modus);

            for (int i = 0; i < buttons.GetLength(0); i++)
            {
                for (int j = 0; j < buttons.GetLength(1); j++)
                {
                    buttons[i, j].BackColor = nichtMarkiert;
                    buttons[i, j].Enabled = true;
                }
            }
            Anzeigen();
        }

        /// <summary>
        /// Startet ein neues Spiel gemäß der Informationen bezüglich Spielerzeichen und Spielmodi.
        /// </summary>
        /// <param name="sender">Objekt welches das Event auslöst.</param>
        /// <param name="e">Informationen zum Event.</param>
        private void BtnSpielStarten_Click(object sender, EventArgs e)
        {
            //Punkte Label zurücksetzen
            LblSpieler1Punkte.Text = "0";
            LblSpieler2Punkte.Text = "0";

            //Spielersymbole aus den MaskedTextBoxen entnehmen
            spieler1Symbol = MtxtBoxSpieler1.Text;
            spieler2Symbol = MtxtBoxSpieler2.Text;

            //Spielmodi aus den ComboBoxen entnehmen
            spieler1Modus = IndexZuSpielmodus(CoBoxSpieler1.SelectedIndex);
            spieler2Modus = IndexZuSpielmodus(CoBoxSpieler2.SelectedIndex);

            //Wenn ein Spieler kein Symbol hat wird das Spiel nicht gestartet
            if (String.IsNullOrWhiteSpace(spieler1Symbol) || String.IsNullOrWhiteSpace(spieler2Symbol))
            {
                MessageBox.Show("Ein Spieler hat kein Symbol angegeben.");
            }
            else
            {
                SpielStarten();
                KIZugAbarbeiten(true);
            }
            
        }

        /// <summary>
        /// Methode, die von allen Buttons die das Spielfeld bilden aufgerufen wird. Identifiziert den Button und macht den entsprechenden Zug.
        /// </summary>
        /// <param name="sender">Objekt welches das Event auslöst.</param>
        /// <param name="e">Informationen zum Event.</param>
        private void Spielfeld_Click(object sender, EventArgs e)
        {
            //Wenn aktuell eine KI dran ist, wird der Klick ignoriert
            if (status.GetKiZug()==false)
            {
                for (int i = 0; i < buttons.GetLength(0); i++)
                {
                    for (int j = 0; j < buttons.GetLength(1); j++)
                    {
                        if (sender == buttons[i, j])
                        {
                            status = sl.MenschZug(i,j);
                        }
                    }
                }
                //Ergebnis des Zuges anzeigen, Ergebnis der Anzeige verarbeiten, gegebenenfalls eine KI ihren Zug machen lassen
                KIZugAbarbeiten(AnzeigeErgebnisBearbeiten(Anzeigen()));
            }
            
        }
        /// <summary>
        /// Methode wird aufgerufen, damit die KI ihren Zug machen kann.
        /// </summary>
        /// <param name="erlaubt">Flag, ob ein KI-Zug noch nötig ist.</param>
        private void KIZugAbarbeiten(bool erlaubt)
        {
            //Dies tritt ein, wenn eine KI dran ist und läuft weiter, wenn der andere Spieler ebenfalls eine KI ist und das Spiel nicht beendet wurde.
            while (status.GetKiZug() && erlaubt)
            {
                status = sl.KiZug();
                AnzeigeErgebnis erg= Anzeigen();
                erlaubt= AnzeigeErgebnisBearbeiten(erg);
            }
        }
        /// <summary>
        /// Öffnet im Falle eines Sieges oder Unentschieden einen Dialog, in dem der Spieler auswählen kann, ob das Spiel fortgesetzt oder beendet werden soll.
        /// </summary>
        /// <param name="nachricht">Nachricht, die in der Mitteilung angezeigt werden soll (Sieg Spieler 1 / Spieler 2, Unentschieden).</param>
        /// <returns>Ergebnis, wie mit der Partie weiter verfahren werden soll.</returns>
        private AnzeigeErgebnis MitteilungAnzeigen(string nachricht)
        {
            Mitteilung mitteilung = new Mitteilung(nachricht);
            if (mitteilung.ShowDialog()==DialogResult.Yes)
            {
                return AnzeigeErgebnis.Fortsetzen;
            }
            else
            {
                return AnzeigeErgebnis.Beenden;
            }
        }

        /// <summary>
        /// Das Spielfeld abhängig von den Nummern im SpielStatus Objekt mit den Spielerzeichen versehen.
        /// </summary>
        private void SpielfeldAktualisieren()
        {
            for (int i = 0; i < buttons.GetLength(0); i++)
            {
                for (int j = 0; j < buttons.GetLength(1); j++)
                {
                    buttons[i, j].Text = "" + status.GetFeld()[i, j];
                    switch (status.GetFeld()[i, j])
                    {
                        case 0:
                            buttons[i, j].Text = "";
                            break;
                        case 1:
                            buttons[i, j].Text = spieler1Symbol;
                            break;
                        case 2:
                            buttons[i, j].Text = spieler2Symbol;
                            break;
                    }
                }
            }
        }
        /// <summary>
        /// Markiert, welcher Spieler am Zug ist. Hilfsmethode von Anzeigen().
        /// </summary>
        private void SpielerAktualisieren()
        {
            if (status.GetSpieler1Zug())
            {
                LblSpieler1.BackColor = markiert;
                LblSpieler2.BackColor = nichtMarkiert;
            }
            else
            {
                LblSpieler2.BackColor = markiert;
                LblSpieler1.BackColor = nichtMarkiert;
            }
        }
        /// <summary>
        /// Sieger Mitteilung anzeigen, Sieg Felder anzeigen, Punkte anpassen. Hilfsmethode von Anzeigen().
        /// </summary>
        /// <returns>Ergebnis des Mitteilung Fensters.</returns>
        private AnzeigeErgebnis SiegerAktualisieren()
        {
            //Sieg Felder markieren
            for (int i = 0; i < status.GetSiegFelder().Length; i++)
            {
                buttons[status.GetSiegFelder()[i].GetX(), status.GetSiegFelder()[i].GetY()].BackColor = markiert;
            }
            /*Punkte anpassen und Sieg Meldung anzeigen.
             * Muss negiert werden, da beim Beenden des Zuges die Flag umgeschaltet wurde*/
            if (!status.GetSpieler1Zug())
            {
                LblSpieler1Punkte.Text = Int32.Parse(LblSpieler1Punkte.Text) + 1 + "";
                return MitteilungAnzeigen("Sieg Spieler 1");
            }
            else
            {
                LblSpieler2Punkte.Text = Int32.Parse(LblSpieler2Punkte.Text) + 1 + "";
                return MitteilungAnzeigen("Sieg Spieler 2");
            }
        }
        /// <summary>
        /// Wird im Falle eines Unentschieden aufgerufen. Hilfsmethode von Anzeigen().
        /// </summary>
        /// <returns>Ergebnis des Mitteilung Fensters.</returns>
        private AnzeigeErgebnis Unentschieden()
        {
            AnzeigeErgebnis ergebnis = MitteilungAnzeigen("Unentschieden");
            return ergebnis;
        }
        /// <summary>
        /// Löst abhängig von AnzeigeErgebnis ein neues Spiel aus oder setzt das Aktuelle fort oder beendet es.
        /// </summary>
        /// <param name="erg">AnzeigeErgebnis Objekt der Mitteilung.</param>
        /// <returns>Flag die angibt, ob weiterhin KI Züge abgefragt werden sollen.</returns>
        private bool AnzeigeErgebnisBearbeiten(AnzeigeErgebnis erg)
        {
            if (erg == AnzeigeErgebnis.Fortsetzen)
            {
                SpielStarten();
                return true;
            }
            else if (erg==AnzeigeErgebnis.Beenden)
            {
                SpielBlockieren();
                return false;
            }
            return true;
        }
        /// <summary>
        /// Blockiert das Spielfeld, wird benötigt, wenn ein Spiel beendet werden soll.
        /// </summary>
        private void SpielBlockieren()
        {
            for (int i = 0; i < buttons.GetLength(0); i++)
            {
                for (int j = 0; j < buttons.GetLength(1); j++)
                {
                    buttons[i, j].Text = "";
                    buttons[i, j].BackColor = nichtMarkiert;
                    buttons[i, j].Enabled = false;
                }
            }
        }
        /// <summary>
        /// Methode um einen Index aus einer der ComboBoxen in einen Spielmodus zu überführen.
        /// </summary>
        /// <param name="index">Index der ComboBox.</param>
        /// <returns>Spielmodus passend zum Index.</returns>
        private static SpielLogik.Spielmodi IndexZuSpielmodus(int index)
        {
            SpielLogik.Spielmodi modus = SpielLogik.Spielmodi.Mensch;
            switch (index)
            {
                case 1:
                    modus = SpielLogik.Spielmodi.KILeicht;
                    break;
                case 2:
                    modus = SpielLogik.Spielmodi.KISchwer;
                    break;
            }
            return modus;
        }
    }
}
