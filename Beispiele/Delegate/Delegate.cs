
using System;

namespace BeispieleOOPKonzepte
{

/// <summary>
/// Delegate Definition
/// </summary>
delegate void Procedure();

/// <summary>
/// Class DelegateDemo
/// </summary>
class DelegateDemo
{
    public static void Method1()
    {
        Console.WriteLine("Method 1");
    }

    public static void Method2()
    {
        Console.WriteLine("Method 2");
    }

    public void Method3()
    {
        Console.WriteLine("Method 3");
    }

    static void Main()
    {
        Procedure someProcs = null;

        someProcs += DelegateDemo.Method1;
        someProcs += Method2;  // Example with omitted class name

        DelegateDemo demo = new DelegateDemo();

        someProcs += demo.Method3;
        someProcs();

        someProcs -= Method1;

        someProcs();

        Console.ReadLine();
    }
}



   
}
