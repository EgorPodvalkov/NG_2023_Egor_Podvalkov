namespace Task2;

public class MagicClass
{

    public virtual void CountYourMagic(int magic)
    {
        Console.WriteLine("I understand you...");
    }
}

public class FireMagic: MagicClass
{
    public override void CountYourMagic(int magic)
    {
        if (magic == 150)
            Console.WriteLine("Wow, your magic is fire magic!");
        else
            base.CountYourMagic(magic);
    }
}

public class WatherMagic: MagicClass
{
    public override void CountYourMagic(int magic)
    {
        if (magic == 50000000)
            Console.WriteLine("Incredible! You have 50 millions of power! It's water magic!");
        else
            base.CountYourMagic(magic);
    }
}
