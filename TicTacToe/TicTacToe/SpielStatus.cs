using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    //Klasse um den Aktuellen Status des Spiels zu repräsentieren
    class SpielStatus
    {

        //Repräsentation des Spielfeldes
        private int[,] feld = new int[3, 3];

        //Gibt an, ob der Zug gültig war
        private bool valide = true;

        //Flag zum Markieren, ob Spieler 1 am Zug ist
        private bool spieler1Zug = true;

        //Flag zum Markieren, ob eine KI am Zug ist
        private bool kiZug;

        //Flag zum Markieren eines Unedntschieden
        private bool unentschieden = false;

        //Zähler für die Züge die gemacht wurden, dient zur Feststellung eines Unentschieden
        private int zuege = 0;

        //Sieg Felder
        private Koordinate[] siegFelder;

        //Konstruktor
        public SpielStatus(bool kiZuerst)
        {
            kiZug = kiZuerst;
        }

        //Getter für das Spielfeld
        public int[,] GetFeld()
        {
            return feld;
        }
        //Getter für die valide Flag
        public bool GetValide()
        {
            return valide;
        }
        //Getter für die Spieler1 Flag
        public bool GetSpieler1Zug()
        {
            return spieler1Zug;
        }
        //Getter für die KIZug Flag
        public bool GetKiZug()
        {
            return kiZug;
        }
        //Getter für siegFelder Array
        public Koordinate[] GetSiegFelder()
        {
            return siegFelder;
        }
        //Getter für die Unentschieden Flag
        public bool GetUnentschieden()
        {
            return unentschieden;
        }

        //Setter für die valide Flag
        public void SetValide(bool valide)
        {
            this.valide = valide;
        }
        //Setter für die siegFelder
        public void SetSiegFelder(Koordinate[] siegFelder)
        {
            this.siegFelder = siegFelder;
        }
        //Setter für die Unentschieden Flag
        public void SetUnentschieden(bool unentschieden)
        {
            this.unentschieden = unentschieden;
        }

        //Setzt den übergebenen Spieler an die angegebene Position
        public void Setzte(Koordinate k, bool spieler1)
        {
            if (spieler1)
            {
                feld[k.GetX(), k.GetY()] = 1;
            }
            else
            {
                feld[k.GetX(), k.GetY()] = 2;
            }
        }
        /*Negiert den Wert der Spieler1Zug Flag und erhöht den Wert des Zug Zählers um 1.
         * Im Falle eines vollen Spielfeldes wird die Unentschieden Flag auf true gesetzt */
        public void ZugBeenden()
        {
            spieler1Zug = !spieler1Zug;
            zuege++;
            if (zuege>=9)
            {
                unentschieden = true;
            }
        }
    }
}
