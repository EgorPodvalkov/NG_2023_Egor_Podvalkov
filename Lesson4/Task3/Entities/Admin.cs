namespace Task3.Entities;

public class Admin : User
{
    public string Role { get; } = "Admin";
    public Admin(string name) : base(name) { }
}
