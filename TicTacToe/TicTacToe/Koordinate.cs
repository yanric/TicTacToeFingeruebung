using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    //Koordinatenobjekt. Dient zur Positionsangabe innerhalb des Spielfeld Arrays
    class Koordinate
    {
        private int x;
        private int y;

        public Koordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int GetX()
        {
            return x;
        }
        public int GetY()
        {
            return y;
        }
    }
}
