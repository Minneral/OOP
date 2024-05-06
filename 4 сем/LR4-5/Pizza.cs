using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR4_5;

class Pizza
{ 
    public string Name { get; set; }
    public string Description { get; set; }
    public string FullDescription { get; set; }
    public float Price { get; set; }
    public string ImageUrl { get; set; }
    public Pizza(string name = default(string), string description = default(string), string fullDescription = default(string), float price = 0, string imageUrl = default(string))
    {
        Name = name;
        Description = description;
        FullDescription = fullDescription;
        Price = price;
        ImageUrl = imageUrl;
    }
}
