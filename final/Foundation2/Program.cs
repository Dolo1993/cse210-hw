using System;
using System.Collections.Generic;

public class Product
{
    private string name;
    private string productId;
    private decimal price;
    private int quantity;

    public Product(string _name, string _productId, decimal _price, int _quantity)
    {
        this.name = _name;
        this.productId = _productId;
        this.price = _price;
        this.quantity = _quantity;
    }

    public decimal GetTotalPrice()
    {
        return price * quantity;
    }

    public string GetName()
    {
        return name;
    }

    public string GetProductId()
    {
        return productId;
    }
}

public class Address
{
    private string street;
    private string city;
    private string stateProvince;
    private string country;

    public Address(string street, string city, string stateProvince, string country)
    {
        this.street = street;
        this.city = city;
        this.stateProvince = stateProvince;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.Equals("USA", StringComparison.OrdinalIgnoreCase);
    }

    public string GetFullAddress()
    {
        return $"{street}\n{city}, {stateProvince}\n{country}";
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

    public string GetName()
    {
        return name;
    }

    public Address GetAddress()
    {
        return address;
    }
}

public class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(List<Product> products, Customer customer)
    {
        this.products = products;
        this.customer = customer;
    }

    public decimal CalculateTotalCost()
    {
        decimal totalCost = 0;

        foreach (Product product in products)
        {
            totalCost += product.GetTotalPrice();
        }

        if (customer.IsInUSA())
        {
            totalCost += 5;  
        }
        else
        {
            totalCost += 35;  
        }

        return totalCost;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "Packing Label:\n";
        foreach (Product product in products)
        {
            packingLabel += $"Name: {product.GetName()}, ID: {product.GetProductId()}\n";
        }

        return packingLabel;
    }

    public string GetShippingLabel()
    {
        Address address = customer.GetAddress();
        return $"Shipping Label:\nName: {customer.GetName()}\nAddress:\n{address.GetFullAddress()}";
    }
}

public class Program
{
    public static void Main()
    {
       
        List<Product> products = new List<Product>();

        for (int i = 1; i <= 2; i++)
        {
            Console.WriteLine($"Product {i}:");
            Console.Write("Enter the name: ");
            string name = Console.ReadLine();
            Console.Write("Enter the product ID: ");
            string productId = Console.ReadLine();
            Console.Write("Enter the price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Enter the quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            Product product = new Product(name, productId, price, quantity);
            products.Add(product);
        }

        
        Console.Write("Enter the street address: ");
        string streetAddress = Console.ReadLine();
        Console.Write("Enter the city: ");
        string city = Console.ReadLine();
        Console.Write("Enter the state/province: ");
        string stateProvince = Console.ReadLine();
        Console.Write("Enter the country: ");
        string country = Console.ReadLine();

        Address address = new Address(streetAddress, city, stateProvince, country);

        
        Console.Write("Enter the customer name: ");
        string customerName = Console.ReadLine();
        Customer customer = new Customer(customerName, address);
 
        Order order = new Order(products, customer);

         
        Console.WriteLine();
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order.CalculateTotalCost()}"); 
        Console.WriteLine();
    }
}
