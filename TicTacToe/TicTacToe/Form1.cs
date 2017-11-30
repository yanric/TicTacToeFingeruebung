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
    public partial class Form1 : Form
    {
        //Stringarray mit den verschiedenen Spielmodi die für jeden Spieler gewählt werden können
        private string[] spielmodi = { "Mensch", "KI Leicht", "KI Schwer" };

        //Aktueller Spielmodus von Spieler 1
        SpielLogik.Spielmodi spieler1Modus;

        //Aktueller Spielmodus von Spieler 2
        SpielLogik.Spielmodi spieler2Modus;

        //Symbol von Spieler 1 auf dem Spielfeld
        private string spieler1Symbol;

        //Symbol von Spieler 2 auf dem Spielfeld
        private string spieler2Symbol;

        //SpielLogik Objekt das von dieser Oberfläche verwendet wird
        private SpielLogik sl = new SpielLogik();

        //Array mit den Buttons die das Spielfeld bilden, um diese über Indizes anzusprechen
        private Button[,] buttons;

        //Spielstatus Objekt, das von der SpielLogik zurückgegeben und angezeigt wird
        private SpielStatus status;

        //Farbenobjekte um den aktiven Spieler und die Sieg Felder zu markieren
        private Color markiert = Color.FromArgb(0, 204, 102);
        private Color nichtMarkiert = SystemColors.Control;

        /*Repräsentation der Antwortmöglichkeiten des Dialogs am Ende einer Partie sowie für die Situation,
         * dass die Partie noch läuft*/
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

            //Buttonarray anlegen
            buttons=new [,]{ { Btn0x0, Btn0x1, Btn0x2 }, { Btn1x0, Btn1x1, Btn1x2 }, { Btn2x0, Btn2x1, Btn2x2 } };

        }

        //Methode die die Oberflächenelemente gemäß des aktuellen Spielstatus Objekts anpasst
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

        //Startet eine Partie
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

        //Startet ein neues Spiel gemäß der Informationen bezüglich Spielerzeichen und Spielmodi
        private void BtnSpielStarten_Click(object sender, EventArgs e)
        {
            //todo: prüfen ob die Spieler beide ein Symbol haben
            LblSpieler1Punkte.Text = "0";
            LblSpieler2Punkte.Text = "0";
            spieler1Symbol = MtxtBoxSpieler1.Text;
            spieler2Symbol = MtxtBoxSpieler2.Text;
            spieler1Modus = HilfsKlasse.IndexZuSpielmodus(CoBoxSpieler1.SelectedIndex);
            spieler2Modus = HilfsKlasse.IndexZuSpielmodus(CoBoxSpieler2.SelectedIndex);
            SpielStarten();
            KIZugAbarbeiten(true);
        }

        //Methode die von allen Buttons die das Spielfeld bilden aufgerufen wird
        private void Spielfeld_Click(object sender, EventArgs e)
        {
            if (status.GetKiZug()==false)
            {
                for (int i = 0; i < buttons.GetLength(0); i++)
                {
                    for (int j = 0; j < buttons.GetLength(1); j++)
                    {
                        if (sender == buttons[i, j])
                        {
                            status = sl.MenschZug(new Koordinate(i,j));
                        }
                    }
                }
                KIZugAbarbeiten(AnzeigeErgebnisBearbeiten(Anzeigen()));
            }
            
        }
        //Methode wird aufgerufen, damit die KI ihren Zug machen kann
        private void KIZugAbarbeiten(bool erlaubt)
        {
            /*dies tritt ein wenn eine KI drann ist und läuft weiter 
            *wenn der andere Spieler ebenfalls eine KI ist und das Spiel nicht beendet wurde*/
            while (status.GetKiZug() && erlaubt)
            {
                status = sl.KiZug();
                AnzeigeErgebnis erg= Anzeigen();
                erlaubt= AnzeigeErgebnisBearbeiten(erg);
            }
        }

        /*Öffnet im Falle eines Sieges oder Unentschieden einen Dialog in dem der Spieler auswählen kann,
         * ob das Spiel fortgesetzt oder beendet werden soll */
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

        //Das Spielfeld abhängig von den Nummern im Status Objekt mit den Spielerzeichen versehen
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
                        default:
                            break;
                    }
                }
            }
        }
        //Markiert welcher Spieler am Zug ist
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
        //Sieger anzeigen, Sieg Felder anzeigen, Punkte anpassen
        private AnzeigeErgebnis SiegerAktualisieren()
        {
            for (int i = 0; i < status.GetSiegFelder().Length; i++)
            {
                buttons[status.GetSiegFelder()[i].GetX(), status.GetSiegFelder()[i].GetY()].BackColor = markiert;
            }
            //Muss negiert werden, da beim Beenden des Zuges die Flag umgeschaltet wurde
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
        //Anzeigen eines Unentschieden
        private AnzeigeErgebnis Unentschieden()
        {
            AnzeigeErgebnis ergebnis = MitteilungAnzeigen("Unentschieden");
            return ergebnis;
        }
        //Löst abhängig von erg ein neues Spiel aus oder setzt das Aktuelle fort oder beendet es
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
        //Blockiert das Spielfeld, wird benötigt wenn ein Spiel beendet werden soll
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
    }
}
