namespace Task3.Entities;

public class Admin : User
{
    public new const string Role = "Admin";

    public Admin(string name, string email, string password, string role = Role)
        : base(name, email, password, role) { }

    public override void PrintInfo()
    {
        Console.WriteLine($"Id:{Id}\nName: {Name}, Role: {Role}");
    }
}
