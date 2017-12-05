using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    /// <summary>
    /// Dient zur Positionsangabe innerhalb des Spielfeld Arrays.
    /// </summary>
    class Koordinate
    {
        /// <summary>
        /// Erster Wert.
        /// </summary>
        private int x;
        /// <summary>
        /// Zweiter Wert.
        /// </summary>
        private int y;

        /// <summary>
        /// Konstruktor. Erzeugt aus den übergebenen Werten eine Koordinate.
        /// </summary>
        /// <param name="x">Erster Wert.</param>
        /// <param name="y">Zweiter Wert.</param>
        public Koordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        /// <summary>
        /// Getter für den ersten Wert.
        /// </summary>
        /// <returns></returns>
        public int GetX()
        {
            return x;
        }
        /// <summary>
        /// Getter für den zweiten Wert.
        /// </summary>
        /// <returns></returns>
        public int GetY()
        {
            return y;
        }
    }
}
