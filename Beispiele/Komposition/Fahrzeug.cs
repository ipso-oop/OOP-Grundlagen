using System;

namespace BeispieleOOPKonzepte
{
    /// <summary>
    /// Austauschbares Teil. Das Fahrzeug hängt nur von diesem Vertrag ab,
    /// nicht von Benzinmotor oder Elektromotor.
    /// </summary>
    public interface IAntrieb
    {
        string Bezeichnung { get; }

        void Starten();
    }

    public class Benzinmotor : IAntrieb
    {
        public string Bezeichnung
        {
            get { return "Benzinmotor"; }
        }

        public void Starten()
        {
            Console.WriteLine("Benzinmotor springt an.");
        }
    }

    public class Elektromotor : IAntrieb
    {
        public string Bezeichnung
        {
            get { return "Elektromotor"; }
        }

        public void Starten()
        {
            Console.WriteLine("Elektromotor summt.");
        }
    }

    /// <summary>
    /// Ein Fahrzeug IST kein Motor. Es HAT einen Antrieb.
    /// Deshalb gibt es keine Unterklassen Benzinauto und Elektroauto,
    /// solange sich nur der Antrieb unterscheidet.
    /// </summary>
    public class Fahrzeug
    {
        private readonly IAntrieb antrieb;

        public Fahrzeug(string modell, IAntrieb antrieb)
        {
            if (string.IsNullOrWhiteSpace(modell))
            {
                throw new ArgumentException("Das Modell darf nicht leer sein.");
            }

            if (antrieb == null)
            {
                throw new ArgumentNullException("antrieb");
            }

            Modell = modell.Trim();
            this.antrieb = antrieb;
        }

        public string Modell { get; private set; }

        public void Losfahren()
        {
            antrieb.Starten();
            Console.WriteLine(Modell + " fährt (" + antrieb.Bezeichnung + ").");
        }
    }
}
