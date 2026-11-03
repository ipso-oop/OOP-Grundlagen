
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BeispieleOOPKonzepte
{

    /// <summary>
    /// Interface for rotateable shapes
    /// </summary>
    interface IRotateable
    {
        void Rotate(double theta);
    }

    /// <summary>
    /// Interfacel for drawable shapes
    /// </summary>
    interface IDrawable : IRotateable
    {
        void Draw();
    }

    /// <summary>
    /// Interace for a shape
    /// </summary>
    interface IShape
    {
        double X { get; set; }
        double Y { get; set; }
        void Draw();
    }

    /// <summary>
    /// The square class which implements the interface IShape
    /// </summary>
    class Square : IRotateable
    {
        private double mX, mY;

        /// <summary>
        /// Function Draw. Draws the object
        /// </summary>
        public void Draw()
        {
            Console.WriteLine("Draws the object: " + this.ToString());
        }

        /// <summary>
        /// Function Rotate. Rotates the object
        /// </summary>
        /// <param name="theta"></param>
        public void Rotate(double theta)
        {
            Console.WriteLine("Rotate the object: Theta: " + theta.ToString());
        }

        /// <summary>
        /// Accessor for the x point value
        /// </summary>
        public double X
        {
            set { mX = value; }
            get { return mX; }
        }

        /// <summary>
        /// Accessor for the y point value
        /// </summary>
        public double Y
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
            IRotateable shape = new Square();
           
            shape.Rotate(50.0);

            Thread.Sleep(5000);
            
        }




    }
}
