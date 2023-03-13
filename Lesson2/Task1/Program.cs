//creating products list
var products = new List<Product>()
{
    new Product("Bread", 16),
    new Product("Apple", 17),
    new Product("Banana", 71),
    new Product("Pineapple", 93),
    new Product("Garlic", 102),
    new Product("Mandarin", 62),
    new Product("Carrot", 43),
    new Product("Chicken Eggs", 66),
    new Product("Chicken Fillet", 139),
    new Product("Beer", 34)
};

//creating 2 sorted lists
var ascendingSortedProducts = from product in products orderby product.Price select product;
var descendingSortedProducts = from product in products orderby product.Price descending select product;

//logging ascending sorted list
Console.WriteLine("Ascending sort:\n");
foreach (var product in ascendingSortedProducts)
{
    Console.WriteLine($"Name: {product.Name}");
    Console.WriteLine($"Price: {product.Price} grn.");
    Console.WriteLine();
}

//logging descending sorted list
Console.WriteLine("---------------------------------\nDescending sort:\n");
foreach (var product in descendingSortedProducts)
{
    Console.WriteLine($"Name: {product.Name}");
    Console.WriteLine($"Price: {product.Price} grn.");
    Console.WriteLine();
}

// class product implemented
class Product
{
    public string Name { get; }
    public int Price { get; }

    public Product(string name, int price) =>
        (Name, Price) = (name, price);
}
