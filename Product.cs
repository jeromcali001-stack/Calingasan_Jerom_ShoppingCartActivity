class Product
{
    public int Id;
    public string Name;
    public double Price;
    public int Stock = 100;
    public string Category;

    public bool IsLowStock()
    {
        return Stock < 10;
    }
}