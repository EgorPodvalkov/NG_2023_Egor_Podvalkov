using Task2.Interfaces;

namespace Task2.Magic;

public class WaterMagic : IMagicCounter
{
    public void CountYourMagic(int magic)
    {
        if (magic == 50000000)
            Console.WriteLine("Incredible! You have 50 millions of power! It's water magic!");
    }
}
