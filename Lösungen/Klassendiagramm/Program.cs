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
            Privatkunde kunde = new Privatkunde();

            Gebaeude gebaeude = new Gebaeude();

            Student student = new Student("Roman");

            Vorlesung vorlesung = new Vorlesung(student);

            WaermeSensor waermesensor = new WaermeSensor();
            


           
        }
    }
}
