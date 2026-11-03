
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BeispieleOOPKonzepte
{

    /// <summary>
    /// Abstrakte Klasse
    /// </summary>
    public abstract class AbstractShape
    {
        public abstract void Draw();

        public void Rotate()
        {
            Console.WriteLine("Function Rotate");
        }
        public abstract double X { get; set; }
        public abstract double Y { get; set; }
    }


    /// <summary>
    /// The square class which implements the abstract class "AbstractShape"
    /// </summary>
    class Square : AbstractShape
    {
        private double mX, mY;

        /// <summary>
        /// Function Draw. Draws the object
        /// </summary>
        public override void Draw()
        {
            Console.WriteLine("Draws the object: " + this.ToString());
        }

        /// <summary>
        /// Accessor for the x point value
        /// </summary>
        public override double X
        {
            set { mX = value; }
            get { return mX; }
        }

        /// <summary>
        /// Accessor for the y point value
        /// </summary>
        public override double Y
        {
            set { mY = value; }
            get { return mY; }
        }

        /// <summary>
        /// Main function
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {  
            AbstractShape shape = new Square();
            shape.Draw();
            shape.Rotate();

            Thread.Sleep(5000);
            
        }




    }
}
