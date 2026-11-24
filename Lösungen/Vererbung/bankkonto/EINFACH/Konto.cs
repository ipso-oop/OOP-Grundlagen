using System;

namespace Konto
{
    public class Konto
    {
        private string mKontoNummer;
        private double mKontoStand;

        /// <summary>
        /// Konstruktor zur Initialisierung von KontoNummer und KontoStand.
        /// </summary>
        /// <param name="nummer">Kontonummer</param>
        /// <param name="betrag">Anfangssaldo</param>
        public Konto(string nummer, double betrag)
        {
            this.mKontoNummer = nummer;
            this.mKontoStand = betrag;
        }

        /// <summary>
        /// Konstruktor zur Initialisierung der KontoNummer.
        /// Der KontoStand wird mit 0 initialisiert.
        /// </summary>
        /// <param name="nummer">Kontonummer</param>
        public Konto(string nummer)
        {
            mKontoNummer = nummer;
            mKontoStand = 0;
        }

        public double gibKontostand()
        {
            return mKontoStand;
        }

        public string gibKontoNummer()
        {
            return mKontoNummer;
        }

        /// <summary>
        /// Erhöht den KontoStand um den angegebenen Betrag.
        /// </summary>
        public void einzahlen(double betrag)
        {
            mKontoStand += betrag;
        }

        /// <summary>
        /// Reduziert den KontoStand um den angegebenen Betrag.
        /// Es kann höchstens so viel abgehoben werden, dass der Stand positiv bleibt.
        /// </summary>
        /// <returns>true, wenn die Abhebung ausgeführt wurde</returns>
        public bool abheben(double betrag)
        {
            bool valid = mKontoStand - betrag > 0;
            if (valid)
                mKontoStand -= betrag;
            return valid;
        }

        /// <summary>
        /// Zeigt KontoNummer und KontoStand an.
        /// virtual, damit Unterklassen die Methode mit override ersetzen.
        /// </summary>
        public virtual void auszug()
        {
            Console.WriteLine("Konto          : " + mKontoNummer);
            Console.WriteLine("Kontostand Fr. : " + mKontoStand);
        }

        public override string ToString()
        {
            return "Konto " + mKontoNummer + " (Kontostand " + mKontoStand + ")";
        }
    }

    /// <summary>
    /// Unterklasse mit eigenem Attribut, Konstruktor und überschriebenem Auszug.
    /// </summary>
    public class Waehrungskonto : Konto
    {
        private string mWaehrung;

        public Waehrungskonto(string nummer, string waehrung) : base(nummer)
        {
            mWaehrung = waehrung;
            Console.WriteLine("Waehrungskonto initialisiert.");
        }

        /// <summary>
        /// Ersetzt den Auszug der Basisklasse: der Saldo wird in der Kontowährung gezeigt.
        /// </summary>
        public override void auszug()
        {
            Console.WriteLine("Konto          : " + gibKontoNummer());
            Console.WriteLine("Kontostand " + mWaehrung + " : " + gibKontostand());
        }
    }

    /// <summary>
    /// Unterklasse mit Zinssatz, zusätzlicher Methode saldieren und überschriebenem Auszug.
    /// </summary>
    public class Sparkonto : Konto
    {
        private double mZinssatz;

        public Sparkonto(string nummer, double zinssatz) : base(nummer)
        {
            mZinssatz = zinssatz;
            Console.WriteLine("Sparkonto initialisiert.");
        }

        /// <summary>
        /// Schreibt den Zins auf den Kontostand gut.
        /// </summary>
        public void saldieren()
        {
            einzahlen(mZinssatz * gibKontostand() / 100);
        }

        /// <summary>
        /// Übernimmt den Auszug der Basisklasse und ergänzt den Zinssatz.
        /// </summary>
        public override void auszug()
        {
            base.auszug();
            Console.WriteLine("Zinssatz       : " + mZinssatz + " %");
        }
    }
}
