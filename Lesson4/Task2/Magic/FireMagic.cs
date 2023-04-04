using Task2.Interfaces;

namespace Task2.Magic;

public class FireMagic : IMagicCounter
{
    public void CountYourMagic(int magic)
    {
        if (magic == 150)
            Console.WriteLine("Wow, your magic is fire magic!");
    }
}
