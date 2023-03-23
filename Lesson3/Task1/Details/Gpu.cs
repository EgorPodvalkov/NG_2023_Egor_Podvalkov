using System.Net.Sockets;
using Task1.Abstractions;

namespace Task1.Classes;

public class Gpu : Detail
{
    public string? MemorySize { get; set; }
    public string? Frequency { get; set; }

    public Gpu(decimal price, string supplier, string country, string name)
        : base(price, supplier, country, name) { }
 
    public override string GetFullInfo()
    {
        return base.GetFullInfo() + "\n" +
            "   " + $"Memory Size: {MemorySize}, Frequency: {Frequency}";
    }
}
