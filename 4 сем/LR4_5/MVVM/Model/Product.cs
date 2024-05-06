using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR4_5.MVVM.Model;

internal class Product
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string FullDescription { get; set; }
    public float Price { get; set; }
    public string ImageUrl { get; set; }
    public Product(string name, string description, string fullDescription, float price, string imageUrl)
    {
        Name = name;
        Description = description;
        FullDescription = fullDescription;
        Price = price;
        ImageUrl = imageUrl;
    }
}
