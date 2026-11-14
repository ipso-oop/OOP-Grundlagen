using System;

namespace Melder
{
    public class RauchmelderSirene
    {
        private readonly string ort;

        public RauchmelderSirene(string ort)
        {
            if (string.IsNullOrWhiteSpace(ort))
            {
                throw new ArgumentException("Der Ort darf nicht leer sein.");
            }

            this.ort = ort.Trim();
        }

        public void Ausloesen()
        {
            Console.WriteLine("Rauchmelder " + ort + ": Sirene heult.");
        }
    }

    public class RauchmelderEmail
    {
        private readonly string ort;

        public RauchmelderEmail(string ort)
        {
            if (string.IsNullOrWhiteSpace(ort))
            {
                throw new ArgumentException("Der Ort darf nicht leer sein.");
            }

            this.ort = ort.Trim();
        }

        public void Ausloesen()
        {
            Console.WriteLine("Rauchmelder " + ort + ": E-Mail an hauswart@schule.ch.");
        }
    }

    public class BewegungsmelderSirene
    {
        private readonly string ort;

        public BewegungsmelderSirene(string ort)
        {
            if (string.IsNullOrWhiteSpace(ort))
            {
                throw new ArgumentException("Der Ort darf nicht leer sein.");
            }

            this.ort = ort.Trim();
        }

        public void Ausloesen()
        {
            Console.WriteLine("Bewegungsmelder " + ort + ": Sirene heult.");
        }
    }

    public class BewegungsmelderEmail
    {
        private readonly string ort;

        public BewegungsmelderEmail(string ort)
        {
            if (string.IsNullOrWhiteSpace(ort))
            {
                throw new ArgumentException("Der Ort darf nicht leer sein.");
            }

            this.ort = ort.Trim();
        }

        public void Ausloesen()
        {
            Console.WriteLine("Bewegungsmelder " + ort + ": E-Mail an hauswart@schule.ch.");
        }
    }

    /// <summary>
    /// Aufgabe: Schlechtes Design verbessern.
    /// Zwei Eigenschaften werden zu einer Klasse verrechnet:
    /// die Art des Melders und die Art des Alarms.
    /// SMS als weitere Alarmart bräuchte wieder zwei neue Klassen.
    /// Die vier Klassen haben keinen gemeinsamen Typ, deshalb gibt es
    /// keine Liste und keine gemeinsame Schleife.
    /// Dieselbe Prüfung des Orts steht viermal im Code.
    ///
    /// Umbau, die Ausgabe bleibt gleich:
    /// - Ein Melder hat einen Alarm. Er ist keiner.
    /// - Sirene und E-Mail sind austauschbare Klassen hinter einem Vertrag.
    /// - Rauch und Bewegung unterscheiden sich hier nur im Namen.
    /// - Main hält eine Liste und ruft nur Ausloesen() auf.
    /// </summary>
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Melder ===");
            Console.WriteLine();

            new RauchmelderSirene("Küche").Ausloesen();
            new BewegungsmelderEmail("Eingang").Ausloesen();
            new RauchmelderEmail("Labor").Ausloesen();
            new BewegungsmelderSirene("Archiv").Ausloesen();

            Console.ReadLine();
        }
    }
}
