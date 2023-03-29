
using Task1;

var c = new Customer(4,"4",132);

var list = Customer.CustomersList;

foreach (var item in list)
    Console.WriteLine($"{item.Id}, {item.Name}, {item.Balance}$");

c.UpdateBalance(1, 23);

foreach (var item in list)
    Console.WriteLine($"{item.Id}, {item.Name}, {item.Balance}$");

Console.WriteLine("Hello, World!");
