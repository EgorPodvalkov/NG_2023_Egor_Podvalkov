namespace Task3.Entities;

public class Owner: Admin
{
    public new const string Role = "Owner";

    public Owner(string name, string email, string password, string role = Role)
        : base(name, email, password, role) { }

    public override void PrintInfo()
    {
        Console.WriteLine($"Id:{Id}\nName: {Name}, Role: {Role}");
    }
}
