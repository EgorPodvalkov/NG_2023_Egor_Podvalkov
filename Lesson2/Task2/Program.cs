//creating persons list
var persons = new List<Person>()
{
    new Person("Egor", 20),
    new Person("Vlad", 25),
    new Person("Fedor", 58),
    new Person("Marina", 35),
    new Person("Anastasia", 14),
    new Person("Max", 8),
    new Person("Slava", 27),
    new Person("Sergey", 22),
    new Person("Sveta", 24),
    new Person("Dima", 19)
};

// getting range
Console.WriteLine("Enter age range(from ... to ...)");
var from = ReadNumber("From: ");
var to = ReadNumber("To: ", from);

//creating filtered list
var filteredPersons = persons.Where(person => person.Age >= from & person.Age <= to);

//logging filtered list
if (filteredPersons.Count() <= 0)
    Console.WriteLine($"No persons in age range from {from} to {to} :(");
else
{
    Console.WriteLine($"Persons that age range from {from} to {to} ({filteredPersons.Count()} persons): ");
    foreach (var person in filteredPersons)
        Console.WriteLine($"Age: {person.Age.ToString().PadLeft(3)}, Name: {person.Name};");
}

// function for read and validate number from console
int ReadNumber(string message = "Enter number: ", int minValue = 0)
{
    while (true)
    {
        try
        {
            Console.Write(message);
            int num = Int32.Parse(Console.ReadLine());
            if (num < minValue)
                throw new Exception();
            return num;
        }
        catch
        {
            Console.WriteLine("Bad number :(");
        }
    }
}

// class for persons 
class Person
{
    public string Name { get; }
    public int Age { get; }

    public Person(string name, int age) =>
        (Name, Age) = (name, age);
}