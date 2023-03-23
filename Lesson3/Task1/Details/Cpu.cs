using Task1.Abstractions;

namespace Task1.Classes;

public class Cpu : Detail
{
    public string? SocketType { get; set; }
    public int? Cores { get; set; }
    public string? Frequency { get; set; }

    public Cpu(decimal price, string supplier, string country, string name)
        : base(price, supplier, country, name) { }

    public override string GetFullInfo()
    {
        return base.GetFullInfo() + "\n" +
            "   " + $"Socket Type: {SocketType}, Cores: {Cores}, Frequency: {Frequency}";
    }
}
