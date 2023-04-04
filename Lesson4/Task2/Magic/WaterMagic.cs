using Task2.Interfaces;

namespace Task2.Magic;

public class WaterMagic : IMagicCounter
{
    public void CountYourMagic(int magic)
    {
        Console.WriteLine($"Incredible! You have {magic} of power! It's water magic!");
    }
}
