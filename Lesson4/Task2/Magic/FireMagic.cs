using Task2.Interfaces;

namespace Task2.Magic;

public class FireMagic : IMagicCounter
{
    public void CountYourMagic(int magic)
    {
            Console.WriteLine("Wow, your magic is fire magic!");
    }
}
