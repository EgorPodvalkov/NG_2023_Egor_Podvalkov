namespace Task3.Entities;

public class User
{
    public Guid Id { get; }
    public string Name { get; set; }
    public string Role { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public User(string name, string email, string password, string role)
    {
        // Filling Fields
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        Password = password;
        Role = role;
    }

    public virtual void PrintInfo()
    {
        Console.WriteLine($"Id:{Id}\nName: {Name}, Role: {Role}");
    }
}
