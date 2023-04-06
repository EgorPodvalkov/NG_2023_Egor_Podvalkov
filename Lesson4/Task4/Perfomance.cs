using Task4.Vehicles;

namespace Task4;

public static class Perfomance
{
    public static void PerformActions()
    {
        var car = new Car();
        var motocycle = new Motocycle();
        var airplane = new Airplane();

        car.StartEngine();

        motocycle.StartEngine();

        airplane.StartEngine();
        airplane.Fly();
    }
}
