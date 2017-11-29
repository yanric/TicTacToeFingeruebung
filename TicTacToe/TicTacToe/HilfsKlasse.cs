using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    static class HilfsKlasse
    {
        //Klasse mit kleineren Hilfsmethoden
        public static SpielLogik.Spielmodi IndexZuSpielmodus(int index)
        {
            //Methode um einen Index aus einer der ComboBoxen in einen Spielmodus zu überführen
            SpielLogik.Spielmodi modus=SpielLogik.Spielmodi.Mensch;
            switch (index)
            {
                case 1:
                    modus = SpielLogik.Spielmodi.KILeicht;
                    break;
                case 2:
                    modus = SpielLogik.Spielmodi.KISchwer;
                    break;
                default:
                    break;
            }
            return modus;
        }
    }
}
