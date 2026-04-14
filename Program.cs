using System;

class Product
{
    public int Id;
    public string Name;
    public double Price;
    public int Stock = 10;

    public void DisplayProduct()
    {
        Console.WriteLine($"{Id}. {Name} - {Price} (Stock: {Stock})");
    }

    public bool IsLowStock()
    {
        return Stock < 10;
    }
}

class Program
{
    static void Main()
    {
        Product[] products = new Product[100];
        int count = 0;
        products[count++] = new Product { Id = 1, Name = "Keyboard", Price = 500 };
        products[count++] = new Product { Id = 2, Name = "Mouse", Price = 300 };
        products[count++] = new Product { Id = 3, Name = "Monitor", Price = 7000 };

        while (true)
        {
            Console.WriteLine("\n MAIN MENU ");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View Products");
            Console.WriteLine("3. Exit");
            Console.WriteLine("4. Total Items");
            Console.WriteLine("5. Check Low Stock");
            Console.Write("Choose: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                if (count >= products.Length)
                {
                    Console.WriteLine("Product list is full!");
                    continue;
                }

                Product p = new Product();

                Console.Write("Enter ID: ");
                p.Id = int.Parse(Console.ReadLine());

                Console.Write("Enter Name: ");
                p.Name = Console.ReadLine();

                Console.Write("Enter Price: ");
                p.Price = double.Parse(Console.ReadLine());

                // ❌ removed stock input → default is 10

                products[count] = p;
                count++;

                Console.WriteLine("Product added successfully!");
            }

            else if (choice == "2")
            {
                if (count == 0)
                {
                    Console.WriteLine("No products available at the moment");
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        products[i].DisplayProduct();
                    }
                }
            }

            else if (choice == "3")
            {
                break;
            }

            else if (choice == "4")
            {
                int totalItems = 0;

                for (int i = 0; i < count; i++)
                {
                    totalItems += products[i].Stock;
                }

                Console.WriteLine("Total Items: " + totalItems);
            }

            else if (choice == "5")
            {
                Console.Write("Enter Product ID: ");
                int id = int.Parse(Console.ReadLine());

                bool found = false;

                for (int i = 0; i < count; i++)
                {
                    if (products[i].Id == id)
                    {
                        found = true;

                        Console.WriteLine("Current Stock: " + products[i].Stock); 

                        if (products[i].IsLowStock())
                        {
                            Console.WriteLine("Stock is LOW (below 10)!");
                        }
                        else
                        {
                            Console.WriteLine("Stock is OK.");
                        }

                        break;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("Product not found.");
                }
            }

            else
            {
                Console.WriteLine("Invalid Choice");
            }
        }
    }
}