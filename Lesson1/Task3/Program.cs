List<int> GetListFromConsole(int count = 1)
{
    var list = new List<int>();
    for (int i = 0; i < count; i++)
    {
        try
        {
            Console.Write($"Enter your {i + 1} number: ");
            list.Add(Int32.Parse(Console.ReadLine()));
        }
        catch
        {
            Console.WriteLine("Bad number :(, try again!");
            i--;
        }
    }
    return list;
}


void PrintListToConsole<T>(List<T> list, string listName = "List")
{
    if (list.Count == 0)
    {
        Console.WriteLine($"{listName} is empty!");
    }
    else
    {
        Console.WriteLine($"{listName}: ");
        for (int i = 0; i < list.Count - 1; i++)
        {
            Console.Write($"{list[i]}, ");
        }
        Console.WriteLine($"{list[list.Count - 1]}.");
    }
}


const int count = 10;
List<int> userList = GetListFromConsole(count);
List<int> dubicatedList = new List<int>();
PrintListToConsole(userList, "User list");
int dublNum;
while (true)
{
    try
    {
        Console.Write("Enter number for dublication: ");
        dublNum = Int32.Parse(Console.ReadLine());
        break;
    }
    catch
    {
        Console.WriteLine("Bad number :(, try again!");
    }
}
foreach (int number in userList)
{
    dubicatedList.Add(number);
    if (number == dublNum)
    {
        dubicatedList.Add(number);
    }
}
PrintListToConsole(dubicatedList, "Dublicated list");
