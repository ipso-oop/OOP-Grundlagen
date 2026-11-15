using System;
using System.Collections.Generic;

namespace Sumo
{
    /// <summary>
    /// Ein Datensatz im InMemoryDb.
    /// Spalten ohne Verhalten. View und InMemoryDb schreiben sie beide.
    /// Grundbeitrag ist der Wert, den die InMemoryDb beim Einfuegen ablegt.
    /// </summary>
    public class Vereinsdatensatz
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Stufe { get; set; }

        public int Jahre { get; set; }

        public bool Bezahlt { get; set; }

        public decimal Grundbeitrag { get; set; }
    }

    /// <summary>
    /// In-Memory-Datenbank: Datensätze und Prozeduren, ohne SQL.
    /// Einfuegen prüft die Eingabe und schreibt den Grundbeitrag in den Datensatz.
    /// Dieselben Prüfungen stehen noch einmal in der VereinsView.
    /// </summary>
    public class InMemoryDb
    {
        private readonly List<Vereinsdatensatz> datensaetze = new List<Vereinsdatensatz>();

        public List<Vereinsdatensatz> Datensaetze
        {
            get { return datensaetze; }
        }

        public void Einfuegen(string name, string email, string stufe, int jahre, bool bezahlt)
        {
            Pruefe(name, email, stufe, jahre);

            Vereinsdatensatz datensatz = new Vereinsdatensatz();
            datensatz.Name = name;
            datensatz.Email = email;
            datensatz.Stufe = stufe;
            datensatz.Jahre = jahre;
            datensatz.Bezahlt = bezahlt;
            datensatz.Grundbeitrag = Grundbeitrag(stufe);
            datensaetze.Add(datensatz);
        }

        public decimal Grundbeitrag(string stufe)
        {
            if (stufe == "Aktiv")
            {
                return 80m;
            }

            if (stufe == "Jugend")
            {
                return 40m;
            }

            if (stufe == "Passiv")
            {
                return 20m;
            }

            return 0m;
        }

        public string OffenerText(decimal beitrag)
        {
            return "Beitrag " + beitrag.ToString("0.00") + " CHF noch offen.";
        }

        private void Pruefe(string name, string email, string stufe, int jahre)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Der Name darf nicht leer sein.");
            }

            if (string.IsNullOrWhiteSpace(email) || email.IndexOf('@') <= 0 || email.EndsWith("@"))
            {
                throw new ArgumentException("Die E-Mail muss ein @ enthalten.");
            }

            if (stufe != "Aktiv" && stufe != "Jugend" && stufe != "Passiv")
            {
                throw new ArgumentException("Unbekannte Stufe.");
            }

            if (jahre < 0)
            {
                throw new ArgumentException("Die Jahre dürfen nicht negativ sein.");
            }
        }
    }

    /// <summary>
    /// Fette View, verheiratet mit der InMemoryDb.
    /// Der Zuschlag und die Mahnstufe stehen hier, der Grundbeitrag in der InMemoryDb.
    /// Die Prüfung von Name, E-Mail, Stufe und Jahren steht in beiden Klassen.
    /// </summary>
    public class VereinsView
    {
        private readonly InMemoryDb inMemoryDb = new InMemoryDb();

        public void Erfasse(string name, string email, string stufe, int jahre, bool bezahlt)
        {
            Pruefe(name, email, stufe, jahre);
            inMemoryDb.Einfuegen(name, email, stufe, jahre, bezahlt);
        }

        public decimal Zuschlag(Vereinsdatensatz datensatz)
        {
            if (datensatz.Stufe == "Aktiv")
            {
                return 10m * datensatz.Jahre;
            }

            return 0m;
        }

        public void Ausgeben()
        {
            Console.WriteLine("=== Verein ===");
            Console.WriteLine();

            int anzahl = 0;
            decimal offen = 0m;
            foreach (Vereinsdatensatz datensatz in inMemoryDb.Datensaetze)
            {
                decimal beitrag = datensatz.Grundbeitrag + Zuschlag(datensatz);
                string status = "offen";
                if (datensatz.Bezahlt)
                {
                    status = "bezahlt";
                }

                Console.WriteLine(
                    datensatz.Name + ", " + datensatz.Email + ", " + datensatz.Stufe + ", "
                    + JahreText(datensatz.Jahre) + ", " + beitrag.ToString("0.00") + " CHF, " + status);

                string mahnung = Mahnung(datensatz, beitrag);
                if (mahnung != null)
                {
                    Console.WriteLine("  " + mahnung);
                }

                anzahl = anzahl + 1;
                if (!datensatz.Bezahlt)
                {
                    offen = offen + beitrag;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Mitglieder: " + anzahl);
            Console.WriteLine("Offen: " + offen.ToString("0.00") + " CHF");
        }

        private string Mahnung(Vereinsdatensatz datensatz, decimal beitrag)
        {
            if (datensatz.Bezahlt || datensatz.Jahre < 1)
            {
                return null;
            }

            string text = inMemoryDb.OffenerText(beitrag);
            if (datensatz.Jahre > 2)
            {
                return "Letzte Erinnerung: " + text;
            }

            return "Erinnerung: " + text;
        }

        private string JahreText(int jahre)
        {
            if (jahre == 1)
            {
                return "1 Jahr";
            }

            return jahre + " Jahre";
        }

        private void Pruefe(string name, string email, string stufe, int jahre)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Der Name darf nicht leer sein.");
            }

            if (string.IsNullOrWhiteSpace(email) || email.IndexOf('@') <= 0 || email.EndsWith("@"))
            {
                throw new ArgumentException("Die E-Mail muss ein @ enthalten.");
            }

            if (stufe != "Aktiv" && stufe != "Jugend" && stufe != "Passiv")
            {
                throw new ArgumentException("Unbekannte Stufe.");
            }

            if (jahre < 0)
            {
                throw new ArgumentException("Die Jahre dürfen nicht negativ sein.");
            }
        }
    }

    /// <summary>
    /// Aufgabe: Sumo-Hochzeit.
    /// Eine fette View hängt an einer noch fetteren InMemoryDb.
    /// Die InMemoryDb hält Datensätze, Spalten und Prozeduren, ohne SQL.
    ///
    /// Der Grundbeitrag steht in InMemoryDb.Grundbeitrag.
    /// Der Zuschlag steht in VereinsView.Zuschlag.
    /// Die Mahnstufe steht in der View, der Mahnungstext in der InMemoryDb.
    /// Name, E-Mail, Stufe und Jahre werden zweimal geprüft.
    /// Eine neue Stufe, zum Beispiel Ehrenmitglied, muss an vier Stellen nachgezogen werden:
    /// beide Pruefe-Methoden, Grundbeitrag und Zuschlag.
    /// Fehlt eine Stelle, kompiliert das Programm und rechnet falsch oder lehnt falsch ab.
    ///
    /// Umbau, die Ausgabe bleibt gleich:
    /// - Mitglied kennt Prüfung, Grundbeitrag, Zuschlag und Mahnung
    /// - Datensatz speichert nur die Spalten, ohne Grundbeitrag
    /// - InMemoryDb legt Datensätze ab und gibt sie zurück, ohne Formel
    /// </summary>
    class Program
    {
        static void Main()
        {
            VereinsView view = new VereinsView();
            view.Erfasse("Ada Berger", "ada@verein.ch", "Aktiv", 3, false);
            view.Erfasse("Ben Meier", "ben@verein.ch", "Jugend", 1, true);
            view.Erfasse("Clara Huber", "clara@verein.ch", "Passiv", 2, false);
            view.Ausgeben();
            Console.WriteLine();

            try
            {
                view.Erfasse("Dan Berger", "danverein.ch", "Aktiv", 1, false);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("danverein.ch abgelehnt: " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}
