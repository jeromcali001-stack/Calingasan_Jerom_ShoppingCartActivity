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
            Console.WriteLine("3. Total Items");
            Console.WriteLine("4. Stock Check");
            Console.WriteLine("5. Deduct Stock");
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
                int id;
                int.TryParse(Console.ReadLine(), out id);

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
            else if (choice == "3")
            {
                int totalItems = 0;
                for (int i = 0; i < count; i++)
                {
                    totalItems += products[i].Stock;
                }
                Console.Write("Total Items: " + totalItems);

            }
            else if (choice == "4")
            {
                Console.WriteLine("Enter ID to check: ");
                int id;
                int.TryParse(Console.ReadLine(), out id);

                bool found = false;
                for (int i = 0; i < count; i++)
                {
                    if (products[i].Id == id)
                {
                    found = true;

                    Console.WriteLine("Current Stock: " + products[i].Stock);

                    if (products[i].IsLowStock())
                    {
                        Console.WriteLine("Product is Low on stock");
                    }
                    else
                    {
                        Console.WriteLine("Stock sufficient");
                    }

                    break;
                }   
                    
                }
            }
            else if (choice == "5")
            {
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine($"{products[i].Id} - {products[i].Name} - {products[i].Stock}");
                }
                Console.Write("Enter the ID of the product: ");
                int id;
                int.TryParse(Console.ReadLine(), out id);
                
                bool found = false;
                for (int i = 0; i < count; i++)
                
                {
                    if (products[i].Id == id)
                    {
                        found = true;
                       
                        Console.WriteLine($"{products[i].Name} - {products[i].Stock}");
                        Console.Write("how many would you like to deduct?");
                        int qty;
                        int.TryParse(Console.ReadLine(), out qty);

                        if (qty > products[i].Stock)
                        {   
                            
                            Console.Write("Not Enough Stock");
                            break;
                        }

                        else if (qty <= 0)
                        {   
                            
                            Console.Write("Invalid Amount");
                        }
                        else 
                        {
                            products[i].Stock -= qty;
                            Console.Write("Stock Updated");
                            Console.WriteLine($"{products[i].Name} - {products[i].Stock}");
                            
                        }
                    }
                     
                }
                    if (!found)
                {
                    Console.WriteLine("Product not found");
                }
            }
            
        }
    }
}