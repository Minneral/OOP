using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_8;

public class Product
{
    public string Name { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public byte[] Image { get; set; }

    public Product(string name, string description, float price, byte[] image)
    {
        Name = name;
        Description = description;
        Price = price;
        Image = image;
    }
    public Product()
    {
        Name = "";
        Description = "";
        Price = 0;
        Image = null;
    }
}
