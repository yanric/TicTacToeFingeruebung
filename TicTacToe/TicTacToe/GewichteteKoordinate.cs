using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    /// <summary>
    /// Koordinate für die schwere KI, die neben der Positionsangabe auch eine Bewertung des Zuges beinhaltet.
    /// </summary>
    class GewichteteKoordinate
    {
        /// <summary>
        /// Koordinaten Objekt mit der Positionsangabe.
        /// </summary>
        private Koordinate koordinate;

        /// <summary>
        /// Bewertung des Zuges passend zur Koordinate.
        /// </summary>
        private int bewertung;

        /// <summary>
        /// Konstruktor. Erzeugt aus der übergebenen Koordinate eine mit gewichtbare.
        /// </summary>
        /// <param name="k">Koordinate, die gewichtbar sein soll.</param>
        public GewichteteKoordinate(Koordinate k)
        {
            koordinate = k;
        }
        /// <summary>
        /// Getter für die Koordinate.
        /// </summary>
        /// <returns>Koordinate.</returns>
        public Koordinate GetKoordinate()
        {
            return koordinate;
        }
        /// <summary>
        /// Getter für die Bewertung der Koordinate.
        /// </summary>
        /// <returns>Bewertung.</returns>
        public int GetBewertung()
        {
            return bewertung;
        }
        /// <summary>
        /// Setter für die Bewertung der Koordinate.
        /// </summary>
        /// <param name="b">Neue Bewertung der Koordinate</param>
        public void SetBewertung(int b)
        {
            bewertung = b;
        }
    }
}
