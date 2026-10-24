using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uebung251
{
    
    /// <summary>
    /// Class D with function D (Uebung 251 b))
    /// </summary>
    public class ClassD
    {
      public void functionD()
      {
      	Console.WriteLine("funtionD called.");
      }
    }
    
    
    /// <summary>
    /// Class A with function A (Uebung 251 a) b))
    /// </summary>
    public class ClassA : ClassC
    {
        /// <summary>
        /// Aggregation to ClassB
        /// </summary>
        private ClassB mClassB;
        /// <summary>
        /// Komposition to ClassD
        /// </summary>
        private ClassD mClassD = new ClassD();

        private bool _Test;

        

        public ClassB classB
        {
            get { return mClassB; }
        }

        public ClassD classD
        {
            get { return mClassD; }
        }

        public bool Test
        {
            get { return _Test; }
        }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="classB"></param>
        public ClassA(ClassB classB)
        {
            mClassB = classB;
            _Test = false;
        }

        /// <summary>
        /// Function A
        /// </summary>
        public void functionA()
        {
            mClassD.functionD();
            Console.WriteLine("funtionA called.");
        }
    }
}
