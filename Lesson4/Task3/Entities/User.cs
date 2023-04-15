namespace Task3.Entities;

public class User
{
    public string Role { get; } = "Owner";
    public Guid Id { get; set; }
    public string Name { get; set; }

    public User(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}
