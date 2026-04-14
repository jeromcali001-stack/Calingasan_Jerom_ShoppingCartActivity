using System;

class Program
{
    static void Main()
    {
        string[] products = { "Keyboard", "Mouse", "Monitor" };
        int[] prices = { 500, 300, 7000 };
        int[] stock = { 10, 15, 5 };

        Console.WriteLine("=== STORE MENU ===");

        for (int i = 0; i < products.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {products[i]} - {prices[i]} (Stock: {stock[i]})");
        }

        Console.Write("\nChoose product number: ");
        int choice = int.Parse(Console.ReadLine());

        if (choice < 1 || choice > products.Length)
        {
            Console.WriteLine("Invalid product selection!");
        }
        else
        {
            int index = choice - 1;

            Console.WriteLine($"You selected: {products[index]}");
            Console.WriteLine($"Price: {prices[index]}");
            Console.WriteLine($"Stock: {stock[index]}");
        }
    }
}