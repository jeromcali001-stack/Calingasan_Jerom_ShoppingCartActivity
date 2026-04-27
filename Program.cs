using System;

class Program
{
    static void Main()
    {
        Product[] products = new Product[100];
        int count = 0;

        CartItem[] cart = new CartItem[100];
        int cartCount = 0;

        products[count++] = new Product { Id = 1, Name = "Keyboard", Price = 500 };
        products[count++] = new Product { Id = 2, Name = "Mouse", Price = 300 };
        products[count++] = new Product { Id = 3, Name = "Monitor", Price = 7000 };

        while (true)
        {
            Console.WriteLine("\n1. Add Product");
            Console.WriteLine("2. View Products");
            Console.Write("Choose: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                if (count >= products.Length)
                {
                    Console.WriteLine("Product list is full");
                    continue;
                }

                Console.Write("Enter ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Price: ");
                double price = double.Parse(Console.ReadLine());

                products[count++] = new Product
                {
                    Id = id,
                    Name = name,
                    Price = price
                };

                Console.WriteLine("Product added!");
            }
            else if (choice == "2")
            {
                if (count == 0)
                {
                    Console.WriteLine("Products are empty");
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        Console.WriteLine($"{products[i].Id} - {products[i].Name} - {products[i].Price}");
                    }
                }
            }
        }
    }
}