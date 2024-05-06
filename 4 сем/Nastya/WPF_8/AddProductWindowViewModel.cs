using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_8;

public class AddProductWindowViewModel : INotifyPropertyChanged
{
	public MainWindowViewModel mw;

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

	private string price;

	public string Price
	{
		get { return price; }
		set
		{
			price = value;
			OnPropertyChanged();
		}
	}

	private string imagePath;

	public string ImagePath
	{
		get { return imagePath; }
		set
		{
			imagePath = value;
			OnPropertyChanged();
		}
	}

	public RelayCommand PickImageCommand { get; }
	public RelayCommand AddCommand { get; }


	public AddProductWindowViewModel()
	{
		PickImageCommand = new RelayCommand(o => PickImageCommand_Execute());
		AddCommand = new RelayCommand(o => AddCommand_Execute());
    }

    private void PickImageCommand_Execute()
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Изображения (*.jpg;*.jpeg;*.png;*.gif;*.bmp)|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Все файлы (*.*)|*.*";

        if (openFileDialog.ShowDialog() == true)
        {
            ImagePath = openFileDialog.FileName;
        }
    }

	private void AddCommand_Execute()
	{
		if(Validate())
		{
			mw.AddProduct(new Product(Name, Description, float.Parse(Price), File.ReadAllBytes(ImagePath)));
			MessageBox.Show("Объект добавлен!");
		}
	}

	private bool Validate()
	{
		return true;
	}

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }

}
