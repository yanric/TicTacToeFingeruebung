using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    /// <summary>
    /// Hilfsklasse, die von der schweren KI benötigt wird, um Züge zu simulieren.
    /// </summary>
    class KISpielbrett
    {
        /// <summary>
        /// Array, welches das Spielfeld repräsentiert.
        /// </summary>
        private int[,] brett;

        /// <summary>
        /// Liste aller Leeren Felder auf dem Brett.
        /// </summary>
        private List<GewichteteKoordinate> leereFelder;

        /// <summary>
        /// Sieger dieses Brettes.
        /// </summary>
        private int sieger;

        /// <summary>
        /// Konstruktor. Erzeugt eine eigene Kopie des übergebenen Arrays, um darauf das Spiel zu simulieren.
        /// </summary>
        /// <param name="brett">Array, aus dem das Spielbrett erzeugt werden soll.</param>
        public KISpielbrett(int [,] brett)
        {
            this.brett = new int[3, 3];
            this.brett = (int[,])brett.Clone();
            BerechneLeereFelder();
        }

        /// <summary>
        /// Getter für die Liste der leeren Felder auf dem Spielfeld.
        /// </summary>
        /// <returns>Liste der leeren Felder.</returns>
        public List<GewichteteKoordinate> GetLeereFelder()
        {
            return leereFelder;
        }
        /// <summary>
        /// Macht an der übergebenen Koordinate den Zug für den übergebenen Spieler.
        /// </summary>
        /// <param name="k">Koordinate für den Zug.</param>
        /// <param name="spielerNummer">Nummer des Spielers.</param>
        public void MacheZug(GewichteteKoordinate k, int spielerNummer)
        {
            brett[k.GetKoordinate().GetX(), k.GetKoordinate().GetY()] = spielerNummer;
            BerechneLeereFelder();
            sieger = SiegerTesten();
        }

        /// <summary>
        /// Hilfsmethode welche nach dem Erzeugen des Spielbrettes und dem machen eines Zuges die restlichen leeren Felder berechnet.
        /// </summary>
        private void BerechneLeereFelder()
        {
            leereFelder = new List<GewichteteKoordinate>();
            for (int i = 0; i < brett.GetLength(0); i++)
            {
                for (int j = 0; j < brett.GetLength(1); j++)
                {
                    if (brett[i, j] == 0)
                    {
                        leereFelder.Add(new GewichteteKoordinate(new Koordinate(i, j)));
                    }
                }
            }
        }
        /// <summary>
        /// Getter für den Sieger dieses Brettes.
        /// </summary>
        /// <returns>1/2 falls Spieler 1/2 gewonnen hat, ansonsten 0.</returns>
        public int GetSieger()
        {
            return sieger;
        }

        /// <summary>
        /// Erzeugt eine Kopie des aktuellen Status des Spielbrettes.
        /// </summary>
        /// <returns>Kopie des Spielbrettes.</returns>
        public KISpielbrett Kopie()
        {
            return new KISpielbrett(brett);
        }
        /// <summary>
        /// Testet, ob irgendein Spieler mit dem aktuellen Brett gewonnen hat. Im Falle eines Sieges wird die entsprechende Nummer des Spielers zurückgegeben.
        /// </summary>
        /// <returns>1/2 falls Spieler 1/2 gewonnen hat, ansonsten 0.</returns>
        private int SiegerTesten()
        {
            for (int i = 0; i < brett.GetLength(0); i++)
            {
                //Reihen testen
                if (brett[i,0]!=0)
                {
                    int testWert = brett[i, 0];
                    if (new[] { brett[i, 0], brett[i, 1], brett[i, 2] }.All(x => x == testWert))
                    {
                        return testWert;
                    }
                }
                //Spalten testen
                if (brett[0,i]!=0)
                {
                    int testWert =brett[0, i];
                    if (new[] { brett[0, i], brett[1, i], brett[2, i] }.All(x => x == testWert))
                    {
                        return testWert;
                    }
                }
            }
            //Erste Diagonale testen
            if (brett[0,0]!=0)
            {
                int testWert = brett[0, 0];
                if (new[] { brett[0, 0], brett[1, 1], brett[2, 2] }.All(x => x == testWert))
                {
                    return testWert;
                }
            }
            //Zweite Diagonale testen
            if (brett[0,2]!=0)
            {
                int testWert = brett[0, 2];
                if (new[] { brett[0, 2], brett[1, 1], brett[2, 0] }.All(x => x == testWert))
                {
                    return testWert;
                }
            }
            return 0;
        }
    }
}
