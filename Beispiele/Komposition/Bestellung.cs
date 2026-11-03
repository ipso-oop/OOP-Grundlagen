using System;
using System.Collections.Generic;

namespace BeispieleOOPKonzepte
{
    /// <summary>
    /// Ware existiert für sich. Mehrere Bestellungen können dieselbe Ware nennen.
    /// Das ist eine Aggregation: das Teil lebt auch ohne das Ganze.
    /// </summary>
    public class Ware
    {
        public Ware(string bezeichnung, decimal einzelpreis)
        {
            if (string.IsNullOrWhiteSpace(bezeichnung))
            {
                throw new ArgumentException("Die Bezeichnung darf nicht leer sein.");
            }

            if (einzelpreis < 0)
            {
                throw new ArgumentException("Der Einzelpreis darf nicht negativ sein.");
            }

            Bezeichnung = bezeichnung.Trim();
            Einzelpreis = einzelpreis;
        }

        public string Bezeichnung { get; private set; }

        public decimal Einzelpreis { get; private set; }
    }

    /// <summary>
    /// Eine Position gehört zu einer Bestellung.
    /// Die Bestellung erzeugt sie. Ohne Bestellung wird keine Position angelegt.
    /// </summary>
    public class Position
    {
        public Position(Ware ware, int menge)
        {
            if (ware == null)
            {
                throw new ArgumentNullException("ware");
            }

            if (menge <= 0)
            {
                throw new ArgumentException("Die Menge muss grösser als 0 sein.");
            }

            Ware = ware;
            Menge = menge;
        }

        public Ware Ware { get; private set; }

        public int Menge { get; private set; }

        public decimal Betrag
        {
            get { return Ware.Einzelpreis * Menge; }
        }
    }

    /// <summary>
    /// Die Bestellung ist das Ganze, die Positionen sind die Teile.
    /// Die Summe berechnet nicht die Bestellung selbst Zeile für Zeile aus den
    /// Waren, sondern jede Position liefert ihren Betrag (Delegation).
    /// </summary>
    public class Bestellung
    {
        private readonly List<Position> positionen = new List<Position>();

        public Bestellung(string nummer)
        {
            if (string.IsNullOrWhiteSpace(nummer))
            {
                throw new ArgumentException("Die Nummer darf nicht leer sein.");
            }

            Nummer = nummer.Trim();
        }

        public string Nummer { get; private set; }

        public void Hinzufuegen(Ware ware, int menge)
        {
            positionen.Add(new Position(ware, menge));
        }

        public decimal Gesamtbetrag()
        {
            decimal summe = 0m;
            foreach (Position position in positionen)
            {
                summe += position.Betrag;
            }

            return summe;
        }

        public void Ausgeben()
        {
            Console.WriteLine("Bestellung " + Nummer);
            foreach (Position position in positionen)
            {
                Console.WriteLine(
                    "  " + position.Menge + " x " + position.Ware.Bezeichnung
                    + " à " + position.Ware.Einzelpreis.ToString("0.00")
                    + "    " + position.Betrag.ToString("0.00") + " CHF");
            }

            Console.WriteLine("Gesamt: " + Gesamtbetrag().ToString("0.00") + " CHF");
        }
    }
}
