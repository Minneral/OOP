using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF4_5.MVVM.Model;

namespace WPF4_5.MVVM.ViewModel;

class HomeViewModel
{
    public ObservableCollection<PizzaModel> PizzaList { get; set; }
	public HomeViewModel()
	{
		PizzaList = new ObservableCollection<PizzaModel>()
		{
			new PizzaModel("Пепперони", "Вкусная пицца", "Очень вкусная пицца", 10, "https://dodopizza-a.akamaihd.net/static/Img/Products/70834e6311c0483493bf2279dbc1718d_292x292.webp"),
			new PizzaModel("Мясная", "Вкусная пицца", "Очень вкусная пицца", 16, "https://dodopizza-a.akamaihd.net/static/Img/Products/4fa4de77d8a34912830cfdbedfaff698_292x292.webp"),
			new PizzaModel("Маргарита", "Вкусная пицца", "Очень вкусная пицца", 8, "https://dodopizza-a.akamaihd.net/static/Img/Products/a10ad669c5054be2b019613e5cfd2477_292x292.webp"),
			new PizzaModel("Гавайская", "Вкусная пицца", "Очень вкусная пицца", 10, "https://dodopizza-a.akamaihd.net/static/Img/Products/c16bf6aa92ba4792805e1a3d4522ab65_292x292.webp")
		};
	}
}
