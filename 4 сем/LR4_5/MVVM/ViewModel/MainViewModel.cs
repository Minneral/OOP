using LR4_5.Core;
using LR4_5.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LR4_5.MVVM.ViewModel;

public enum ProductType
{
	Pizza, Drink, Snack
}

internal class MainViewModel : ObservableObject
{
	public RelayCommand AddProductCommand { get; set; }
	public RelayCommand ShowPizzaCommand { get; set; }
	public RelayCommand ShowSnackCommand { get; set; }
	public RelayCommand ShowDrinkCommand { get; set; }
	public RelayCommand OpenProductProfileCommand { get; set; }
	public PizzaViewModel PizzaVM { get; set; }
	public SnackViewModel SnackVM { get; set; }
	public DrinkViewModel DrinkVM { get; set; }
	public AddItemViewModel AddItemVM { get; set; }
	public ProductType CurrentType { get; set; }

	private object _currentView;

	public object CurrentView
	{
		get { return _currentView; }
		set 
		{
			_currentView = value;
			OnPropertyChanged();
		}
	}

	public MainViewModel()
	{
        
		ShowPizzaCommand = new RelayCommand(o => { CurrentView = PizzaVM; CurrentType = ProductType.Pizza; });
		ShowDrinkCommand = new RelayCommand(o => { CurrentView = DrinkVM; CurrentType = ProductType.Drink; });
		ShowSnackCommand = new RelayCommand(o => { CurrentView = SnackVM; CurrentType = ProductType.Snack; });
		AddProductCommand = new RelayCommand(o => CurrentView = AddItemVM);
		OpenProductProfileCommand = new RelayCommand(ExecuteOpenProductProfileCommand);

        SnackVM = new SnackViewModel();
        DrinkVM = new DrinkViewModel();
        PizzaVM = new PizzaViewModel();
        AddItemVM = new AddItemViewModel();
        CurrentView = PizzaVM;

    }

    private void ExecuteOpenProductProfileCommand(object o)
	{
		Product product = (Product)o;
		MessageBox.Show("Окно " + product.Name);
	}
}
