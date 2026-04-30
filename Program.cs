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
    Console.WriteLine("Welcome to the Cali-Store!");
    Console.WriteLine("How would you like to proceed?");
    Console.WriteLine("1. Admin");
    Console.WriteLine("2. Customer");
    Console.Write("Choose: ");

    string choose = Console.ReadLine();

    if (choose == "1")
    {
        while (true)
        {
            Console.WriteLine("\n1. Add Product");
            Console.WriteLine("2. View Products");
            Console.WriteLine("3. Total Items");
            Console.WriteLine("4. Stock Check");
            Console.WriteLine("5. Deduct Stock");
            Console.WriteLine("6. Exit");
            Console.Write("Choose: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Enter ID: ");
                int id;
                int.TryParse(Console.ReadLine(), out id);

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Price: ");
                double price;
                double.TryParse(Console.ReadLine(), out price);

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
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine($"{products[i].Id} - {products[i].Name} - {products[i].Price} - Stock: {products[i].Stock}");
                }
            }

            else if (choice == "3")
            {
                int totalItems = 0;

                for (int i = 0; i < count; i++)
                {
                    totalItems += products[i].Stock;
                }

                Console.WriteLine("Total Items: " + totalItems);
            }

            else if (choice == "4")
            {
                Console.Write("Enter Product ID: ");
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
                            Console.WriteLine("Low Stock!");
                        else
                            Console.WriteLine("Stock sufficient");

                        break;
                    }
                }

                if (!found)
                    Console.WriteLine("Product not found");
            }

            else if (choice == "5")
            {
                Console.Write("Enter Product ID: ");
                int id;
                int.TryParse(Console.ReadLine(), out id);

                bool found = false;

                for (int i = 0; i < count; i++)
                {
                    if (products[i].Id == id)
                    {
                        found = true;

                        Console.Write("How many to deduct? ");
                        int qty;
                        int.TryParse(Console.ReadLine(), out qty);

                        if (qty <= 0)
                            Console.WriteLine("Invalid amount");
                        else if (qty > products[i].Stock)
                            Console.WriteLine("Not enough stock");
                        else
                        {
                            products[i].Stock -= qty;
                            Console.WriteLine("Stock updated!");
                        }

                        break;
                    }
                }

                if (!found)
                    Console.WriteLine("Product not found");
            }

            

            else if (choice == "6")
            {
                Console.WriteLine("Returning to main menu...");
                break;
            }

            else
            {
                Console.WriteLine("Invalid choice");
            }
        }
    }

                
    
    else if (choose == "2")
    {
        while(true)
        {
            
                Console.WriteLine("\nSHOPPING CART");
                Console.WriteLine("1. View Cart");
                Console.WriteLine("2. Add to Cart");
                Console.WriteLine("3. Remove from Cart");
                Console.WriteLine("4. Checkout");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Choose: ");

                string cartChoice = Console.ReadLine();

                

                if (cartChoice == "1")
                {
                    if (cartCount == 0)
                    {
                        Console.WriteLine("Cart is empty");
                    }
                    else
                    {
                        double total = 0;

                        for (int i = 0; i < cartCount; i++)
                        {
                            Console.WriteLine($"{cart[i].Name} x{cart[i].Quantity} = {cart[i].SubTotal}");
                            total += cart[i].SubTotal;
                        }

                        Console.WriteLine("Total: " + total);
                    }
                }

                else if (cartChoice == "2")
                {
                    for (int i = 0; i < count; i++)
                    {
                        Console.WriteLine($"{products[i].Id} - {products[i].Name} - {products[i].Price} - Stock: {products[i].Stock}");
                    }

                    Console.Write("Enter Product ID: ");
                    int id;
                    int.TryParse(Console.ReadLine(), out id);

                    bool found = false;

                    for (int i = 0; i < count; i++)
                    {
                        if (products[i].Id == id)
                        {
                            found = true;

                            Console.Write("Enter Quantity: ");
                            int qty;
                            int.TryParse(Console.ReadLine(), out qty);

                            if (qty <= 0)
                            {
                                Console.WriteLine("Invalid amount");
                            }
                            else if (qty > products[i].Stock)
                            {
                                Console.WriteLine("Not enough stock");
                            }
                            else
                            {
                                cart[cartCount++] = new CartItem
                                {
                                    Id = products[i].Id,
                                    Name = products[i].Name,
                                    Price = products[i].Price,
                                    Quantity = qty,
                                    SubTotal = products[i].Price * qty
                                };

                                products[i].Stock -= qty;
                                Console.WriteLine("Added to cart!");
                            }

                            break;
                        }
                    }

                    if (!found)
                        Console.WriteLine("Product not found");
                }

                else if (cartChoice == "3")
                {
                    Console.Write("Enter Product ID to remove: ");
                    int id;
                    int.TryParse(Console.ReadLine(), out id);

                    bool found = false;

                    for (int i = 0; i < cartCount; i++)
                    {
                        if (cart[i].Id == id)
                        {
                            found = true;

                            for (int j = 0; j < count; j++)
                            {
                                if (products[j].Id == id)
                                {
                                    products[j].Stock += cart[i].Quantity;
                                    break;
                                }
                            }

                            for (int j = i; j < cartCount - 1; j++)
                            {
                                cart[j] = cart[j + 1];
                            }

                            cartCount--;
                            Console.WriteLine("Removed from cart!");
                            break;
                        }
                    }

                    if (!found)
                        Console.WriteLine("Item not found in cart");
                }

                else if (cartChoice == "4")
                {
                    double total = 0;

                    for (int i = 0; i < cartCount; i++)
                    {
                        Console.WriteLine($"{cart[i].Name} x{cart[i].Quantity} = {cart[i].SubTotal}");
                        total += cart[i].SubTotal;
                    }

                    Console.WriteLine("Final Total: " + total);
                    cartCount = 0;
                    Console.WriteLine("Checkout complete!");
                }

                else if (cartChoice == "5")
                {
                    Console.WriteLine("Returning to main menu...");
                    break;
                }

                else
                {
                    Console.WriteLine("Invalid choice");
                }   
    
            
    
                
            }
    }
    else if (choose == "3")
                {
                    Console.WriteLine("Thank you for visiting Cali-Store!");
                    break;
                }
    }
    }
}

