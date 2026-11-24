using System;

namespace Konto
{
    public class Bankschalter
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Sparkonto ===");
            Sparkonto sparkonto = new Sparkonto("60-5678-00", 1);

            sparkonto.einzahlen(1000);
            sparkonto.auszug();
            if (!sparkonto.abheben(2000))
            {
                Console.WriteLine("Kontostand ungenügend.");
            }

            sparkonto.abheben(500);
            sparkonto.auszug();
            sparkonto.saldieren();
            sparkonto.auszug();

            Console.WriteLine();
            Console.WriteLine("=== Waehrungskonto ===");
            Waehrungskonto waehrungskonto = new Waehrungskonto("70-1234-00", "EUR");

            waehrungskonto.einzahlen(2500);
            waehrungskonto.auszug();
            if (!waehrungskonto.abheben(400))
            {
                Console.WriteLine("Kontostand ungenügend.");
            }
            waehrungskonto.auszug();

            Console.WriteLine();
            Console.WriteLine("=== Aufruf über eine Konto-Variable ===");
            Konto alsKonto = waehrungskonto;
            alsKonto.auszug();

            Console.ReadLine();
        }
    }
}
