using System;

namespace BeispieleOOPKonzepte
{
    public class Drucker
    {
        /// <summary>
        /// Bewusst nicht virtual. Eine Methode gleichen Namens in der
        /// Unterklasse verdeckt diese Methode nur.
        /// </summary>
        public void Status()
        {
            Console.WriteLine("Drucker bereit");
        }

        public virtual void Drucken()
        {
            Console.WriteLine("Drucker druckt schwarz");
        }
    }

    public class Farbdrucker : Drucker
    {
        /// <summary>
        /// new verdeckt Status(). Beim Aufruf zählt der Typ der Variablen,
        /// nicht der Typ des Objekts.
        /// </summary>
        public new void Status()
        {
            Console.WriteLine("Farbdrucker bereit");
        }

        /// <summary>
        /// override ersetzt Drucken(). Beim Aufruf zählt der Typ des Objekts.
        /// </summary>
        public override void Drucken()
        {
            Console.WriteLine("Farbdrucker druckt in Farbe");
        }
    }
}
