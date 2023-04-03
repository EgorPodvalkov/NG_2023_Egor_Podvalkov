namespace Task1;

public static class DBManager
{
    public static void UpdateCustomerBalance(int customerId, decimal newBalance)
    {
        var customer = CustomerManager.GetCustomerById(customerId);
        if (customer == null)
            return;
        customer.Balance = newBalance;
    }

    public static void SaveToDatabase() => Console.WriteLine("Saved!");
}
