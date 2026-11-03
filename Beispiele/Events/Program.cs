using System;

namespace BeispieleOOPKonzepte
{
    class Program
    {
        static void Main()
        {
            Button b = new Button();
            Client c = new Client();
            b.ButtonClicked += c.MyHandler;
            b.ButtonSpecialClick += c.MyHandler;

            b.SimulateClick();
            b.FireSpecialButtonEvent();

            Console.ReadLine();
        }
    }
}
