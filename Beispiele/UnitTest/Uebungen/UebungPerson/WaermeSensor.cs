using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UebungPerson
{
    
    interface ISensor
    {
        void aktivieren();
        int lesen();
    }
    
    public class WaermeSensor : ISensor
    {
        private bool _Activate = false;

        private int _Value = 0;
        
        public bool Activate
        {
            get { return _Activate; }
        }

        public int Value
        {
            get { return _Value; }
        }

        public void aktivieren()
        {
            _Activate = true;
        }

        public int lesen()
        {
            _Value = 10;
            return _Value;
        }
    }
}

