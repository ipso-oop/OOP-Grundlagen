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
    /// Eine Rechnung sollte Beträge kennen.
    /// Diese Klasse kennt zusätzlich den Kunden, die Mehrwertsteuer,
    /// die Mahnstufe, zwei Ausgabeformate, den E-Mail-Versand
    /// und das Speichern. Jede dieser Aufgaben ändert Rechnung.
    /// </summary>
    public class Rechnung
    {
        private readonly List<Position> positionen = new List<Position>();
        private readonly decimal mwstSatz = 0.081m;
        private string kundenName;
        private string kundenEmail;
        private int tageUeberfaellig;

        public Rechnung(string nummer)
        {
            if (string.IsNullOrWhiteSpace(nummer))
            {
                throw new ArgumentException("Die Nummer darf nicht leer sein.");
            }

            Nummer = nummer.Trim();
        }

        public string Nummer { get; private set; }

        public string KundenName
        {
            get { return kundenName; }
        }

        public string KundenEmail
        {
            get { return kundenEmail; }
        }

        public int TageUeberfaellig
        {
            get { return tageUeberfaellig; }
        }

        public void SetzeKunde(string name, string email)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Der Name darf nicht leer sein.");
            }

            if (string.IsNullOrWhiteSpace(email) || email.IndexOf('@') <= 0 || email.Trim().EndsWith("@"))
            {
                throw new ArgumentException("Die E-Mail-Adresse ist ungültig.");
            }

            kundenName = name.Trim();
            kundenEmail = email.Trim();
        }

        public void SetzeTageUeberfaellig(int tage)
        {
            if (tage < 0)
            {
                throw new ArgumentException("Die Tage dürfen nicht negativ sein.");
            }

            tageUeberfaellig = tage;
        }

        public void Hinzufuegen(string bezeichnung, int menge, decimal einzelpreis)
        {
            positionen.Add(new Position(bezeichnung, menge, einzelpreis));
        }

        public decimal Netto()
        {
            decimal summe = 0m;
            foreach (Position position in positionen)
            {
                summe += position.Menge * position.Einzelpreis;
            }

            return summe;
        }

        public decimal MwstBetrag()
        {
            return decimal.Round(Netto() * mwstSatz, 2, MidpointRounding.AwayFromZero);
        }

        public decimal Brutto()
        {
            return Netto() + MwstBetrag();
        }

        public string Mahnstufe()
        {
            if (tageUeberfaellig == 0)
            {
                return "Keine Mahnung";
            }

            if (tageUeberfaellig <= 10)
            {
                return "1. Erinnerung";
            }

            if (tageUeberfaellig <= 30)
            {
                return "2. Erinnerung";
            }

            return "Letzte Mahnung";
        }

        public void KundeAusgeben()
        {
            Console.WriteLine("Kunde: " + kundenName + " <" + kundenEmail + ">");
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

            Console.WriteLine("Netto: " + Netto().ToString("0.00") + " CHF");
            Console.WriteLine(
                "MwSt " + (mwstSatz * 100m).ToString("0.0") + "%: "
                + MwstBetrag().ToString("0.00") + " CHF");
            Console.WriteLine("Brutto: " + Brutto().ToString("0.00") + " CHF");
        }

        public void AlsCsv()
        {
            Console.WriteLine("--- CSV ---");
            Console.WriteLine("Rechnung;" + Nummer);
            Console.WriteLine(kundenName + ";" + kundenEmail);
            foreach (Position position in positionen)
            {
                decimal betrag = position.Menge * position.Einzelpreis;
                Console.WriteLine(
                    position.Bezeichnung + ";" + position.Menge + ";"
                    + position.Einzelpreis.ToString("0.00") + ";"
                    + betrag.ToString("0.00"));
            }

            Console.WriteLine("Netto;" + Netto().ToString("0.00"));
            Console.WriteLine("MwSt;" + MwstBetrag().ToString("0.00"));
            Console.WriteLine("Brutto;" + Brutto().ToString("0.00"));
        }

        public void MahnungAusgeben()
        {
            string einheit = tageUeberfaellig == 1 ? "Tag" : "Tage";
            Console.WriteLine(
                "Mahnung: " + Mahnstufe()
                + " (" + tageUeberfaellig + " " + einheit + " überfällig)");
        }

        public void SendeEmail()
        {
            Console.WriteLine(
                "E-Mail an " + kundenEmail
                + ": Rechnung " + Nummer
                + ", Brutto " + Brutto().ToString("0.00") + " CHF");
        }

        public void Speichern()
        {
            Console.WriteLine(
                "Gespeichert: Rechnung " + Nummer
                + ", Brutto " + Brutto().ToString("0.00") + " CHF");
        }
    }

    /// <summary>
    /// Die Ausgabe ist fachlich richtig. Die Klasse Rechnung ist es nicht.
    /// Sie prüft die E-Mail, rechnet die Mehrwertsteuer, wählt die Mahnstufe,
    /// schreibt Text und CSV, sendet die E-Mail und speichert die Rechnung.
    /// Menge mal Einzelpreis steht in Netto, AlsText und AlsCsv.
    ///
    /// Umbau, die Ausgabe bleibt gleich:
    /// - Kunde prüft Name und E-Mail.
    /// - Mehrwertsteuer rechnet den Steuerbetrag.
    /// - Mahnwesen wählt die Stufe.
    /// - Text und CSV sind Klassen hinter einem gemeinsamen Vertrag.
    /// - RechnungsMail sendet, RechnungsAblage speichert.
    /// - Rechnung behält Nummer, Positionen, Netto und Brutto.
    /// </summary>
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Rechnung ===");
            Console.WriteLine();

            Rechnung rechnung = new Rechnung("2026-014");
            rechnung.SetzeKunde("Ada Berger", "ada@example.ch");
            rechnung.Hinzufuegen("Kugelschreiber", 2, 2.50m);
            rechnung.Hinzufuegen("Notizblock", 1, 4.00m);
            rechnung.SetzeTageUeberfaellig(20);

            rechnung.KundeAusgeben();
            rechnung.AlsText();
            Console.WriteLine();
            rechnung.AlsCsv();
            Console.WriteLine();
            rechnung.MahnungAusgeben();
            rechnung.SendeEmail();
            rechnung.Speichern();

            Console.ReadLine();
        }
    }
}
