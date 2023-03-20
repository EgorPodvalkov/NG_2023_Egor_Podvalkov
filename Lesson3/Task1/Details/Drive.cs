using Task1.Abstractions;

namespace Task1.Classes;

public class Drive : Detail
{
    public string? Size { get; set; }
    public string? Type { get; set; }
    public string? Speed { get; set; }
    public string? InterfaceType { get; set; }
    public string? Lifetime { get; set; }

    public Drive(decimal price, string supplier, string country, string name)
        : base(price, supplier, country, name) { }
}
