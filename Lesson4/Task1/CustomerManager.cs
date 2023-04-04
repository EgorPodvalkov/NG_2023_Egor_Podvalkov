namespace Task1;

public static class CustomerManager
{
    public static List<Customer> CustomersList = new List<Customer>()
    {
        new Customer(1, "Fikus", 0),
        new Customer(2, "VHarbar", 100000)
    };

    public static void PrintBalanceToConsole(int id)
        => Console.WriteLine($"Customer`s with id {id} balance is: {GetBalanceById(id)}");

    public static decimal GetBalanceById(int id)
    {
        var customer = GetCustomerById(id);
        if (customer == null)
            return -1;
        return customer.Balance;
    }

    public static Customer? GetCustomerById(int id)
        => CustomersList.FirstOrDefault(x => x.Id == id);
}
