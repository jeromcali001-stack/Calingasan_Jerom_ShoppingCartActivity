class Product
{
    public int Id;
    public string Name;
    public double Price;
    public int Stock = 100;
    public string Category;

    public void DisplayProduct()
    {
        Console.WriteLine($"{Id}. {Name} - {Price} (Stock: {Stock})");
    }

    public bool IsLowStock()
    {
        return Stock < 10;
    }
}