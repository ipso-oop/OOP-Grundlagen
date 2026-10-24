using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uebung251
{
    
    interface InterfaceC
    {
    	void functionC();
    }
    
    /// <summary>
    /// Class C with function c (Uebung 251 c))
    /// </summary>
    public class ClassC : InterfaceC
    {
        /// <summary>
        /// Function C
        /// </summary>
        public void functionC()
        {
            Console.WriteLine("funtionC called.");
        }
    }
}
