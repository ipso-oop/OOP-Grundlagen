using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UebungPerson
{
    
    public class Person
    {
        private string _Name;
        private string _Vorname;

        public string Name
        {
            get { return _Name; }
        }

        public string Vorname
        {
            get { return _Vorname; }
        }


    }
    
    /// <summary>
    /// Class Privakunde erbt Klasse Person
    /// </summary>
    public class Privatkunde : Person
    {
        private int _Kundennummer;

        public int Kundennummer
        {
            get { return _Kundennummer; }
        }

    }
}

