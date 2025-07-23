using System;
using System.Collections.Generic;

public class Address
{
    private string streetAddress;
    private string city;
    private string stateOrProvince;
    private string country;

    public Address(string streetAddress, string city, string stateOrProvince, string country)
    {
        this.streetAddress = streetAddress;
        this.city = city;
        this.stateOrProvince = stateOrProvince;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.Equals("USA", StringComparison.OrdinalIgnoreCase);
    }

    public string GetFullAddress()
    {
        return $"{streetAddress}\n{city}, {stateOrProvince}\n{country}";
    }
}

public class Product
{
    private string name;
    private int productId;
    private decimal price;
    private int quantity;

    public Product(string name, int productId, decimal price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public decimal GetTotalCost()
    {
        return price * quantity;
    }

    public string GetProductInfo()
    {
        return $"{name} (ID: {productId}) - Quantity: {quantity} - Price: ${price}";
    }
}

public class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    public string GetCustomerInfo()
    {
        return $"{name}\n{address.GetFullAddress()}";
    }
}

public class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
        products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public decimal CalculateTotalPrice()
    {
        decimal totalCost = 0;
        foreach (var product in products)
        {
            totalCost += product.GetTotalCost();
        }
        decimal shippingCost = customer.IsInUSA() ? 5 : 35; // Adjusting shipping cost for non-USA
        return totalCost + shippingCost;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in products)
        {
            label += product.GetProductInfo() + "\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{customer.GetCustomerInfo()}";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create addresses
        Address address1 = new Address("123 Main St", "Harare", "Harare", "Zimbabwe");
        Address address2 = new Address("456 Second St", "Bulawayo", "Bulawayo", "Zimbabwe");

        // Create customers
        Customer customer1 = new Customer("Tendai Moyo", address1);
        Customer customer2 = new Customer("Chipo Ndlovu", address2);

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Zim Coffee", 201, 4.99m, 3));
        order1.AddProduct(new Product("Traditional Basket", 202, 15.00m, 1));

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Handmade Soap", 203, 5.50m, 2));
        order2.AddProduct(new Product("Shona Sculpture", 204, 25.00m, 1));

        // Display results for order 1
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalPrice():F2}\n");

        // Display results for order 2
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotalPrice():F2}");
    }
}
