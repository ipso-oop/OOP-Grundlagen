using System;
using System.Collections.Generic;
using System.Text;

namespace Sparkonto.NetApp
{
    class Program
    {
        interface IKonto
        {
            void einzahlen(double betrag);
            bool abheben(double betrag);
            void auszug();
        }
        public class Konto : IKonto
        {
            private String kontoNummer;
            private double kontoStand;

            /**
             * Konstruktor zur Initialisierung für <code>kontoNummer</code> und <code>kontoStand</code>.
             *
             * @param kontoNummer vom Typ <code>String</code> weist der <code>kontoNummer</code> 
             * einen alphnummerischen Wert zu.
             * @param kontoStand vom Typ <code>double</code> weist dem <code>kontoStand</code> 
             * einen nummerischen Wert zu.
             */
            public Konto(String kontoNummer, double kontoStand)
            {
                this.kontoNummer = kontoNummer;
                this.kontoStand = kontoStand;
                Console.WriteLine("Konto initialisiert");
            }

            /**
             * Konstruktor zur Initialisierung für <code>kontoNummer</code>. Der <code>kontoStand</code> wird mit Null 
             * initialisiert
             *
             * @param kontoNummer vom Typ <code>String</code> weist der <code>kontoNummer</code> 
             * einen alphnummerischen Wert zu.
             */
            public Konto(String kontoNummer)
            {
                this.kontoNummer = kontoNummer;
                this.kontoStand = 0;
            }

            /**
             * Methode <code>einzahlen</code> erhöht den <code>kontoStand</code> um den Betrag der als
             * Parameter angegeben wird
             *
             * @param betrag vom Typ <code>double</code> erhöht dem <code>kontoStand</code>.
             */
            public void einzahlen(double betrag)
            {
                kontoStand += betrag;
            }

            /**
             * Methode <code>abheben</code> reduziert den <code>kontoStand</code> um den Betrag der als
             * Parameter angegeben wird. Es kann maximal der Betrag abgehoben werden, der dem 
             * <code>kontoStand</code> entspricht.
             *
             * @param betrag vom Typ <code>double</code> reduziert dem <code>kontoStand</code>.
             */
            public bool abheben(double betrag)
            {
                bool valid = kontoStand - betrag > 0;
                if (valid)
                    kontoStand -= betrag;
                return valid;
            }

            /**
             * Methode <code>auszug</code> zeigt <code>kontoNummer</code> und <code>kontoStand</code> an.
             */
            public void auszug()
            {
                Console.WriteLine("Konto          : " + kontoNummer);
                Console.WriteLine("Kontostand Fr. : " + kontoStand);
            }

            /**
             * Methode <code>toString</code> gibt die <code>kontoNummer</code> und den <code>kontoStand</code>
             * als <code>String</code> zurück.
             */
            public string toString()
            {
                string ausgabe = "Konto " + kontoNummer + " (Kontostand " + kontoStand + ")";
                return ausgabe;
            }

            /**
             * Methode <code>gibKontoNummer</code> gibt <code>kontoNummer</code> an.
             */
            public string gibKontoNummer()
            {
                return kontoNummer;
            }

            /**
             * Methode <code>gibKontoStand</code> gibt <code>kontoStand</code> an.
             */
            public double gibKontoStand()
            {
                return kontoStand;
            }
        }


        public class Sparkonto : Konto
        {

            private double zinsSatz;

            /**
             * Konstruktor zur Initialisierung für <code>kontoNummer</code> und <code>zinsSatz</code>.
             *
             * @param kontoNummer vom Typ <code>String</code> weist der <code>kontoNummer</code> 
             * einen alphnummerischen Wert zu.
             * @param zinsSatz vom Typ <code>double</code> weist dem <code>zinsSatz</code> 
             * einen nummerischen Wert (Prozentwert) zu.
             */
            public Sparkonto(String kontoNummer, double zinsSatz) : base(kontoNummer)
            {

                this.zinsSatz = zinsSatz;
                Console.WriteLine("Sparkonto initialisiert");
            }

            /**
             * Methode <code>auszug</code> zeigt die Attribute <code>kontoNummer</code> und 
             * <code>kontoStand</code> der Klasse <code>Konto</code> an.
             * Zusätzlich werden <code>zinsSatz</code> und provisoriescher Jahreszins angezeigt.
             */
            public void auszug()
            {
                base.auszug();
                Console.WriteLine("Zinssatz       : " + zinsSatz + " %");
                Console.WriteLine("Prov.Zins Fr.  : " + zinsSatz * gibKontoStand() / 100);
            }

            /**
             * Methode <code>saldieren</code> addiert zum <code>kontoStand</code> den 
             * provisorischer Jahreszins. Dies erfolgt ohne Berücksichtigung der Konto
             * Historie.
             */
            public void saldieren()
            {
                einzahlen(zinsSatz * gibKontoStand() / 100);
            }
        }

        static void Main(string[] args)
        {
            IKonto konto = new Sparkonto("60-5678-00", 5);//TypeDefinition Typ Interface

            konto.einzahlen(1000);
            Console.WriteLine();
            konto.auszug();
            konto.abheben(500);
            Console.WriteLine();
            konto.auszug();
            ((Sparkonto)konto).saldieren();//Nicht im Interface definiert deshalb TypeCast
            konto.auszug();

            konto = new Konto("60-5678-01");//Gleiche Variable andere Instanz -> Erlaubt generische Implementierung Liskovsche Prinzip Verhalten des Obertypes ist gleich wie des Untertyps

            konto.einzahlen(1000);
            Console.WriteLine();
            konto.auszug();
            konto.abheben(500);
            Console.WriteLine();
            konto.auszug();

            Console.ReadLine();
        }
    }
}
