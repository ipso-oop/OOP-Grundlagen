using System;

namespace BeispieleOOPKonzepte
{
    /// <summary>
    /// Lernziel: Kapselung.
    /// Der Zustand eines Objekts ist privat. Nach aussen gibt es nur Zugänge,
    /// die die Regeln der Klasse einhalten. So kann ein Artikel keinen negativen
    /// Preis und keinen negativen Bestand annehmen, egal wer ihn benutzt.
    /// </summary>
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Kapselung ===");
            Console.WriteLine("Felder sind privat. Geändert wird nur über Properties und Methoden.");
            Console.WriteLine();

            Artikel stift = new Artikel("Kugelschreiber", 2.50m, 100);
            Console.WriteLine("Start:               " + stift);

            stift.Entnehmen(30);
            Console.WriteLine("Nach Entnahme:       " + stift);

            stift.Preis = 2.80m;
            Console.WriteLine("Nach Preisanpassung: " + stift);

            Console.WriteLine();
            Console.WriteLine("Ungültige Werte weist die Klasse selbst ab:");
            try
            {
                stift.Preis = -1m;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("  Preis = -1 -> " + ex.Message);
            }

            try
            {
                stift.Entnehmen(1000);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("  Entnehmen(1000) -> " + ex.Message);
            }

            try
            {
                new Artikel("  ", 1m, 1);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("  leerer Name -> " + ex.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Der Bestand hat keinen öffentlichen Setter.");
            Console.WriteLine("Er ändert sich nur über Einlagern und Entnehmen,");
            Console.WriteLine("weil eine freie Zuweisung die Lagerregel umgehen würde.");
            Console.WriteLine();
            Console.WriteLine("Der Lagerwert steht in keinem eigenen Feld.");
            Console.WriteLine("Er ergibt sich aus Preis mal Bestand.");
            Console.ReadLine();
        }
    }
}
