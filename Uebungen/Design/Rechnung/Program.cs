using System;
using System.Collections.Generic;

namespace Rechnung
{
    public class Position
    {
        public Position(string bezeichnung, int menge, decimal einzelpreis)
        {
            if (string.IsNullOrWhiteSpace(bezeichnung))
            {
                throw new ArgumentException("Die Bezeichnung darf nicht leer sein.");
            }

            if (menge <= 0)
            {
                throw new ArgumentException("Die Menge muss grösser als 0 sein.");
            }

            if (einzelpreis < 0)
            {
                throw new ArgumentException("Der Einzelpreis darf nicht negativ sein.");
            }

            Bezeichnung = bezeichnung.Trim();
            Menge = menge;
            Einzelpreis = einzelpreis;
        }

        public string Bezeichnung { get; private set; }

        public int Menge { get; private set; }

        public decimal Einzelpreis { get; private set; }
    }

    /// <summary>
    /// Die Rechnung kennt ihre Positionen und zugleich jedes Ausgabeformat.
    /// Text und CSV wiederholen die Betragsformel und die Schleife.
    /// </summary>
    public class Rechnung
    {
        private readonly List<Position> positionen = new List<Position>();

        public Rechnung(string nummer)
        {
            if (string.IsNullOrWhiteSpace(nummer))
            {
                throw new ArgumentException("Die Nummer darf nicht leer sein.");
            }

            Nummer = nummer.Trim();
        }

        public string Nummer { get; private set; }

        public void Hinzufuegen(string bezeichnung, int menge, decimal einzelpreis)
        {
            positionen.Add(new Position(bezeichnung, menge, einzelpreis));
        }

        public decimal Summe()
        {
            decimal summe = 0m;
            foreach (Position position in positionen)
            {
                summe += position.Menge * position.Einzelpreis;
            }

            return summe;
        }

        public void AlsText()
        {
            Console.WriteLine("--- Text ---");
            Console.WriteLine("Rechnung " + Nummer);
            foreach (Position position in positionen)
            {
                decimal betrag = position.Menge * position.Einzelpreis;
                Console.WriteLine(
                    "  " + position.Menge + " x " + position.Bezeichnung
                    + " à " + position.Einzelpreis.ToString("0.00")
                    + "    " + betrag.ToString("0.00") + " CHF");
            }

            Console.WriteLine("Summe: " + Summe().ToString("0.00") + " CHF");
        }

        public void AlsCsv()
        {
            Console.WriteLine("--- CSV ---");
            Console.WriteLine("Rechnung;" + Nummer);
            foreach (Position position in positionen)
            {
                decimal betrag = position.Menge * position.Einzelpreis;
                Console.WriteLine(
                    position.Bezeichnung + ";" + position.Menge + ";"
                    + position.Einzelpreis.ToString("0.00") + ";"
                    + betrag.ToString("0.00"));
            }

            Console.WriteLine("Summe;" + Summe().ToString("0.00"));
        }
    }

    /// <summary>
    /// Aufgabe: Schlechtes Design verbessern.
    /// AlsText und AlsCsv tun fachlich das Richtige.
    /// Ein drittes Format, zum Beispiel HTML, ändert die Klasse Rechnung,
    /// obwohl sich Menge, Preis und Summe nicht ändern.
    /// Die Formel Menge mal Einzelpreis steht in Summe, AlsText und AlsCsv.
    ///
    /// Umbau, die Ausgabe bleibt gleich:
    /// - Rechnung und Position berechnen nur Beträge.
    /// - Text und CSV sind eigene Klassen mit einem gemeinsamen Vertrag.
    /// - Eine neue Ausgabeform ist eine neue Klasse. Rechnung bleibt gleich.
    /// </summary>
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Rechnung ===");
            Console.WriteLine();

            Rechnung rechnung = new Rechnung("2026-014");
            rechnung.Hinzufuegen("Kugelschreiber", 2, 2.50m);
            rechnung.Hinzufuegen("Notizblock", 1, 4.00m);

            rechnung.AlsText();
            Console.WriteLine();
            rechnung.AlsCsv();

            Console.ReadLine();
        }
    }
}
