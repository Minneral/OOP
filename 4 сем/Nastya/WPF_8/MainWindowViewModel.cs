using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WPF_8;

public class MainWindowViewModel : INotifyPropertyChanged
{
    string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

    private ObservableCollection<Product> products;

    public ObservableCollection<Product> Products
    {
        get { return products; }
        set
        {
            products = value;
            OnPropertyChanged();
        }
    }

    public RelayCommand AddProductCommand { get; }
    public RelayCommand DataGridSelectedChangedCommand { get; }
    public RelayCommand EditProductCommand { get; }

    private string name;
    private string description;
    private string price;
    private BitmapImage image;
    DataGrid dg;
    

    public BitmapImage Image
    {
        get { return image; }
        set
        {
            Image = value;
        }
    }


    public string Name
    {
        get { return name; }
        set
        {
            name = value;
            OnPropertyChanged();
        }
    }

    public string Description
    {
        get { return description; }
        set
        {
            description = value;
            OnPropertyChanged();
        }
    }
    public string Price
    {
        get { return price; }
        set
        {
            price = value;
            OnPropertyChanged();
        }
    }


    public MainWindowViewModel()
    {
        AddProductCommand = new RelayCommand(o => AddProductCommand_Execute());
        DataGridSelectedChangedCommand = new RelayCommand(o => DataGridSelectedChangedCommand_Execute(o));
        EditProductCommand = new RelayCommand(o => EditProductCommand_Execute());
        products = new ObservableCollection<Product>();

        products.Add(new Product("Pizza", "Descr", 10, File.ReadAllBytes("C:\\\\Users\\\\Еван\\\\OneDrive\\\\Изображения\\\\Снимки экрана\\\\screen1.png")));
    }


    public void DataGridSelectedChangedCommand_Execute(object parameter)
    {
        var selectedItems = ((DataGrid)parameter).SelectedItems;
        var selectedItem = ((DataGrid)parameter).SelectedItem;

        if (selectedItems.Count > 0 && selectedItem.ToString() != "{NewItemPlaceholder}")
        {
            var product = (Product)selectedItems[0];
            dg = (DataGrid)parameter;

            this.Name = product.Name;
            this.Description = product.Description;
            this.Price = product.Price.ToString();

            using (MemoryStream memoryStream = new MemoryStream(product.Image))
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = memoryStream;
                bitmapImage.EndInit();

                this.image = bitmapImage;
                OnPropertyChanged(nameof(Image));
            }
        }
    }

    void AddProductCommand_Execute()
    {
        var window = new AddProductWindow();
        ((AddProductWindowViewModel)window.DataContext).mw = this;
        window.ShowDialog();
    }

    void EditProductCommand_Execute()
    {
        var window = new EditProductWindow();
        ((EditProductWindowViewModel)window.DataContext).mw = this;
        ((EditProductWindowViewModel)window.DataContext).Product = (Product)dg.SelectedItem;
        window.ShowDialog();
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
}
