using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UebungPerson
{
    /// <summary>
    /// Raum & Gebäude als Komposition
    /// </summary>
    public class Raum
    {
        private string _Name;

        public Raum(string name)
        {
            _Name = name;
        }

        public string Name
        {
            get { return _Name; }
        }
    }

    public class Gebaeude
    {
        private Raum _Raum = new Raum("Wohnzimmer");

        public Raum Raum
        {
            get { return _Raum; }
        }

    }
}
