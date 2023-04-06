using Task4.Interfaces;

namespace Task4.Vehicles;

public class Motocycle : Vehicle
{
    public Motocycle() { }
    
    public override void StartEngine()
    {
        Console.WriteLine("Motocycle:");
        base.StartEngine();
    }
}
