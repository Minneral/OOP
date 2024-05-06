using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF4_5.Core;

namespace WPF4_5.MVVM.ViewModel;

class MainViewModel : ObservableObject
{
	public RelayCommand HomeViewCommand { get; set; }
	public RelayCommand SnacksViewCommand { get; set; }
	public RelayCommand DrinksViewCommand { get; set; }
	public RelayCommand AddItemCommand { get; set; }
	public HomeViewModel HomeVM { get; set; }
	public SnacksViewModel SnacksVM { get; set; }
	public DrinksViewModel DrinksVM { get; set; }
	public AddItemViewModel AddItemVM { get; set; }

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
		HomeVM = new HomeViewModel();
		SnacksVM = new SnacksViewModel();
		DrinksVM = new DrinksViewModel();
		AddItemVM = new AddItemViewModel();
		_currentView = HomeVM;

		HomeViewCommand = new RelayCommand(o => CurrentView = HomeVM);
		SnacksViewCommand = new RelayCommand(o => CurrentView = SnacksVM);
		DrinksViewCommand = new RelayCommand(o => CurrentView = DrinksVM);
		AddItemCommand = new RelayCommand(o => CurrentView = AddItemVM);
    }
}
