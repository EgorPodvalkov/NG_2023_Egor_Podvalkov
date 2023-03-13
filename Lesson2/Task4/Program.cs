// creating owners list
var owners = new List<Owner>()
{
    new Owner("Egor", "Address1"),
    new Owner("Vlad", "Address2"),
    new Owner("Fedor", "Address3"),
    new Owner("Marina", "Address4"),
    new Owner("Anastasia", "Address5"),
    new Owner("Egor", "Address6"),
    new Owner("Marina", "Address7"),
    new Owner("Vlad", "Address8"),
};

// creating cars list
var cars = new List<Car>()
{
    new Car("2033", 1),
    new Car("4013", 1),
    new Car("1234", 2),
    new Car("5431", 3),
    new Car("4278", 4),
    new Car("2467", 5),
    new Car("7642", 5),
    new Car("4215", 6),
    new Car("1316", 7),
    new Car("3023", 8)
};

// getting car number from user
var carNumbers = (from car in cars select car.Number).ToList();
Console.WriteLine($"Enter car number ({ListToString(carNumbers)}): ");
string userInput = Console.ReadLine();

// getting and logging result
if (carNumbers.Contains(userInput))
{
    var ownerId = cars.First(car => car.Number.Equals(userInput)).OwnerId;
    try
    {
        var carOwner = owners.First(owner => owner.Id.Equals(ownerId));
        Console.WriteLine($"Car Number: '{userInput}'");
        Console.WriteLine($"Owner`s Name: {carOwner.Name}");
        Console.WriteLine($"Owner`s Address: {carOwner.Address}");
    }
    catch
    {
        Console.WriteLine("No owner for this car :(");
    }
}
else
    Console.WriteLine($"No car with number '{userInput}' :(");

// function for converting list in string
string ListToString<T>(List<T> list)
{
    if (list.Count == 0)
        return "";

    if (list.Count == 1)
        return list[0].ToString();

    string result = list[0].ToString();
    for (int i = 1; i < list.Count - 1; i++)
    {
        result += $", {list[i].ToString()}";
    }
    result += $" and {list[list.Count - 1].ToString()}";
    return result;
}

// class for owners
class Owner
{
    public int Id { get; }
    public string Name { get; }
    public string Address { get; }

    private static int nextId = 1;

    public Owner(string name, string address)
    {
        Id = nextId++;
        Name = name;
        Address = address;
    }
}

// class for cars
class Car
{
    public string Number { get; }
    public int OwnerId { get; }

    public Car(string number, int ownerId)
    {
        Number = number;
        OwnerId = ownerId;
    }
}
