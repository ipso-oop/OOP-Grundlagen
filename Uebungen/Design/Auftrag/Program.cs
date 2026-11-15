using System;

namespace Auftrag
{
    public class Tarif
    {
        private readonly decimal grundpreis;
        private readonly decimal kilopreis;

        public Tarif(decimal grundpreis, decimal kilopreis)
        {
            if (grundpreis < 0m || kilopreis < 0m)
            {
                throw new ArgumentException("Die Preise dürfen nicht negativ sein.");
            }

            this.grundpreis = grundpreis;
            this.kilopreis = kilopreis;
        }

        public decimal Preis(decimal gewicht)
        {
            if (gewicht <= 0m)
            {
                throw new ArgumentException("Das Gewicht muss grösser als 0 sein.");
            }

            return grundpreis + kilopreis * gewicht;
        }
    }

    public class Region
    {
        public Region(string name, Tarif tarif)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Der Name darf nicht leer sein.");
            }

            if (tarif == null)
            {
                throw new ArgumentNullException("tarif");
            }

            Name = name.Trim();
            Tarif = tarif;
        }

        public string Name { get; private set; }

        public Tarif Tarif { get; private set; }
    }

    public class Adresse
    {
        public Adresse(string strasse, string plz, string ort, Region region)
        {
            if (string.IsNullOrWhiteSpace(strasse))
            {
                throw new ArgumentException("Die Strasse darf nicht leer sein.");
            }

            if (string.IsNullOrWhiteSpace(plz) || string.IsNullOrWhiteSpace(ort))
            {
                throw new ArgumentException("PLZ und Ort dürfen nicht leer sein.");
            }

            if (region == null)
            {
                throw new ArgumentNullException("region");
            }

            Strasse = strasse.Trim();
            Plz = plz.Trim();
            Ort = ort.Trim();
            Region = region;
        }

        public string Strasse { get; private set; }

        public string Plz { get; private set; }

        public string Ort { get; private set; }

        public Region Region { get; private set; }
    }

    public class Kunde
    {
        public Kunde(string name, Adresse adresse)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Der Name darf nicht leer sein.");
            }

            if (adresse == null)
            {
                throw new ArgumentNullException("adresse");
            }

            Name = name.Trim();
            Adresse = adresse;
        }

        public string Name { get; private set; }

        public Adresse Adresse { get; private set; }
    }

    public class Auftrag
    {
        public Auftrag(Kunde kunde, decimal gewicht)
        {
            if (kunde == null)
            {
                throw new ArgumentNullException("kunde");
            }

            if (gewicht <= 0m)
            {
                throw new ArgumentException("Das Gewicht muss grösser als 0 sein.");
            }

            Kunde = kunde;
            Gewicht = gewicht;
        }

        public Kunde Kunde { get; private set; }

        public decimal Gewicht { get; private set; }
    }

    /// <summary>
    /// Aufgabe: Train Wreck auflösen.
    /// Die Ausgabe ist richtig. Main kennt dafür den ganzen Innenbau:
    /// Kunde, Adresse, Region und Tarif.
    /// Die Kette auftrag.Kunde.Adresse.Region.Tarif.Preis ist ein Train Wreck.
    /// Wechselt ein Glied, muss jeder solche Aufruf mitgeändert werden.
    ///
    /// Umbau, die Ausgabe bleibt gleich:
    /// - Main spricht nur mit Auftrag.
    /// - Jede Klasse fragt nur ihren direkten Nachbarn.
    /// - Versandpreis() wird von Auftrag an Kunde, Adresse, Region und dann an Tarif gereicht.
    /// - Die Nachbarn sind nicht mehr öffentlich durchgereicht.
    /// </summary>
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Auftrag ===");
            Console.WriteLine();

            Tarif tarif = new Tarif(6.00m, 1.50m);
            Region region = new Region("Stadt", tarif);
            Adresse adresse = new Adresse("Bahnhofstrasse 12", "8001", "Zürich", region);
            Kunde kunde = new Kunde("Ada Berger", adresse);
            Auftrag auftrag = new Auftrag(kunde, 3m);

            Console.WriteLine(auftrag.Kunde.Name);
            Console.WriteLine(auftrag.Kunde.Adresse.Strasse);
            Console.WriteLine(auftrag.Kunde.Adresse.Plz + " " + auftrag.Kunde.Adresse.Ort);
            Console.WriteLine("Region: " + auftrag.Kunde.Adresse.Region.Name);
            Console.WriteLine("Gewicht: " + auftrag.Gewicht.ToString("0.00") + " kg");
            Console.WriteLine(
                "Versand: "
                + auftrag.Kunde.Adresse.Region.Tarif.Preis(auftrag.Gewicht).ToString("0.00")
                + " CHF");

            Console.ReadLine();
        }
    }
}
