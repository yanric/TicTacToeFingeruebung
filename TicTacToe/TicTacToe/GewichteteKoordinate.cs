using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    //Koordinate für die Schwere KI, die neben der Positionsangabe auch eine Bewertung des Zuges beinhaltet
    class GewichteteKoordinate
    {
        private Koordinate koordinate;

        private int bewertung;

        public GewichteteKoordinate(Koordinate k)
        {
            koordinate = k;
        }

        public Koordinate GetKoordinate()
        {
            return koordinate;
        }
        public void SetKoordinate(Koordinate k)
        {
            koordinate = k;
        }

        public int GetBewertung()
        {
            return bewertung;
        }

        public void SetBewertung(int b)
        {
            bewertung = b;
        }
    }
}
