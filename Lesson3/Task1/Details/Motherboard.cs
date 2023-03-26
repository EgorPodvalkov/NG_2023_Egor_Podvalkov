using Task1.Abstractions;

namespace Task1.Classes;

public class Motherboard : Detail
{
    public string? SocketType { get; set; }
    public int RamSlots { get; set; }

    public Motherboard(decimal price, string supplier, string country, string name)
        : base(price, supplier, country, name) { }

    public override string GetFullInfo(int pad = 3)
    {
        return base.GetFullInfo(pad) + "\n" +
            "".PadLeft(pad) + $"Socket Type: {SocketType}, RAM Slots: {RamSlots}";
    }
}
