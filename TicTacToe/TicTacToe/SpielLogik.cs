using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TicTacToe
{
    /// <summary>
    /// Verwaltet das Spiel.
    /// </summary>
    class SpielLogik
    {
        /// <summary>
        /// Spielmodi, die für die Spieler gewählt werden können.
        /// </summary>
        public enum Spielmodi{Mensch,KILeicht,KISchwer};

        /// <summary>
        /// SpielStatus Objekt, mit dem das Spiel verwaltet wird und welches an die Oberfläche zurückgegeben wird.
        /// </summary>
        private SpielStatus status;

        /// <summary>
        /// Spielmodi für die jeweiligen Spieler.
        /// </summary>
        Spielmodi spieler1;
        Spielmodi spieler2;

        /// <summary>
        /// Initialisiert ein neues Spiel abhängig der übergebenen Modi.
        /// </summary>
        /// <param name="spieler1">Gewählter Spielmodus für Spieler 1.</param>
        /// <param name="spieler2">Gewählter Spielmodus für Spieler 2.</param>
        /// <returns>SpielStatus Objekt, für das neue Spiel.</returns>
        public SpielStatus InitSpiel(Spielmodi spieler1, Spielmodi spieler2)
        {
            this.spieler1 = spieler1;
            this.spieler2 = spieler2;
            status = new SpielStatus(spieler1, spieler2);
            return status;
        }

        /// <summary>
        /// Methode, die im Falle eines Zuges einer KI von der Oberfläche aufgerufen wird.
        /// </summary>
        /// <returns>SpielStatus Objekt, nach dem Zug der KI.</returns>
        public SpielStatus KiZug()
        {
            //Da die leichte KI keine Perspektive braucht, muss bei ihr keine Unterscheidung gemacht werden, als welcher Spieler sie spielt.
            if (spieler1==Spielmodi.KILeicht||spieler2==Spielmodi.KILeicht)
            {
                LeichteKI ki = new LeichteKI();
                status.Setzte(ki.GetZug(status.GetFeld()), status.GetSpieler1Zug());
                status.SetSiegFelder(SiegTesten());
                status.ZugBeenden();
            }

            //Bei der schweren KI muss die Rolle abgefragt werden, damit die KI aus der richtigen Perspektive spielt.
            else
            {
                SchwereKI ki = new SchwereKI();
                if (status.GetSpieler1Zug() && spieler1 == Spielmodi.KISchwer)
                {
                    status.Setzte(ki.GetZug(status.GetFeld(), 1), status.GetSpieler1Zug());
                }
                else if (!status.GetSpieler1Zug() && spieler2 == Spielmodi.KISchwer)
                {
                    status.Setzte(ki.GetZug(status.GetFeld(), 2), status.GetSpieler1Zug());
                }
                status.SetSiegFelder(SiegTesten());
                status.ZugBeenden();
            }
            return status;
        }

        /// <summary>
        /// Methode, die im Falle eines Zuges eines Menschen von der Oberfläche aufgerufen wird.
        /// </summary>
        /// <param name="k">Koordinate mit der Angabe, wo der Zug gemacht werden soll.</param>
        /// <returns>SpielStatus Objekt nach dem Zug.</returns>
        public SpielStatus MenschZug(int x, int y)
        {
            Koordinate k = new Koordinate(x, y);
            status.SetValide(Validiere(k));
            if (status.GetValide())
            {
                status.Setzte(k, status.GetSpieler1Zug());
                status.SetSiegFelder(SiegTesten());
                status.ZugBeenden();
            }
            return status;
        }

        /// <summary>
        /// Hilfsmethode von MenschZug(). Prüft, ob die übergebene Koordinate ein gültiger Zug ist.
        /// </summary>
        /// <param name="k">Zu prüfende Koordinate.</param>
        /// <returns>True, wenn die Koordinate ein gültiger Zug ist, ansonsten false.</returns>
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

        /// <summary>
        /// Testet ob es für das aktuelle SpielStatus Objekt einen Sieger gibt.
        /// </summary>
        /// <returns>Ein Array mit den Feldern, die einen Sieg darstellen oder null.</returns>
        private Koordinate[] SiegTesten()
        {
            int[,] feld = status.GetFeld();

            //Zahl des Spielers, der im Spielfeld Array überprüft werden soll
            int spielerZahl;

            //Array mit den Feldern mittels denen gewonnen wurde
            Koordinate[] siegFelder = null;

            //Identifizieren, auf welche Zahl im Feld geprüft werden muss, da immer nur der Spieler geprüft werden muss, der eben einen Zug gemacht hat.
            if (status.GetSpieler1Zug())
            {
                spielerZahl = 1;
            }
            else
            {
                spielerZahl = 2;
            }
            //Waagerecht und senkrecht testen
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
        /// <summary>
        /// Hilfsmethode von SiegTesten(). Testet, ob im übergebenen Spielfeld die übergebenen Koordinaten die Nummer des übergebenen Spielers besitzen.
        /// </summary>
        /// <param name="feld">Zu prüfendes Spielfeld Array</param>
        /// <param name="spielerZahl">Zu prüfende Zahl des Spielers</param>
        /// <param name="k1">Koordinate des ersten Feldes</param>
        /// <param name="k2">Koordinate des zweiten Feldes</param>
        /// <param name="k3">Koordinate des dritten Feldes</param>
        /// <returns></returns>
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
