namespace Task3.Entities;

public class Owner : Admin
{
    public new readonly string Role = "Owner";

    public Owner(string name)
        : base(name) { }
}
