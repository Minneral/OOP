using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LR4.Core;

namespace LR4.MVVM.ViewModel;

internal class MainViewModel : ObservableObject
{
	public PizzaViewModel PizzaVM { get; set; }
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
		PizzaVM = new PizzaViewModel();
		CurrentView = PizzaVM;
	}

}
