using Task1.Classes;

namespace Task1.Abstractions;

public abstract class Detail
{
    public decimal Price { get; }
    public string Supplier { get; }
    public string Country { get; }
    public string Name { get; }

    public Detail(decimal price, string supplier, string country, string name)
    {
        Price = price;
        Supplier = supplier;
        Country = country;
        Name = name;
    }
    public virtual string GetFullInfo()
    {
        return $"{Name}\n" +
            $"   {Price}$, {Country}";
    }
}
