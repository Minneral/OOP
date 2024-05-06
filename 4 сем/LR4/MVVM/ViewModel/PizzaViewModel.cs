using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LR4.MVVM.Model;

namespace LR4.MVVM.ViewModel;

internal class PizzaViewModel
{
    ObservableCollection<Pizza> PizzaList;

	public PizzaViewModel()
	{
		PizzaList = new ObservableCollection<Pizza>()
		{
			new Pizza("Пепперони", "Очень вкусная", "Наверное, самая вкусная", 10),
			new Pizza("Мясная", "Очень вкусная", "Наверное, самая вкусная", 10),
            new Pizza("Гавайская", "Очень вкусная", "Наверное, самая вкусная", 10),
            new Pizza("Маргарита", "Очень вкусная", "Наверное, самая вкусная", 10),
        };

    }
}
