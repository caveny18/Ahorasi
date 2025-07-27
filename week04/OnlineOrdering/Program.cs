using System;

class Program
{
    static void Main()
    {
        Address address1 = new Address("123 Main St", "Lima", "Lima", "Peru");
        Customer customer1 = new Customer("Carlos Ruiz", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Notebook", "N123", 3.50m, 4));
        order1.AddProduct(new Product("Pen", "P456", 1.20m, 10));

        Address address2 = new Address("456 Elm St", "Dallas", "TX", "USA");
        Customer customer2 = new Customer("Anna Smith", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Backpack", "B789", 25.00m, 1));
        order2.AddProduct(new Product("Water Bottle", "W012", 10.00m, 2));

        DisplayOrder(order1);
        Console.WriteLine();
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order.GetTotalCost()}");
    }
}
