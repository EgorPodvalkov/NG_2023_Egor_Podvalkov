namespace Task2;

public class MagicClass
{
    private static Dictionary<int, string> _magicResponces = new Dictionary<int, string>()
    {
        {150, "Wow, your magic is fire magic!"},
        {50000000, "Incredible! You have 50 millions of power! It's water magic!"}
    }; 

    public static void CountYourMagic(int magic)
    {
        if (_magicResponces.TryGetValue(magic, out var response))
            Console.WriteLine(response);
        else
            Console.WriteLine("I understand you...");
    }
}
