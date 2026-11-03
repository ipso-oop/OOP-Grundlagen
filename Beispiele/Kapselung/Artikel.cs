using System;

namespace BeispieleOOPKonzepte
{
    /// <summary>
    /// Ein Artikel verwahrt seinen Zustand privat.
    /// Gelesen und geändert wird er nur über Properties und Methoden,
    /// die ungültige Werte abweisen.
    /// </summary>
    public class Artikel
    {
        private string name;
        private decimal preis;
        private int lagerbestand;

        public Artikel(string name, decimal preis, int lagerbestand)
        {
            // Zuweisung über die Properties, damit die Prüfung immer gilt,
            // auch schon beim Erzeugen des Objekts.
            Name = name;
            Preis = preis;
            SetzeBestand(lagerbestand);
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Der Name darf nicht leer sein.");
                }

                name = value.Trim();
            }
        }

        /// <summary>
        /// Der Preis bleibt änderbar, aber nie negativ.
        /// Diese Regel steht nur hier, nicht bei jedem Aufrufer.
        /// </summary>
        public decimal Preis
        {
            get { return preis; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Der Preis darf nicht negativ sein.");
                }

                preis = value;
            }
        }

        public int Lagerbestand
        {
            get { return lagerbestand; }
        }

        /// <summary>
        /// Abgeleiteter Wert. Er wird nicht gespeichert und kann deshalb
        /// nicht von Preis oder Bestand abweichen.
        /// </summary>
        public decimal Lagerwert
        {
            get { return preis * lagerbestand; }
        }

        public void Einlagern(int menge)
        {
            if (menge <= 0)
            {
                throw new ArgumentException("Die Menge muss grösser als 0 sein.");
            }

            lagerbestand += menge;
        }

        public void Entnehmen(int menge)
        {
            if (menge <= 0)
            {
                throw new ArgumentException("Die Menge muss grösser als 0 sein.");
            }

            if (menge > lagerbestand)
            {
                throw new InvalidOperationException("Nicht genug Artikel auf Lager.");
            }

            lagerbestand -= menge;
        }

        public override string ToString()
        {
            return name
                + ", " + preis.ToString("0.00") + " CHF"
                + ", Bestand " + lagerbestand
                + ", Lagerwert " + Lagerwert.ToString("0.00") + " CHF";
        }

        private void SetzeBestand(int wert)
        {
            if (wert < 0)
            {
                throw new ArgumentException("Der Lagerbestand darf nicht negativ sein.");
            }

            lagerbestand = wert;
        }
    }
}
