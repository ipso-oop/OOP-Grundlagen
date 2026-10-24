using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uebung251
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ClassB mClassB = new ClassB();//Instance ClassB
            ClassA mClassA = new ClassA(mClassB);//Instance ClassA
            ClassC mClassC = new ClassC();//Instance ClassC

            mClassA.functionA();
            mClassA.functionC();
            mClassB.functionB();
            mClassC.functionC();

            while (true);

           
        }
    }
}
