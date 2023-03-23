using Task1.Abstractions;

namespace Task1.Classes;

public class Motherboard : Detail
{
    public string? SocketType { get; set; }
    public int RamSlots { get; set; }

    public Motherboard(decimal price, string supplier, string country, string name)
        : base(price, supplier, country, name) { }

    public override string GetFullInfo()
    {
        return base.GetFullInfo() + "\n" +
            "   " + $"Socket Type: {SocketType}";
    }
}
