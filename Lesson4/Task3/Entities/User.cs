namespace Task3.Entities;

public class User
{
    public Guid Id { get; }
    public string Name { get; set; }
    public string Role { get; set; }

    public User(string name, string role)
    {
        // Filling Fields
        Id = Guid.NewGuid();
        Name = name;
        Role = role;
    }
}
