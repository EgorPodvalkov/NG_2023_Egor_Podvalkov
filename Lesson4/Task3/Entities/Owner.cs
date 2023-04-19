namespace Task3.Entities;

public class Owner : Admin
{
    public string Role { get; } = "Owner";
    public Owner(string name) : base(name) { }
}