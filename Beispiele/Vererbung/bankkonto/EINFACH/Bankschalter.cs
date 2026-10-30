using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Konto
{
    public class BankschalterKorrekt
    {
        public static void Main(string[] args)
        {
            Sparkonto kontoA = new Sparkonto("60-5678-00", 1);

            kontoA.einzahlen(1000);
            kontoA.auszug();
            if(!kontoA.abheben(2000))
            {
                Console.WriteLine("Kontostand ungenügend.");
            }

            kontoA.abheben(500);
            kontoA.auszug();
            kontoA.saldieren();
            kontoA.auszug();

            Console.ReadLine();
        }
    }
}
