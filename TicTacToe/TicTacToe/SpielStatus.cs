using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    /// <summary>
    /// Klasse, mittels der der aktuelle Status des Spiels repräsentiert werden kann.
    /// </summary>
    class SpielStatus
    {

        /// <summary>
        /// Repräsentation des Spielfeldes.
        /// </summary>
        private int[,] feld = new int[3, 3];

        /// <summary>
        /// Spielmodi der Spieler.
        /// </summary>
        private SpielLogik.Spielmodi spieler1;
        private SpielLogik.Spielmodi spieler2;

        /// <summary>
        /// Gibt an, ob der Zug gültig war.
        /// </summary>
        private bool valide = true;

        /// <summary>
        /// Flag zum Markieren, ob Spieler 1 am Zug ist.
        /// </summary>
        private bool spieler1Zug = true;

        /// <summary>
        /// Flag zum Markieren, ob eine KI am Zug ist.
        /// </summary>
        private bool kiZug;

        /// <summary>
        /// Flag zum Markieren eines Unentschieden.
        /// </summary>
        private bool unentschieden = false;

        /// <summary>
        /// Zähler für die Züge, die gemacht wurden, dient zur Feststellung eines Unentschieden.
        /// </summary>
        private int zuege = 0;

        /// <summary>
        /// Sieg Felder.
        /// </summary>
        private Koordinate[] siegFelder;

        /// <summary>
        /// Konstruktor. Bereitet das Spiel entsprechend der übergebenen Spielmodi vor.
        /// </summary>
        /// <param name="spieler1">Spielmodus des ersten Spielers.</param>
        /// <param name="spieler2">Spielmodus des zweiten Spielers.</param>
        public SpielStatus(SpielLogik.Spielmodi spieler1, SpielLogik.Spielmodi spieler2)
        {
            this.spieler1 = spieler1;
            this.spieler2 = spieler2;
            //Ist der erste Spieler eine KI muss die KI Flag gesetzt werden, damit diese auch anfängt.
            if (spieler1==SpielLogik.Spielmodi.KILeicht || spieler1==SpielLogik.Spielmodi.KISchwer)
            {
                kiZug = true;
            }
        }

        /// <summary>
        /// Getter für das Spielfeld Array.
        /// </summary>
        /// <returns>Spielfeld Array.</returns>
        public int[,] GetFeld()
        {
            return feld;
        }
        /// <summary>
        /// Getter für die valide Flag.
        /// </summary>
        /// <returns>Valide Flag.</returns>
        public bool GetValide()
        {
            return valide;
        }
        /// <summary>
        /// Getter für die Spieler1Zug Flag.
        /// </summary>
        /// <returns>Spieler1Zug Flag.</returns>
        public bool GetSpieler1Zug()
        {
            return spieler1Zug;
        }
        /// <summary>
        /// Getter für die KiZug Flag.
        /// </summary>
        /// <returns>KiZug Flag.</returns>
        public bool GetKiZug()
        {
            return kiZug;
        }
        /// <summary>
        /// Getter für das SiegFelder Array.
        /// </summary>
        /// <returns>SiegFelder Array.</returns>
        public Koordinate[] GetSiegFelder()
        {
            return siegFelder;
        }
        /// <summary>
        /// Getter für die Unentschieden Flag.
        /// </summary>
        /// <returns>Unentschieden Flag.</returns>
        public bool GetUnentschieden()
        {
            return unentschieden;
        }

        /// <summary>
        /// Setter für die valide Flag.
        /// </summary>
        /// <param name="valide">Zu setzender Wert.</param>
        public void SetValide(bool valide)
        {
            this.valide = valide;
        }
        /// <summary>
        /// Setter für die Sieg Felder.
        /// </summary>
        /// <param name="siegFelder">Array mit den Sieg Feldern</param>
        public void SetSiegFelder(Koordinate[] siegFelder)
        {
            this.siegFelder = siegFelder;
        }

        /// <summary>
        /// Setzt den übergebenen Spieler an die übergebene Position.
        /// </summary>
        /// <param name="k">Zu setzende Koordinate.</param>
        /// <param name="spieler1">Zu setzenden Spieler.</param>
        public void Setzte(Koordinate k, bool spieler1)
        {
            if (spieler1)
            {
                feld[k.GetX(), k.GetY()] = 1;
            }
            else
            {
                feld[k.GetX(), k.GetY()] = 2;
            }
        }
        /// <summary>
        /// Beendet den aktuellen Zug.
        /// Negiert den Wert der Spieler1Zug Flag und erhöht den Wert des Zug Zählers um 1.
        /// Im Falle eines vollen Spielfeldes wird die Unentschieden Flag auf true gesetzt.
        /// Ist der Spieler der jetzt dran ist eine KI, so wird die Flag entsprechend gesetzt.
        /// </summary>
        public void ZugBeenden()
        {
            spieler1Zug = !spieler1Zug;
            zuege++;
            if (zuege>=9)
            {
                unentschieden = true;
            }
            kiZug = false;
            if (spieler1Zug && (spieler1==SpielLogik.Spielmodi.KILeicht || spieler1==SpielLogik.Spielmodi.KISchwer))
            {
                kiZug = true;
            }
            if (!spieler1Zug && (spieler2 == SpielLogik.Spielmodi.KILeicht || spieler2 == SpielLogik.Spielmodi.KISchwer))
            {
                kiZug = true;
            }
        }
    }
}
