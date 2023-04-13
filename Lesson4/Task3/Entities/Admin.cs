namespace Task3.Entities;

public class Admin : User
{
    public new readonly string Role = "Admin"; 

    public Admin(string name)
        : base(name) { }
}
