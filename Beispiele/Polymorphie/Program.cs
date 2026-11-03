using System;
using System.Collections.Generic;

namespace BeispieleOOPKonzepte
{
    /// <summary>
    /// Lernziel: Polymorphie.
    /// Eine Liste vom Typ der Basisklasse enthält unterschiedliche Objekte.
    /// Der Aufruf ist immer person.Auszahlen(). Welche Lohnformel rechnet,
    /// entscheidet der konkrete Typ des Objekts, nicht der Typ der Variablen.
    /// </summary>
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Polymorphie ===");
            Console.WriteLine("Der Lohnlauf kennt nur den Typ Mitarbeiter.");
            Console.WriteLine();

            List<Mitarbeiter> team = new List<Mitarbeiter>();
            team.Add(new Festangestellter("Ada Berger", 6500m));
            team.Add(new StundenlohnEmpfaenger("Ben Meier", 45m, 80m));
            team.Add(new ProvisionsEmpfaenger("Cem Yilmaz", 2000m, 12000m, 0.10m));

            decimal summe = 0m;
            foreach (Mitarbeiter person in team)
            {
                summe += person.Auszahlen();
            }

            Console.WriteLine();
            Console.WriteLine("Lohnsumme: " + summe.ToString("0.00") + " CHF");
            Console.WriteLine();
            Console.WriteLine("Die Schleife prüft den Typ nicht.");
            Console.WriteLine("Eine weitere Mitarbeiterart braucht nur eine neue Unterklasse");
            Console.WriteLine("mit einer eigenen BerechneLohn-Methode.");
            Console.ReadLine();
        }
    }
}
