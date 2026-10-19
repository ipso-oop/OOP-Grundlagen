using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uebung251
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

        string Name
        {
            get { return _Name; }
        }
    }

    public class Gebaeude
    {
        private Raum _Raum = new Raum("Wohnzimmer");

        Raum Raum
        {
            get { return _Raum; }
        }

    }
}
