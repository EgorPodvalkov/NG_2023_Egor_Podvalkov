using Task4.Interfaces;

namespace Task4.Vehicles;

public class Airplane : Vehicle, IFlyable
{
    public Airplane() { }

    public override void StartEngine()
    {
        Console.WriteLine("Airplane:");
        base.StartEngine();
    }

    public void Fly() 
    {
        Console.WriteLine("It`s flying!");
    }
}
