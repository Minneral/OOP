using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoni;

[Serializable]
public class Product : ObservableObject
{
	private string name;
	public string Name
	{
		get { return name; }
		set
		{
			name = value;
			OnPropertyChanged();
		}
	}

	private string description;
	public string Description
	{
		get { return description; }
		set
		{
			description = value;
			OnPropertyChanged();
		}
	}

	private string fullDescription;
	public string FullDescription
	{
		get { return fullDescription; }
		set
		{
			fullDescription = value;
			OnPropertyChanged();
		}
	}

	private string imageUrl;
	public string ImageUrl
	{
		get { return imageUrl; }
		set
		{
			imageUrl = value;
			OnPropertyChanged();
		}
	}

	private float price;
	public float Price
	{
		get { return price; }
		set
		{
			price = value;
			OnPropertyChanged();
		}
	}

	public Product(string name = "name", string description = "description", string fullDescription = "fulldescription", string imageUrl = "", float price = 0)
	{
		Name = name;
		Description = description;
		FullDescription = fullDescription;
		ImageUrl = imageUrl;
		Price = price;
	}

	public Product()
	{
        Name = "name";
        Description = "description";
        FullDescription = "fullDescription";
        ImageUrl = "ImageUrl";
        Price = 0;
    }

}
