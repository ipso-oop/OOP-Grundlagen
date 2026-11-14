using System;
using System.Collections.Generic;

namespace Versand
{
    /// <summary>
    /// Eine Sendung, deren Art ein Text ist.
    /// Preis, Zustellzeit und die Briefgrenze verzweigen an diesem Text.
    /// </summary>
    public class Sendung
    {
        private readonly string art;
        private readonly decimal gewicht;

        public Sendung(string art, decimal gewicht)
        {
            if (string.IsNullOrWhiteSpace(art))
            {
                throw new ArgumentException("Die Art darf nicht leer sein.");
            }

            if (art != "Brief" && art != "Paket" && art != "Sperrgut")
            {
                throw new ArgumentException("Unbekannte Sendungsart.");
            }

            if (gewicht <= 0)
            {
                throw new ArgumentException("Das Gewicht muss grösser als 0 sein.");
            }

            if (art == "Brief" && gewicht > 0.1m)
            {
                throw new ArgumentException("Ein Brief darf höchstens 100 g wiegen.");
            }

            this.art = art;
            this.gewicht = gewicht;
        }

        public string Art
        {
            get { return art; }
        }

        public decimal Gewicht
        {
            get { return gewicht; }
        }

        public decimal Preis()
        {
            if (art == "Brief")
            {
                return 1.20m;
            }

            if (art == "Paket")
            {
                return 6.00m + 2.00m * gewicht;
            }

            if (art == "Sperrgut")
            {
                return 15.00m + 4.00m * gewicht;
            }

            return 0m;
        }

        public int Zustelltage()
        {
            if (art == "Brief")
            {
                return 2;
            }

            if (art == "Paket")
            {
                return 3;
            }

            if (art == "Sperrgut")
            {
                return 5;
            }

            return 0;
        }

        public void Ausgeben()
        {
            Console.WriteLine(
                art + ", " + gewicht.ToString("0.00") + " kg: "
                + Preis().ToString("0.00") + " CHF, "
                + Zustelltage() + " Tage");
        }
    }

    /// <summary>
    /// Aufgabe: Schlechtes Design verbessern.
    /// Vorbild ist die Lösung Abbildung. Dort rechnet jede Figur selbst,
    /// die Ausgabe läuft über die Basisklasse.
    ///
    /// Die Konsolenausgabe dieser Klasse ist fachlich richtig.
    /// Eine neue Sendungsart muss trotzdem im Konstruktor, in Preis
    /// und in Zustelltage ergänzt werden. Fehlt eine Stelle, kompiliert
    /// das Programm und rechnet falsch.
    ///
    /// Umbau, die Ausgabe bleibt gleich:
    /// - abstrakte Klasse Sendung
    /// - Brief, Paket und Sperrgut mit eigener Formel
    /// - Ausgeben() bleibt in der Basisklasse und fragt nicht nach der Art
    /// - die Grenze von 100 g steht nur in der Klasse Brief
    /// </summary>
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Versand ===");
            Console.WriteLine();

            List<Sendung> sendungen = new List<Sendung>();
            sendungen.Add(new Sendung("Brief", 0.02m));
            sendungen.Add(new Sendung("Paket", 3m));
            sendungen.Add(new Sendung("Sperrgut", 8m));

            decimal summe = 0m;
            foreach (Sendung sendung in sendungen)
            {
                sendung.Ausgeben();
                summe += sendung.Preis();
            }

            Console.WriteLine("Summe: " + summe.ToString("0.00") + " CHF");
            Console.WriteLine();

            try
            {
                new Sendung("Brief", 0.50m);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Brief 0.50 kg abgelehnt: " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}
