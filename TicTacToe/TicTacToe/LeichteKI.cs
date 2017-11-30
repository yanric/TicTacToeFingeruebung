using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TicTacToe
{
    class LeichteKI
    {
        //Fordert einen zufälligen Zug für das Übergebene Spielfeld an
        public Koordinate GetZug(int[,] feld)
        {
            List<Koordinate> liste = new List<Koordinate>();
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
            Random r = new Random();
            return liste[r.Next(0, liste.Count)];
        }
    }
}
