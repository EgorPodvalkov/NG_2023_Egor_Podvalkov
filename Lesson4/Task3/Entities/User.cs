namespace Task3.Entities;

public class User
{
    public readonly string Role = "User"; 

    public Guid Id { get; }
    public string Name { get; set; }

    public User(string name)
    {
        // Filling Fields
        Id = Guid.NewGuid();
        Name = name;
    }
}
