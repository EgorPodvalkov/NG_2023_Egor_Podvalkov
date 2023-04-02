namespace Task3.Entities;

public class User
{
    public const string Role = "User";
    public Guid Id { get; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public User(string name, string email, string password, string role = Role)
    {
        // Filling Fields
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        Password = password;

        // Adding Id-Role Pair to Dictionary
        UsersManager.RoleByUserId.Add(Id, role);
    }

    public virtual void PrintInfo()
    {
        Console.WriteLine($"Id:{Id}\nName: {Name}, Role: {Role}");
    }
}
