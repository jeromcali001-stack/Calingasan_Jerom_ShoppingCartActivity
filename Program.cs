using System;
class Product
{
    public int Id;
    public string Name;
    public double Price;
    public int Stock;

    public void DisplayProduct()
    {
        Console.WriteLine($"{Id}. {Name} - {Price} (Stock: {Stock})");
    }
}

class Program
{
    static void Main()
    {
        Product[] products = new Product[100];
        int count = 0;

        while (true)
        {
            Console.WriteLine("\n MAIN MENU ");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View Products");
            Console.WriteLine("3. Exit");
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

                Console.Write("Enter Stock: ");
                p.Stock = int.Parse(Console.ReadLine());

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
        
        }
    }
}
