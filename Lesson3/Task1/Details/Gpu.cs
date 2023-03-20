using Task1.Abstractions;

namespace Task1.Classes;

public class Gpu : Detail
{
    public string? MemorySize { get; set; }
    public string? Speed { get; set; }

    public Gpu(decimal price, string supplier, string country, string name)
        : base(price, supplier, country, name) { }
}
