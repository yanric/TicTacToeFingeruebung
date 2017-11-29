using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    //Verwaltet das Spiel
    class SpielLogik
    {
        //Spielmodi die für die Spieler gewählt werden können
        public enum Spielmodi{Mensch,KILeicht,KISchwer};

        //Spielstatus Objekt
        private SpielStatus status;

        //initialisiert ein neues Spiel abhängig der übergebenen Modi
        public SpielStatus InitSpiel(Spielmodi spieler1, Spielmodi spieler2)
        {
            if (spieler1==Spielmodi.KILeicht || spieler1==Spielmodi.KISchwer)
            {
                status = new SpielStatus(true);
            }
            else
            {
                status = new SpielStatus(false);
            }
            return status;
        }

        //Methode die im Falle eines Zuges einer KI aufgerufen wird
        public SpielStatus KiZug()
        {
            //todo: Übergabe prüfen, Sieg feststellen, Spieler aktualisieren, unentschieden feststellen
            return status;
        }

        //Methode die im Falle eines Zuges eines Menschen aufgerufen wird
        public SpielStatus MenschZug(Koordinate k)
        {
            //todo: unentschieden feststellen
            status.SetValide(Validiere(k));
            if (status.GetValide())
            {
                status.Setzte(k, status.GetSpieler1Zug());
                status.SetSiegFelder(SiegTesten());
                status.ZugBeenden();
            }
            return status;
        }

        //Prüft ob der übergebe Zug gültig ist
        private bool Validiere (Koordinate k)
        {
            if (status.GetFeld()[k.GetX(),k.GetY()]==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Koordinate[] SiegTesten()
        {
            int[,] feld = status.GetFeld();

            //Zahl des Spielers im Spielfeld Array der überprüft werden soll
            int spielerZahl;

            //Array mit den Feldern mittels denen Gewonnen wurde
            Koordinate[] siegFelder = null;

            //Identifizieren auf Welche Zahl im Feld geprüft werden muss
            if (status.GetSpieler1Zug())
            {
                spielerZahl = 1;
            }
            else
            {
                spielerZahl = 2;
            }
            //Waagerecht und Senkrecht testen
            for (int i = 0; i < feld.GetLength(0); i++)
            {
                //Waagerecht testen
                if (siegFelder==null)
                {
                    siegFelder = TesteFelder(feld, spielerZahl, new Koordinate(i, 0), new Koordinate(i, 1), new Koordinate(i, 2));
                }
                //Senkrecht testen
                if (siegFelder==null)
                {
                    siegFelder = TesteFelder(feld, spielerZahl, new Koordinate(0, i), new Koordinate(1, i), new Koordinate(2, i));
                }
            }

            //Diagonalen testen
            if (siegFelder==null)
            {
                siegFelder = TesteFelder(feld, spielerZahl, new Koordinate(0, 0), new Koordinate(1, 1), new Koordinate(2, 2));
            }
            if (siegFelder==null)
            {
                siegFelder = TesteFelder(feld, spielerZahl, new Koordinate(0, 2), new Koordinate(1, 1), new Koordinate(2, 0));
            }
            return siegFelder;
        }
        //Testet ob im übergebenen Spielfeld die übergebenen Koordinaten, die Nummer des übergebenen Spielers besitzen
        private Koordinate[] TesteFelder(int[,] feld,int spielerZahl,Koordinate k1, Koordinate k2, Koordinate k3)
        {
            if (new[] { feld[k1.GetX(),k1.GetY()], feld[k2.GetX(),k2.GetY()], feld[k3.GetX(),k3.GetY()] }.All(x => x == spielerZahl))
            {
                Koordinate[] siegFelder = new Koordinate[] { k1, k2, k3 };
                return siegFelder; 
            }
            else
            {
                return null;
            }
        }
    }
}
