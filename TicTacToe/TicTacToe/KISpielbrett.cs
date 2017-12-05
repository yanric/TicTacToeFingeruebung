using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    //Hilfsklasse die von der Schweren KI benötigt wird, um Züge zu simulieren.
    class KISpielbrett
    {
        private int[,] brett;

        //Liste aller Leeren Felder auf dem Brett
        private List<GewichteteKoordinate> leereFelder;

        //Sieger dieses Brettes
        private int sieger;

        public KISpielbrett(int [,] brett)
        {
            this.brett = new int[3, 3];
            this.brett = (int[,])brett.Clone();
            BerechneLeereFelder();
        }

        public List<GewichteteKoordinate> GetLeereFelder()
        {
            return leereFelder;
        }

        public void MacheZug(GewichteteKoordinate k, int spielerNummer)
        {
            brett[k.GetKoordinate().GetX(), k.GetKoordinate().GetY()] = spielerNummer;
            BerechneLeereFelder();
            sieger = SiegerTesten();
        }

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

        public int[,] GetBrett()
        {
            return brett;
        }
        public int GetSieger()
        {
            return sieger;
        }

        public KISpielbrett Kopie()
        {
            return new KISpielbrett(brett);
        }
        //Testet ob irgendein Spieler mit dem aktuellen Brett gewonnen hat. Falle eines Sieges wird die entsprechende Nummer des Spielers zurückgegeben
        private int SiegerTesten()
        {
            for (int i = 0; i < brett.GetLength(0); i++)
            {
                if (brett[i,0]!=0)
                {
                    int testWert = brett[i, 0];
                    if (new[] { brett[i, 0], brett[i, 1], brett[i, 2] }.All(x => x == testWert))
                    {
                        return testWert;
                    }
                }
                if (brett[0,i]!=0)
                {
                    int testWert =brett[0, i];
                    if (new[] { brett[0, i], brett[1, i], brett[2, i] }.All(x => x == testWert))
                    {
                        return testWert;
                    }
                }
            }
            if (brett[0,0]!=0)
            {
                int testWert = brett[0, 0];
                if (new[] { brett[0, 0], brett[1, 1], brett[2, 2] }.All(x => x == testWert))
                {
                    return testWert;
                }
            }
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
