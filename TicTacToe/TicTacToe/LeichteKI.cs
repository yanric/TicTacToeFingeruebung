using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TicTacToe
{
    /// <summary>
    /// Zufällig spielende leichte KI.
    /// </summary>
    class LeichteKI
    {
        /// <summary>
        /// Fordert einen zufälligen Zug für das übergebene Spielfeld an.
        /// </summary>
        /// <param name="feld">Array für das ein Zug berechnet werden soll</param>
        /// <returns>Zufällige Koordinate.</returns>
        public Koordinate GetZug(int[,] feld)
        {
            List<Koordinate> liste = new List<Koordinate>();

            //Potenzielle (leere) Felder identifizieren.
            for (int i = 0; i < feld.GetLength(0); i++)
            {
                for (int j = 0; j < feld.GetLength(1); j++)
                {
                    if (feld[i,j]==0)
                    {
                        liste.Add(new Koordinate(i, j));
                    }
                }
            }

            //Zufällig eines der möglichen Felder auswählen.
            Random r = new Random();
            return liste[r.Next(0, liste.Count)];
        }
    }
}
