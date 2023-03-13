try
{
    Console.Write("Enter your number: ");
    int number = Int32.Parse(Console.ReadLine());
    Console.WriteLine($"Your number + 10 is {number + 10}");
}
catch
{
    Console.WriteLine("Bad number :(");
}
