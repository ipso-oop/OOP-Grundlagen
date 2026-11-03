using System;

namespace BeispieleOOPKonzepte
{

/// <summary>
/// Delegate ButtonClickedHandler
/// </summary>
public delegate void ButtonClickedHandler();

public delegate void ButtonSpecialHandler(int integer);

/// <summary>
/// Class Button event producer class
/// </summary>
public class Button
{
    public event ButtonClickedHandler ButtonClicked;

    public event ButtonSpecialHandler ButtonSpecialClick;

    public void SimulateClick()
    {
        if (ButtonClicked != null)
        {
           ButtonClicked();
        }
    }

    public void FireSpecialButtonEvent()
    {
        ButtonSpecialClick(1);
    }
    
}

/// <summary>
/// Class Client event consumer class
/// </summary>
public class Client
{
    public void MyHandler()
    {
        Console.WriteLine("MyHandler called.");
    }

    public void MyHandler(int integer)
    {
        Console.WriteLine("MyHandler called. Integer: "+integer);
    }

   
}



   
}
