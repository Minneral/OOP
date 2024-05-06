namespace LAB5;

public abstract class Product
{
    //public string Type { get; set; }
    public string Name { get; set; }
    public string Price { get; set; }
    public eType Type { get; set; }
    public enum eType
    {
        Monitor, Screen, PC, EarBuds, Table, Projector
    }
 
    public Product(eType type, string name, string price)
    {
        Type = type;
        Name = name;
        Price = price;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Price);

        Enum.GetNames(typeof(Type));
        
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
}
