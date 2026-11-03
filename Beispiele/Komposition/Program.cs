using System;

namespace BeispieleOOPKonzepte
{
    /// <summary>
    /// Lernziel: Komposition, also "hat ein" statt "ist ein".
    /// Teil 1 zeigt Ganzes und Teile an einer Bestellung.
    /// Teil 2 zeigt, wann ein austauschbares Teil die bessere Modellierung
    /// ist als eine neue Unterklasse.
    /// </summary>
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Komposition, Teil 1: Ganzes und Teile ===");
            Console.WriteLine("Die Bestellung erzeugt ihre Positionen.");
            Console.WriteLine("Die Waren gibt es auch ohne diese Bestellung.");
            Console.WriteLine();

            Ware stift = new Ware("Kugelschreiber", 2.50m);
            Ware block = new Ware("Notizblock", 4.00m);

            Bestellung bestellung = new Bestellung("2026-014");
            bestellung.Hinzufuegen(stift, 2);
            bestellung.Hinzufuegen(block, 1);
            bestellung.Ausgeben();

            Console.WriteLine();
            Console.WriteLine("Dieselbe Ware kann auf einer zweiten Bestellung stehen.");
            Bestellung weitere = new Bestellung("2026-015");
            weitere.Hinzufuegen(stift, 5);
            weitere.Ausgeben();

            Console.WriteLine();
            Console.WriteLine("=== Komposition, Teil 2: Hat-ein statt Ist-ein ===");
            Console.WriteLine("Derselbe Fahrzeugtyp, zwei Antriebe, keine neuen Unterklassen.");
            Console.WriteLine();

            Fahrzeug familie = new Fahrzeug("Familienwagen", new Benzinmotor());
            Fahrzeug stadt = new Fahrzeug("Stadtwagen", new Elektromotor());
            familie.Losfahren();
            Console.WriteLine();
            stadt.Losfahren();

            Console.ReadLine();
        }
    }
}
