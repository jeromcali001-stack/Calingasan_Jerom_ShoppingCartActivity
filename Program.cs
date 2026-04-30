    using System;

    class Program
    {
        static void Main()
        {
            History[] history = new History[100];
            int historyCount = 0;

            int receiptNumber = 1;
            Product[] products = new Product[100];
            int count = 0;

            CartItem[] cart = new CartItem[100];
            int cartCount = 0;

            products[count++] = new Product { Id = 1, Name = "Keyboard", Category = "Electronics", Price = 500 };
            products[count++] = new Product { Id = 2, Name = "Mouse", Category = "Electronics", Price = 300 };
            products[count++] = new Product { Id = 3, Name = "Monitor", Category = "Electronics", Price = 7000 };
            
            products[count++] = new Product { Id = 4, Name = "Mousepad", Category = "Accessories", Price = 150 };
            products[count++] = new Product { Id = 5, Name = "USB Flash Drive 32GB", Category = "Accessories", Price = 350 };
            products[count++] = new Product { Id = 6, Name = "Headset", Category = "Electronics", Price = 1200 };

            products[count++] = new Product { Id = 7, Name = "Laptop Stand", Category = "Accessories", Price = 800 };
            products[count++] = new Product { Id = 8, Name = "External Hard Drive 1TB", Category = "Storage", Price = 2500 };
            products[count++] = new Product { Id = 9, Name = "Webcam HD", Category = "Electronics", Price = 900 };
            products[count++] = new Product { Id = 10, Name = "Mechanical Keyboard Switch Set", Category = "Accessories", Price = 600 };


        while (true)
        {
        Console.WriteLine("Welcome to the Cali-Store!");
        Console.WriteLine("How would you like to proceed?");
        Console.WriteLine("1. Store Owner");
        Console.WriteLine("2. Customer");
        Console.WriteLine("3. Exit");
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
                Console.WriteLine("6. Search Products");
                Console.WriteLine("7. Search by Category");
                Console.WriteLine("8. Exit");
                Console.Write("Choose: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    string proceed = "y";

                    do
                    {
                        Console.Write("Enter ID: ");
                        int id;
                        int.TryParse(Console.ReadLine(), out id);

                        bool idExists = false;

                        for (int i = 0; i < count; i++)
                        {
                            if (products[i].Id == id)
                            {
                                idExists = true;
                                break;
                            }
                        }

                        if (idExists)
                        {
                            Console.WriteLine("ID already exists!");
                            continue;
                        }

                        string name;

                        while (true)
                        {
                            Console.Write("Enter Name: ");
                            name = Console.ReadLine() ?? "";

                            bool exists = false;

                            for (int i = 0; i < count; i++)
                            {
                                if (products[i].Name.ToLower() == name.ToLower())
                                {
                                    exists = true;
                                    break;
                                }
                            }

                            if (!exists) break;

                            Console.WriteLine("Product name already exists!");
                        }

                        
                        int stock;

                        while (true)
                        {
                            Console.Write("Enter Stock: ");

                            if (!int.TryParse(Console.ReadLine(), out stock))
                            {
                                Console.WriteLine("Invalid input! Enter a number.");
                                continue;
                            }

                            if (stock <= 0)
                            {
                                Console.WriteLine("Stock must be greater than 0!");
                                continue;
                            }

                            break;
                        }

                        double price;
                        while (true)
                        {
                            Console.Write("Enter Price: ");
                            if (double.TryParse(Console.ReadLine(), out price) && price > 0)
                                break;

                            Console.WriteLine("Price must be greater than 0!");
                        }

                        Console.Write("Enter Category: ");
                        string category = Console.ReadLine() ?? "";

                        products[count++] = new Product
                        {
                            Id = id,
                            Name = name,
                            Category = category,
                            Price = price,
                            Stock = stock
                        };

                        Console.WriteLine("Product added!");

                        Console.Write("Add another? (y/n): ");
                        proceed = Console.ReadLine()?.ToLower() ?? "n";

                    } while (proceed == "y");
                }
                else if (choice == "2")
                {
                    for (int i = 0; i < count; i++)
                    {
                        if (products[i].Stock <= 0)
                        {
                            Console.WriteLine($"{products[i].Id} - {products[i].Name} - OUT OF STOCK");
                        }
                        else
                        {
                            Console.WriteLine($"{products[i].Id} - {products[i].Name} - {products[i].Category} - {products[i].Price} - Stock: {products[i].Stock}");
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

                    Console.WriteLine("Total Items: " + totalItems);
                }

                else if (choice == "4")
                {
                    string proceed;

                    do
                    {
                        Console.Write("Enter Product ID: ");
                        string input = Console.ReadLine();

                        int id;

                        if (!int.TryParse(input, out id))
                        {
                            Console.WriteLine("Invalid ID! Please enter a valid number.");
                        }
                        else
                        {
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

                        Console.Write("Do you wish to check another product? (y/n): ");
                        proceed = Console.ReadLine().ToLower();

                        if (proceed != "y")
                        {
                            Console.WriteLine("Returning to main menu...\n");
                        }

                    } while (proceed == "y");
                }
                else if (choice == "5")
                {
                    string proceed;

                    do
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
                                {
                                    Console.WriteLine("Invalid amount");
                                }
                                else if (qty > products[i].Stock)
                                {
                                    Console.WriteLine("Not enough stock");
                                }
                                else
                                {
                                    products[i].Stock -= qty;
                                    Console.WriteLine("Stock updated!");
                                }

                                break;
                            }
                        }

                        if (!found)
                        {
                            Console.WriteLine("Product not found");
                        }

                    
                        Console.Write("Do you wish to deduct another product? (y/n): ");
                        proceed = Console.ReadLine().ToLower();

                        if (proceed != "y")
                        {
                            Console.WriteLine("Returning to main menu...\n");
                        }

                    } while (proceed == "y");
                }
                
                
                    else if (choice == "6")
                {
                    string proceed;

                    do
                    {
                        Console.Write("Enter product name to search: ");
                        string search = Console.ReadLine().ToLower();
                        bool found = false;

                        for (int i = 0; i < count; i++)
                        {
                            if (products[i].Name.ToLower().Contains(search))
                            {
                                Console.WriteLine($"{products[i].Id} - {products[i].Name} - PHP {products[i].Price} - Stock: {products[i].Stock}");
                                found = true;
                            }
                        }

                        if (!found)
                            Console.WriteLine("No product found");

                        Console.Write("Do you wish to search another product? (y/n): ");
                        proceed = Console.ReadLine().ToLower();

                        if (proceed != "y")
                        {
                            Console.WriteLine("Returning to main menu...\n");
                        }

                    } while (proceed == "y");
                }
                    
                
                    else if (choice == "7")
                    {
                        string proceed;

                        do
                        {
                            Console.WriteLine("Available Categories:");

                            for (int i = 0; i < count; i++)
                            {
                                bool alreadyPrinted = false;

                                for (int j = 0; j < i; j++)
                                {
                                    if (products[i].Category.ToLower() == products[j].Category.ToLower())
                                    {
                                        alreadyPrinted = true;
                                        break;
                                    }
                                }

                                if (!alreadyPrinted)
                                {
                                    Console.WriteLine(products[i].Category);
                                }
                            }

                            Console.Write("Enter category to search: ");
                            string search = Console.ReadLine().ToLower();
                            bool found = false;

                            for (int i = 0; i < count; i++)
                            {
                                if (products[i].Category.ToLower().Contains(search))
                                {
                                    Console.WriteLine($"{products[i].Id} - {products[i].Name} - PHP {products[i].Price} - Stock: {products[i].Stock}");
                                    found = true;
                                }
                            }

                            if (!found)
                                Console.WriteLine("No products found in that category.");

                            Console.Write("Do you wish to search another category? (y/n): ");
                            proceed = Console.ReadLine().ToLower();

                            if (proceed != "y")
                            {
                                Console.WriteLine("Returning to main menu...\n");
                            }

                        } while (proceed == "y");
                    }
            else if (choice == "8")
            {
                Console.WriteLine("Returning to main menu...\n");
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
                    Console.WriteLine("5. Clear Cart");
                    Console.WriteLine("6. Category Search");
                    Console.WriteLine("7. Order History");
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
                        string proceed;

                        do
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
                                    if (products[i].Stock <= 0)
                                    {
                                        Console.WriteLine("This product is OUT OF STOCK!");
                                        break;
                                    }
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

                            Console.Write("Do you want to add another product? (y/n): ");
                            proceed = Console.ReadLine().ToLower();

                            if (proceed != "y")
                            {
                                Console.WriteLine("Returning to cart menu...\n");
                            }

                        } while (proceed == "y");
                    }

                    else if (cartChoice == "3")
                    {
                        string proceed;

                        do
                        {
                            for (int i = 0; i < cartCount; i++)
                            {
                                Console.WriteLine($"{cart[i].Id} - {cart[i].Name} - {cart[i].Price} x{cart[i].Quantity} = {cart[i].SubTotal}");
                            }

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

                            Console.Write("Do you want to remove another item? (y/n): ");
                            proceed = Console.ReadLine().ToLower();

                            if (proceed != "y")
                            {
                                Console.WriteLine("Returning to cart menu...\n");
                            }

                        } while (proceed == "y");
                    }

                    else if (cartChoice == "4")
                    {
                        double total = 0;

                    for (int i = 0; i < cartCount; i++)
                        {
                            Console.WriteLine($"{cart[i].Name} x{cart[i].Quantity} = {cart[i].SubTotal}");
                            total += cart[i].SubTotal;
                        }

                        Console.WriteLine("Grand Total: PHP " + total);

                        double discount = 0;

                        if (total >= 5000)
                        {
                            discount = total * 0.10;
                            Console.WriteLine("Discount (10%): PHP " + discount);
                        }

                        double finalTotal = total - discount;

                        Console.WriteLine("Final Total: PHP " + finalTotal);

                        double payment;
                        Console.WriteLine("Do you wish to continue? (y/n):");
                        if (Console.ReadLine().ToLower() != "y")
                        {
                            Console.WriteLine("Checkout cancelled.");
                            break;
                        }
                        while (true)
                        {
                            Console.Write("Enter Payment: ");
                            bool valid = double.TryParse(Console.ReadLine(), out payment);

                            if (!valid)
                            {
                                Console.WriteLine("Invalid input.");
                            }
                            else if (payment < finalTotal)
                            {
                                Console.WriteLine("Insufficient payment.");
                            }
                            else
                            {
                                break;
                            }
                        }

                        double change = payment - finalTotal;

                        Console.WriteLine("Change: PHP " + change);
                        
                        cartCount = 0;
                        Console.WriteLine("Do you wish to see your receipt? (y/n):");
                        if (Console.ReadLine().ToLower() != "y")
                        {
                            Console.WriteLine("Thank you.");
                            continue;
                        }
                            else
                            {
                                Console.WriteLine("\n Receipt Details:");
                                Console.WriteLine("Receipt No: " + receiptNumber.ToString("D4"));
                                Console.WriteLine("Date: " + DateTime.Now);
                                Console.WriteLine("Final Total: PHP " + finalTotal);
                                Console.WriteLine("Payment: PHP " + payment);
                                Console.WriteLine("Change: PHP " + change);
                                
                            }
                        history[historyCount++] = new History
                        {
                            ReceiptNumber = receiptNumber,
                            Date = DateTime.Now,
                            FinalTotal = finalTotal
                        };

                        receiptNumber++;

                    Console.WriteLine("Do you wish to go back to menu (y/n):");
                        if (Console.ReadLine().ToLower() != "y")
                        {
                            Console.WriteLine("Returning to main menu...");
                            continue;
                        }
                    }


                else if (cartChoice == "5")
                    {
                        if (cartCount == 0)
                        {
                            Console.WriteLine("Cart already empty.");
                        }
                        else
                        {
                            for (int i = 0; i < cartCount; i++)
                            {
                                for (int j = 0; j < count; j++)
                                {
                                    if (products[j].Id == cart[i].Id)
                                    {
                                        products[j].Stock += cart[i].Quantity;
                                        break;
                                    }
                                }
                            }

                            cartCount = 0;
                            Console.WriteLine("Cart cleared!");
                        }
                    }
                    else if (cartChoice == "6")
                    {
                        string proceed;

                        do
                        {
                            Console.WriteLine("Available Categories:");

                            for (int i = 0; i < count; i++)
                            {
                                bool alreadyPrinted = false;

                                for (int j = 0; j < i; j++)
                                {
                                    if (products[i].Category.ToLower() == products[j].Category.ToLower())
                                    {
                                        alreadyPrinted = true;
                                        break;
                                    }
                                }

                                if (!alreadyPrinted)
                                {
                                    Console.WriteLine(products[i].Category);
                                }
                            }

                            Console.Write("Enter category to search: ");
                            string search = Console.ReadLine().ToLower();

                            bool found = false;

                            for (int i = 0; i < count; i++)
                            {
                                if (products[i].Category.ToLower().Contains(search))
                                {
                                    Console.WriteLine($"{products[i].Id} - {products[i].Name} - PHP {products[i].Price} - Stock: {products[i].Stock}");
                                    found = true;
                                }
                            }

                            if (!found)
                                Console.WriteLine("No products found in that category.");

                            Console.Write("Do you want to search another category? (y/n): ");
                            proceed = Console.ReadLine().ToLower();

                            if (proceed != "y")
                            {
                                Console.WriteLine("Returning to menu...\n");
                            }

                        } while (proceed == "y");
                    }
                    else if (cartChoice == "7")
                    {
                        if (historyCount == 0)
                        {
                            Console.WriteLine("No order history.");
                        }
                        else
                        {
                            Console.WriteLine("ORDER HISTORY");

                            for (int i = 0; i < historyCount; i++)
                            {
                                Console.WriteLine($"Receipt No: {history[i].ReceiptNumber}");
                                Console.WriteLine($"Date: {history[i].Date}");
                                Console.WriteLine($"Final Total: PHP {history[i].FinalTotal}");
                                Console.WriteLine("-------------------------");
                            }
                        }
                    }
                    else if (cartChoice == "8")
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


