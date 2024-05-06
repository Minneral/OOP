using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF8;

/// <summary>
/// Логика взаимодействия для AddProductWindow.xaml
/// </summary>
public partial class AddProductDBWindow : Window
{
    public RelayCommand AddProductCommand { get; }

    private string productName;
    public string ProductName
    {
        get { return productName; }
        set
        {
            productName = value;
        }
    }

    private string description;
    public string Description
    {
        get { return description; }
        set
        {
            description = value;
        }
    }

    private string fullDescription;
    public string FullDescription
    {
        get { return fullDescription; }
        set
        {
            fullDescription = value;
        }
    }

    private string imageUrl;
    public string ImageUrl
    {
        get { return imageUrl; }
        set
        {
            imageUrl = value;
        }
    }

    private float price;
    public float Price
    {
        get { return price; }
        set
        {
            price = value;
        }
    }

    public AddProductDBWindow()
    {
        InitializeComponent();

        MainWindow dbWindow = (MainWindow)Owner;

        AddProductCommand = new RelayCommand(o =>
        {
            if (Validate())
            {
                var product = new Product(ProductName, Description, FullDescription, ImageUrl, Price);
                ((MainWindow)Owner).AddProduct(product);

                MessageBox.Show("Продукт добавлен!");

                this.Close();
            }
        });
    }

    bool Validate()
    {
        bool result = true;

        if (productName == String.Empty ||
            Description == String.Empty ||
            FullDescription == String.Empty ||
            ImageUrl == String.Empty)
        {
            result = false;
            MessageBox.Show("Поля не должны быть пустыми!");
        }

        if(Price < 0)
        {
            result = false;
            MessageBox.Show("Цена не может быть отрицательной");
        }

        return result;
    }
}
