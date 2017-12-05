using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class SchwereKI
    {
        public Koordinate GetZug(int[,] feld, int perspektive)
        {
            GewichteteKoordinate zug = MiniMax(new KISpielbrett(feld), perspektive, perspektive);
            return zug.GetKoordinate();
        }

        //Rekursive Funktion, um entweder eine Siegmöglichkeit zu finden, oder den Sieg des Gegners zu verhindern
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

                /*Solange dieses Spiebrett das Spiel nicht beendet, werden rekursiv neue Spielbretter angelegt.
                 * Dabei wird der Spieler gewechselt*/
                if (neuesBrett.GetSieger()==0 && neuesBrett.GetLeereFelder().Count>0)
                {
                    int neueSpielerNummer = InvertiereSpieler(spielerNummer);
                    GewichteteKoordinate tempZug = MiniMax(neuesBrett, neueSpielerNummer, vorgeseheneSpielerNummer);
                    
                    //Übernimmt die die Bewertung des rekursiven Zugs.
                    neuerZug.SetBewertung(tempZug.GetBewertung());
                }
                //Beendet das aktuelle Brett das Spiel, wird dies Bewertet.
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

                /* Der gemachte Zug, wird zum besten Zug, wenn dieser Entweder zum Sieg führt,
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
