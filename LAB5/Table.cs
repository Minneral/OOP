namespace LAB5;

struct MaterialsCost
{
    public int oak = 80;
    public int pine = 60;
    public int birch = 70;
    public int wood = 45;
    public MaterialsCost() { }
}

public class Table : Product
{
    
    public string Width { get; set; }
    public string Height { get; set; }
    public string Shape {get; set; }

    public Table(string name, string material, string width, string height, string shape)
        : base(eType.Table, name, CalcPrice(material, width, height))
    {
        Width = width;
        Height = height;
        Shape = shape;
    }

    public static string CalcPrice(string typeOfWood, string width, string height)
    {
        float price;
        float iWidth = (float)Convert.ToDouble(width);
        float iHeight = (float)Convert.ToDouble(height);

        switch (typeOfWood.ToLower())
        {
            case "oak":
                price = (new MaterialsCost().oak) * iWidth * iHeight;
                break;
            case "birch":
                price = (new MaterialsCost().birch) * iWidth * iHeight;
                break;
            case "pine":
                price = (new MaterialsCost().pine) * iWidth * iHeight;
                break;
            default:
                price = (new MaterialsCost().wood) * iWidth * iHeight;
                break;
        }

        return price.ToString();
    }

    public override string ToString()
    {
        return base.ToString() + $"\nShape: {Shape} | Width: {Width} | Height: {Height}";
    }

}
