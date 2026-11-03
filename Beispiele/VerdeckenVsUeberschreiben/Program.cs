using System;

namespace BeispieleOOPKonzepte
{
    /// <summary>
    /// Lernziel: Verdecken mit new und Überschreiben mit override.
    /// Beide Methoden der Unterklasse heissen gleich wie in der Basisklasse.
    /// Trotzdem läuft über eine Variable vom Typ Drucker nur Drucken()
    /// in der Unterklasse. Status() bleibt die Methode der Basisklasse.
    ///
    /// Derselbe Effekt steht im Konto-Beispiel: Sparkonto.auszug() ist weder
    /// virtual noch override. Ein Aufruf über eine Konto-Variable zeigt deshalb
    /// den Auszug der Basisklasse, ohne Zinssatz.
    /// </summary>
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Verdecken (new) und Überschreiben (override) ===");
            Console.WriteLine();

            Farbdrucker farbe = new Farbdrucker();

            Console.WriteLine("Variable vom Typ Drucker, Objekt ist ein Farbdrucker:");
            Drucker alsDrucker = farbe;
            Console.Write("  Status()  -> ");
            alsDrucker.Status();
            Console.Write("  Drucken() -> ");
            alsDrucker.Drucken();

            Console.WriteLine();
            Console.WriteLine("Dasselbe Objekt, Variable vom Typ Farbdrucker:");
            Console.Write("  Status()  -> ");
            farbe.Status();
            Console.Write("  Drucken() -> ");
            farbe.Drucken();

            Console.WriteLine();
            Console.WriteLine("Ein normales Drucker-Objekt bleibt bei seiner eigenen Methode:");
            Drucker normal = new Drucker();
            Console.Write("  Drucken() -> ");
            normal.Drucken();

            Console.WriteLine();
            Console.WriteLine("Merksatz: Bei new entscheidet der Typ der Variablen.");
            Console.WriteLine("Bei override entscheidet der Typ des Objekts.");
            Console.ReadLine();
        }
    }
}
