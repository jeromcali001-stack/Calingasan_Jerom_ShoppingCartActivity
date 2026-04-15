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

class CartItem
{
    public int Id;
    public string Name;
    public double Price;
    public int Quantity;
    public double SubTotal;
}

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
            Console.WriteLine("\n MAIN MENU ");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View Products");
            Console.WriteLine("3. Exit");
            Console.WriteLine("4. Total Items");
            Console.WriteLine("5. Check Low Stock");
            Console.WriteLine("6. Remove Stock");
            Console.WriteLine("7. Shopping Cart");
            Console.WriteLine("8. Checkout Shopping Cart");
            Console.Write("Choose: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                if (count >= products.Length)
                {
                    Console.WriteLine("Product list is full!");
                    continue;
                }

                Console.Write("Enter ID: ");
                int newId = int.Parse(Console.ReadLine());

                bool exists = false;

                for (int i = 0; i < count; i++)
                {
                    if (products[i].Id == newId)
                    {
                        exists = true;
                        break;
                    }
                }

                if (exists)
                {
                    Console.WriteLine("ID already exists! Try a different ID.");
                    continue;
                }

                Product p = new Product();
                p.Id = newId;

                Console.Write("Enter Name: ");
                p.Name = Console.ReadLine();

                Console.Write("Enter Price: ");
                p.Price = double.Parse(Console.ReadLine());

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
            else if (choice == "6")
            {
                Console.Write("Enter Product ID: ");
                int id = int.Parse(Console.ReadLine());

                bool found = false;

                for (int i = 0; i < count; i++)
                {
                    if (products[i].Id == id)
                    {
                        found = true;

                        Console.WriteLine($"Product: {products[i].Name}");
                        Console.WriteLine($"Current Stock: {products[i].Stock}");

                        Console.Write("How many to deduct? ");
                        int qty = int.Parse(Console.ReadLine());

                        if (qty <= 0)
                        {
                            Console.WriteLine("Invalid quantity");
                        }
                        else if (qty > products[i].Stock)
                        {
                            Console.WriteLine("Not enough stock");
                        }
                        else
                        {
                            products[i].Stock -= qty;
                            Console.WriteLine("Stock updated successfully!");
                            Console.WriteLine($"New Stock: {products[i].Stock}");
                        }

                        break;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("Product not found.");
                }
            }
            else if (choice == "7")
            {
                Console.Write("Enter Product ID: ");
                int id = int.Parse(Console.ReadLine());

                bool found = false;

                for (int i = 0; i < count; i++)
                {
                    if (products[i].Id == id)
                    {
                        found = true;

                        Console.WriteLine($"Product: {products[i].Name}");
                        Console.WriteLine($"Price: {products[i].Price}");
                        Console.WriteLine($"Stock: {products[i].Stock}");

                        Console.Write("Enter quantity to buy: ");
                        int qty = int.Parse(Console.ReadLine());

                        if (qty <= 0)
                        {
                            Console.WriteLine("Invalid quantity");
                        }
                        else if (qty > products[i].Stock)
                        {
                            Console.WriteLine("Not enough stock");
                        }
                        else
                        {
                            bool inCart = false;

                            for (int j = 0; j < cartCount; j++)
                            {
                                if (cart[j].Id == products[i].Id)
                                {
                                    cart[j].Quantity += qty;
                                    cart[j].SubTotal += products[i].Price * qty;
                                    inCart = true;
                                    break;
                                }
                            }

                            if (!inCart)
                            {
                                cart[cartCount] = new CartItem
                                {
                                    Id = products[i].Id,
                                    Name = products[i].Name,
                                    Price = products[i].Price,
                                    Quantity = qty,
                                    SubTotal = products[i].Price * qty
                                };

                                cartCount++;
                            }

                            products[i].Stock -= qty;

                            Console.WriteLine("Added to cart!");
                        }

                        break;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("Product not found.");
                }
            }
            else if (choice == "8")
            {
                if (cartCount == 0)
                {
                    Console.WriteLine("Cart is empty.");
                }
                else
                {
                    double grandTotal = 0;

                    Console.WriteLine("\n===== RECEIPT =====");

                    for (int i = 0; i < cartCount; i++)
                    {
                        Console.WriteLine($"{cart[i].Name} x{cart[i].Quantity} = {cart[i].SubTotal}");
                        grandTotal += cart[i].SubTotal;
                    }

                    Console.WriteLine("-------------------");
                    Console.WriteLine("Grand Total: " + grandTotal);

                    double discount = 0;

                    if (grandTotal >= 5000)
                    {
                        discount = grandTotal * 0.10;
                        Console.WriteLine("Discount (10%): " + discount);
                    }

                    double finalTotal = grandTotal - discount;

                    Console.WriteLine("Final Total: " + finalTotal);

                    Console.WriteLine("\n===== UPDATED STOCK =====");

                    for (int i = 0; i < count; i++)
                    {
                        Console.WriteLine($"{products[i].Name} - Stock: {products[i].Stock}");
                    }

                    cartCount = 0;

                    Console.WriteLine("Checkout complete!");
                }
            }
            else
            {
                Console.WriteLine("Invalid Choice");
            }
        }
    }
}