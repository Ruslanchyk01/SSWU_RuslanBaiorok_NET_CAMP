using Task2;

var products = new List<Product>
{
    new Products("Apple", 0.2, true),
    new Electronics("Laptop", 2.5, 35.0, 1000.0),
    new Сlothes("T-Shirt", 0.3, СlothesSize.M)
};

var shippingCost = new ShippingCost();

foreach (var product in products)
{
    double shippingCosts = product.Accept(shippingCost);
    PrintShippingCost(product.Name, shippingCosts);
}

static void PrintShippingCost(string productName, double cost)
{
    Console.WriteLine($"Shipping cost for product '{productName}': {cost}");
}