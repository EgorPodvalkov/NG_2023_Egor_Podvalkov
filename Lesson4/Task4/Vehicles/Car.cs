using Task4.Interfaces;

namespace Task4.Vehicles;

public class Car : Vehicle
{
    public Car() { }

    public override void StartEngine()
    {
        Console.WriteLine("Car:");
        base.StartEngine();
    }
}
