using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR4.MVVM.Model;

internal class Pizza
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string FullDescription { get; set; }
    public float Price { get; set; }

    public Pizza(string name, string description, string fullDescription, float price)
    {
        Name = name;
        Description = description;
        FullDescription = fullDescription;
        Price = price;
    }
}
