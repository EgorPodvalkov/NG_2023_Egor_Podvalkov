using Task2.Interfaces;

namespace Task2.Magic;

public class MagicClass : IMagicCounter
{
    public void CountYourMagic(int magic)
    {
        Console.WriteLine("I understand you...");
    }
}
