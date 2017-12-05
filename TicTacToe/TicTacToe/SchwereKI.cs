using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    /// <summary>
    /// Schwere KI, die nach dem Minimax-Algorithmus spielt.
    /// </summary>
    class SchwereKI
    {
        /// <summary>
        /// Errechnet einen Zug für die KI, abhängig vom übergebenen Feld und der Perspektive.
        /// </summary>
        /// <param name="feld">Array mit den Spielerzahlen als Repräsentation des Spielfelds.</param>
        /// <param name="perspektive">Angabe der Perspektive der KI, entweder Spieler 1 oder Spieler 2.</param>
        /// <returns>Koordinaten Objekt für den Zug der KI.</returns>
        public Koordinate GetZug(int[,] feld, int perspektive)
        {
            GewichteteKoordinate zug = MiniMax(new KISpielbrett(feld), perspektive, perspektive);
            return zug.GetKoordinate();
        }

        /// <summary>
        /// Rekursive Funktion, um entweder eine Siegmöglichkeit zu finden, oder den Sieg des Gegners zu verhindern.
        /// </summary>
        /// <param name="brett">Spielbrett Objekt, mit dem die KI das Spiel simuliert.</param>
        /// <param name="spielerNummer">Die Nummer des Spielers, der in der aktuellen Rekursion am Zug ist.</param>
        /// <param name="vorgeseheneSpielerNummer">Nummer des Spielers, den die KI repräsentieren soll.</param>
        /// <returns>Die gewichtete Koordinate, die sich als der beste Zug ergeben hat.</returns>
        private GewichteteKoordinate MiniMax(KISpielbrett brett, int spielerNummer, int vorgeseheneSpielerNummer)
        {
            /*Bester Zug, der sich aus der Rekursion ergeben hat. Entweder eine Siegmöglichkeit
             * oder ein Zug um den Sieg des Gegners zu verhindern. Notfalls auch ein Unentschieden*/
            GewichteteKoordinate besterZug = null;
            List<GewichteteKoordinate> optionen = brett.GetLeereFelder();
            KISpielbrett neuesBrett;

            //Für jedes leere Feld wird ein neues Spielbrett angelegt, um die Züge zu simulieren
            for (int i = 0; i < optionen.Count; i++)
            {
                neuesBrett= brett.Kopie();

                //Entnimmt den nächsten möglichen Zug aus der Liste und setzt ihn
                GewichteteKoordinate neuerZug = optionen[i];
                neuesBrett.MacheZug(neuerZug, spielerNummer);

                /*Solange dieses Spielbrett das Spiel nicht beendet, werden rekursiv neue Spielbretter angelegt.
                 * Dabei wird der Spieler gewechselt*/
                if (neuesBrett.GetSieger()==0 && neuesBrett.GetLeereFelder().Count>0)
                {
                    int neueSpielerNummer = InvertiereSpieler(spielerNummer);
                    GewichteteKoordinate tempZug = MiniMax(neuesBrett, neueSpielerNummer, vorgeseheneSpielerNummer);
                    
                    //Übernimmt die Bewertung des rekursiven Zugs.
                    neuerZug.SetBewertung(tempZug.GetBewertung());
                }
                //Beendet das aktuelle Brett das Spiel, wird dies bewertet.
                else
                {
                    if (neuesBrett.GetSieger()==0)
                    {
                        neuerZug.SetBewertung(0);
                    }
                    else if (neuesBrett.GetSieger()==vorgeseheneSpielerNummer)
                    {
                        neuerZug.SetBewertung(1);
                    }
                    else if (neuesBrett.GetSieger()==InvertiereSpieler(vorgeseheneSpielerNummer))
                    {
                        neuerZug.SetBewertung(-1);
                    }
                }

                /* Der gemachte Zug wird zum besten Zug, wenn dieser entweder zum Sieg führt,
                 * den des Gegners verhindert, oder es keine Wahl (Unentschieden) gibt*/
                if (besterZug==null || 
                    (spielerNummer==InvertiereSpieler(vorgeseheneSpielerNummer) && neuerZug.GetBewertung()<besterZug.GetBewertung()) || 
                    (spielerNummer==vorgeseheneSpielerNummer && neuerZug.GetBewertung() > besterZug.GetBewertung()))
                {
                    besterZug = neuerZug;
                }
            }
            return besterZug;
        }
        /// <summary>
        /// Hilfsmethode, um die Nummer des Spielers zu invertieren.
        /// </summary>
        /// <param name="spielerNummer">Nummer des aktuellen Spielers.</param>
        /// <returns>Nummer des anderen Spielers.</returns>
        private int InvertiereSpieler(int spielerNummer)
        {
            if (spielerNummer==1)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }
    }
}
