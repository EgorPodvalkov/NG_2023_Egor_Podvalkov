using Task1.Abstractions;

namespace Task1.Classes;

public class Drive : Detail
{
    public string? Size { get; set; }
    public string? Type { get; set; }
    public string? Speed { get; set; }
    public string? InterfaceType { get; set; }
    public int? Lifetime { get; set; }

    public Drive(decimal price, string supplier, string country, string name)
        : base(price, supplier, country, name) { }

    public override string GetFullInfo(int pad = 3)
    {
        string result = base.GetFullInfo(pad) + "\n" +
            "".PadLeft(pad) + $"Size: {Size}, Interface Type: {InterfaceType}";
        if (Type == "SSD")
        {
            result += $", Speed: {Speed}, Lifetime: {Lifetime}";
        }
        return result;
    }
}
