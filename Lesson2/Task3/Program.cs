// creating list of customers
var customers = new List<Customer>()
{
    new Customer("Egor",      20, "Adress1"),
    new Customer("Vlad",      25, "Adress2"),
    new Customer("Fedor",     58, "Adress3"),
    new Customer("Marina",    35, "Adress4"),
    new Customer("Anastasia", 14, "Adress5"),
    new Customer("Egor",       8, "Adress6"),
    new Customer("Marina",    27, "Adress7"),
    new Customer("Egor",      22, "Adress8"),
    new Customer("Vlad",      24, "Adress9"),
    new Customer("Marina",    19, "Adress10")
};

// getting name
var names = (from customer in customers where customer.Age > 18 select customer.Name).Distinct().ToList();
Console.WriteLine($"Enter name that you`d like to get ({ListToString(names)}):");
string customerName = Console.ReadLine();

// logging result
if (names.Contains(customerName))
{
    var customersWithName = from customer in customers where customer.Name == customerName & customer.Age > 18 select customer;
    Console.WriteLine($"18+ customers with name {customerName} ({customersWithName.Count()} customers):");
    foreach(var customer in customersWithName)
    {
        Console.Write($"Name: {customer.Name}, ");
        Console.Write($"Age: {customer.Age}, ".PadRight(10));
        Console.WriteLine($"Adderess: {customer.Address}");
    }
}
else
    Console.WriteLine($"No 18+ customers with name '{customerName}'.");

// function for converting list in string
string ListToString<T>(List<T> list)
{
    if (list.Count == 0)
        return "";

    if (list.Count == 1)
        return list[0].ToString();

    string result = list[0].ToString();
    for(int i = 1; i < list.Count - 1; i++)
    {
        result += $", {list[i].ToString()}";
    }
    result += $" and {list[list.Count - 1].ToString()}";
    return result;
}

// class for customers
class Customer
{
    public string Name { get; }
    public int Age { get; }
    public string Address { get; }
   
    public Customer(string name, int age, string address)
    {
        Name = name;
        Age = age;
        Address = address;
    }
}
