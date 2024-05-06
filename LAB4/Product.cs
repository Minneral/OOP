namespace LAB4;

public abstract class Product
{
    public string Type { get; set; }
    public string Name { get; set; }
    public string Price { get; set; }

    public Product(string type, string name, string price)
    {
        Type = type;
        Name = name;
        Price = price;
    }

    //public abstract void Sold();

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Price);
    }
    public override bool Equals(object? obj)
    {
        return Equals(obj as Product);
    }
    public bool Equals(Product? other)
    {
        return other != null && other.Name == Name && other.Price == Price && other.Type == Type;
    }
    public override string ToString()
    {
        return $"Type: {Type}\nName: {Name} | Price: {Price}";
    }

    public abstract void SayHi();
}
