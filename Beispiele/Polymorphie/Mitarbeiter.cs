using System;

namespace BeispieleOOPKonzepte
{
    /// <summary>
    /// Gemeinsamer Vertrag aller Mitarbeiter.
    /// Die Klasse ist abstract, weil "ein Mitarbeiter" allein noch keine
    /// Lohnformel hat. Jede konkrete Art liefert ihre eigene.
    /// </summary>
    public abstract class Mitarbeiter
    {
        private readonly string name;

        protected Mitarbeiter(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Der Name darf nicht leer sein.");
            }

            this.name = name.Trim();
        }

        public string Name
        {
            get { return name; }
        }

        public abstract decimal BerechneLohn();

        protected abstract string Lohnart { get; }

        /// <summary>
        /// Steht in der Basisklasse und gilt für jede Art.
        /// BerechneLohn() und Lohnart werden zur Laufzeit in der jeweiligen
        /// Unterklasse ausgeführt.
        /// </summary>
        public decimal Auszahlen()
        {
            decimal lohn = BerechneLohn();
            Console.WriteLine("  " + Name + ", " + Lohnart + ": " + lohn.ToString("0.00") + " CHF");
            return lohn;
        }
    }

    public class Festangestellter : Mitarbeiter
    {
        private readonly decimal monatslohn;

        public Festangestellter(string name, decimal monatslohn)
            : base(name)
        {
            if (monatslohn < 0)
            {
                throw new ArgumentException("Der Monatslohn darf nicht negativ sein.");
            }

            this.monatslohn = monatslohn;
        }

        public override decimal BerechneLohn()
        {
            return monatslohn;
        }

        protected override string Lohnart
        {
            get { return "Festgehalt"; }
        }
    }

    public class StundenlohnEmpfaenger : Mitarbeiter
    {
        private readonly decimal stundenlohn;
        private readonly decimal stunden;

        public StundenlohnEmpfaenger(string name, decimal stundenlohn, decimal stunden)
            : base(name)
        {
            if (stundenlohn < 0 || stunden < 0)
            {
                throw new ArgumentException("Stundenlohn und Stunden dürfen nicht negativ sein.");
            }

            this.stundenlohn = stundenlohn;
            this.stunden = stunden;
        }

        public override decimal BerechneLohn()
        {
            return stundenlohn * stunden;
        }

        protected override string Lohnart
        {
            get
            {
                return "Stundenlohn " + stunden.ToString("0.##")
                    + " h à " + stundenlohn.ToString("0.00");
            }
        }
    }

    /// <summary>
    /// Grundlohn plus Anteil am Umsatz.
    /// Neue Lohnart: nur diese Klasse kommt dazu, der Lohnlauf bleibt gleich.
    /// </summary>
    public class ProvisionsEmpfaenger : Mitarbeiter
    {
        private readonly decimal grundlohn;
        private readonly decimal umsatz;
        private readonly decimal satz;

        public ProvisionsEmpfaenger(string name, decimal grundlohn, decimal umsatz, decimal satz)
            : base(name)
        {
            if (grundlohn < 0 || umsatz < 0 || satz < 0)
            {
                throw new ArgumentException("Grundlohn, Umsatz und Satz dürfen nicht negativ sein.");
            }

            this.grundlohn = grundlohn;
            this.umsatz = umsatz;
            this.satz = satz;
        }

        public override decimal BerechneLohn()
        {
            return grundlohn + umsatz * satz;
        }

        protected override string Lohnart
        {
            get { return "Grundlohn plus " + (satz * 100m).ToString("0") + "% vom Umsatz"; }
        }
    }
}
