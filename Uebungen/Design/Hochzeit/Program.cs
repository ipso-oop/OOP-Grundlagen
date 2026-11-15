using System;
using System.Collections.Generic;

namespace Hochzeit
{
    /// <summary>
    /// Ein Gast, dessen Art ein Text ist.
    /// Der Beitrag verzweigt an diesem Text.
    /// </summary>
    public class Gast
    {
        private readonly string art;
        private readonly int tisch;

        public Gast(string name, string art, int tisch)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Der Name darf nicht leer sein.");
            }

            if (art != "Brautpaar" && art != "Familie" && art != "Kind")
            {
                throw new ArgumentException("Unbekannte Gästeart.");
            }

            if (tisch <= 0)
            {
                throw new ArgumentException("Der Tisch muss grösser als 0 sein.");
            }

            Name = name.Trim();
            this.art = art;
            this.tisch = tisch;
        }

        public string Name { get; private set; }

        public string Art
        {
            get { return art; }
        }

        public int Tisch
        {
            get { return tisch; }
        }

        public decimal Beitrag()
        {
            if (art == "Brautpaar")
            {
                return 0m;
            }

            if (art == "Familie")
            {
                return 80m;
            }

            if (art == "Kind")
            {
                return 40m;
            }

            return 0m;
        }

        public void Ausgeben()
        {
            Console.WriteLine(
                "  " + Name + ", " + Art + ", Tisch " + Tisch
                + ", " + Beitrag().ToString("0.00") + " CHF");
        }
    }

    public class Hochzeit
    {
        private readonly List<Gast> gaeste = new List<Gast>();

        public Hochzeit(string paar, string datum, string ort)
        {
            if (string.IsNullOrWhiteSpace(paar) || string.IsNullOrWhiteSpace(datum) || string.IsNullOrWhiteSpace(ort))
            {
                throw new ArgumentException("Paar, Datum und Ort dürfen nicht leer sein.");
            }

            Paar = paar.Trim();
            Datum = datum.Trim();
            Ort = ort.Trim();
        }

        public string Paar { get; private set; }

        public string Datum { get; private set; }

        public string Ort { get; private set; }

        public void Hinzufuegen(Gast gast)
        {
            if (gast == null)
            {
                throw new ArgumentNullException("gast");
            }

            gaeste.Add(gast);
        }

        public int Gedeck
        {
            get { return gaeste.Count; }
        }

        public decimal Beitragssumme()
        {
            decimal summe = 0m;
            foreach (Gast gast in gaeste)
            {
                summe += gast.Beitrag();
            }

            return summe;
        }

        public void Ausgeben()
        {
            Console.WriteLine(Paar);
            Console.WriteLine(Datum + ", " + Ort);
            Console.WriteLine();
            Console.WriteLine("Gäste");
            foreach (Gast gast in gaeste)
            {
                gast.Ausgeben();
            }

            Console.WriteLine();
            Console.WriteLine("Gedeck: " + Gedeck);
            Console.WriteLine("Beitrag: " + Beitragssumme().ToString("0.00") + " CHF");
        }
    }

    /// <summary>
    /// Aufgabe: Hochzeit, Typcode statt Unterklassen.
    /// Vorbild ist die Lösung Abbildung und die Übung Versand.
    /// Die Gästeart ist der Text Brautpaar, Familie oder Kind.
    /// Beitrag() verzweigt an diesem Text. Eine Art Kollege muss
    /// im Konstruktor und in Beitrag() ergänzt werden.
    ///
    /// Umbau, die Ausgabe bleibt gleich:
    /// - Gast wird abstrakt, Ausgeben() bleibt in der Basisklasse.
    /// - Brautpaar, Familie und Kind liefern Art und Beitrag selbst.
    /// - Hochzeit kennt nur den Typ Gast.
    /// </summary>
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Hochzeit ===");
            Console.WriteLine();

            Hochzeit fest = new Hochzeit("Anna und Ben", "14. Juni 2026", "Schloss Hallwyl");
            fest.Hinzufuegen(new Gast("Anna Berger", "Brautpaar", 1));
            fest.Hinzufuegen(new Gast("Ben Meier", "Brautpaar", 1));
            fest.Hinzufuegen(new Gast("Clara Meier", "Familie", 2));
            fest.Hinzufuegen(new Gast("Dan Berger", "Kind", 2));
            fest.Ausgeben();

            Console.ReadLine();
        }
    }
}
