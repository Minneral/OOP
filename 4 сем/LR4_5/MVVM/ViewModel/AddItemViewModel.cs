using LR4_5.Core;
using LR4_5.MVVM.Model;
using LR4_5.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LR4_5.MVVM.ViewModel;

class AddItemViewModel : ObservableObject
{
    public RelayCommand AddProductCommand { get; set; }

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

	private MainViewModel mainViewModel = (MainViewModel)Application.Current.MainWindow.DataContext;

    public AddItemViewModel()
	{
        AddProductCommand = new RelayCommand(o =>
		{
			Product product = new Product(Name, Description, FullDescription, Price, ImageUrl);

			switch(mainViewModel.CurrentType)
			{
				case ProductType.Pizza:
					mainViewModel.PizzaVM.PizzaList.Add(product);
					break;
                case ProductType.Drink:
                    mainViewModel.DrinkVM.DrinkList.Add(product);
                    break;
                case ProductType.Snack:
                    mainViewModel.SnackVM.SnackList.Add(product);
                    break;
            }

			MessageBox.Show("Товар добавлен!");
		});	
	}

}
