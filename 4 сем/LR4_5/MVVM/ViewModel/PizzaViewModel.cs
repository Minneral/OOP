using LR4_5.Core;
using LR4_5.MVVM.Model;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR4_5.MVVM.ViewModel;

class PizzaViewModel : ObservableObject
{
	public ObservableCollection<Product> PizzaList { get; set; }

	//private readonly MainViewModel mainViewModel = (MainViewModel)Application.Current.MainWindow.DataContext;
	public RelayCommand OpenProductProfileCommand { get; set; }

	public PizzaViewModel()
	{
		PizzaList = new ObservableCollection<Product>()
		{
			new Product("Пепперони", "Вкусная", "Очень вкусная", 12, "https://dodopizza-a.akamaihd.net/static/Img/Products/70834e6311c0483493bf2279dbc1718d_292x292.webp"),
			new Product("Мясная", "Вкусная", "Очень вкусная", 16, "https://dodopizza-a.akamaihd.net/static/Img/Products/4fa4de77d8a34912830cfdbedfaff698_292x292.webp"),
			new Product("Гавайская", "Вкусная", "Очень вкусная", 12, "https://dodopizza-a.akamaihd.net/static/Img/Products/c16bf6aa92ba4792805e1a3d4522ab65_292x292.webp"),
			new Product("Маргарита", "Вкусная", "Очень вкусная", 8, "https://dodopizza-a.akamaihd.net/static/Img/Products/a10ad669c5054be2b019613e5cfd2477_292x292.webp")
		};

		OpenProductProfileCommand = new RelayCommand(o =>
		{
			//mainViewModel.OpenProductProfileCommand.Execute(this);
		});
    }
}
