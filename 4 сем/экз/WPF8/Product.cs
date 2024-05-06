using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF8;

public interface IMemento
{
	void Restore();
}

[Serializable]
public class Product : ObservableObject
{
	public static int identity = 1;
	public int Id { get; }
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
		Id = identity++;
		Name = name;
		Description = description;
		FullDescription = fullDescription;
		ImageUrl = imageUrl;
		Price = price;
	}

    public Product(int id, string name = "name", string description = "description", string fullDescription = "fulldescription", string imageUrl = "", float price = 0)
    {
        Id = id;
        Name = name;
        Description = description;
        FullDescription = fullDescription;
        ImageUrl = imageUrl;
        Price = price;
    }

    public Product()
	{
		Id = identity++;
        Name = "name";
        Description = "description";
        FullDescription = "fullDescription";
        ImageUrl = "ImageUrl";
        Price = 0;
    }

	public ProductMemento CreateMemento()
	{
		return new ProductMemento(this);
	}
}



public class ProductMemento : IMemento
{
	public readonly Product product;
	private readonly string name;
	private readonly string description;
	private readonly string fullDescription;
	private readonly string imageUrl;
	private readonly float price;

    public ProductMemento(Product product)
	{
		this.product = product;
		this.name = product.Name;
		this.description = product.Description;
		this.fullDescription = product.FullDescription;
		imageUrl = product.ImageUrl;
		price = product.Price;
	}

	public void Restore()
	{
		product.Name = name;
		product.Description = description;
		product.FullDescription = fullDescription;
		product.ImageUrl = imageUrl;
		product.Price = price;
	}
}