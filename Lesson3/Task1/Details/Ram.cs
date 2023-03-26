using Task1.Abstractions;

namespace Task1.Classes;

public class Ram : Detail
{
    public string? Type { get; set; }
    public string? Size { get; set; }

    public Ram(decimal price, string supplier, string country, string name)
        : base(price, supplier, country, name) { }

    public override string GetFullInfo(int pad = 3)
    {
        return base.GetFullInfo(pad) + "\n" +
            "".PadLeft(pad) + $"Type: {Type}, Size: {Size}";
    }
}
