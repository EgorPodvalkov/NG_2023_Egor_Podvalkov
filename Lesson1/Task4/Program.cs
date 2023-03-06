string GetStringFromConsole(string message = "Enter your string: ")
{
    string str;
    Console.Write(message);
    str = Console.ReadLine();
    if (str == null)
    {
        return "";
    }
    return str;
}

string str1 = GetStringFromConsole("Enter first string: ");
string str2 = GetStringFromConsole("Enter second string: ");

if (str1.Length > str2.Length)
{
    Console.WriteLine("First string is longer then second one, so result is:");
    Console.WriteLine(str1 + str2);
}
else if (str1.Length < str2.Length)
{
    Console.WriteLine("First string is shorter then second one, so result is:");
    try
    {
        string[] result = str2.Split(str1[0]);
        for(int i = 0; i < result.Length; i++) 
        {
            Console.WriteLine($"Part {i + 1}: {result[i]}");
        }
    }
    catch
    {
        Console.WriteLine("Something wrong :(");
    }
}
else
{
    Console.WriteLine("Strings are equal, so result is :\n*some void");
}
