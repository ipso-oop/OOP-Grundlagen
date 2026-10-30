using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    interface IShape
    {
        double X { get; set; }
        double Y { get; set; }
        void Draw();
    }


    class Square : IShape
    {
        private double _mX, _mY;
        public void Draw() { }
        public double X
        {
            set { _mX = value; }
            get { return _mX; }
        }
        public double Y
        {
            set { _mY = value; }
            get { return _mY; }
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            IShape shape = new Square();
           

            shape.Draw();
          

        }
    }
}
