using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
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

namespace Amoni
{
    /// <summary>
    /// Логика взаимодействия для EditProductWindow.xaml
    /// </summary>
    public partial class EditProductWindow : Window, INotifyPropertyChanged
    {

        public RelayCommand SaveChangesCommand { get; }

        private string productName;
        public string ProductName
        {
            get { return productName; }
            set
            {
                productName = value;
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

        private float price;

        public event PropertyChangedEventHandler? PropertyChanged;

        public float Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged();
            }
        }
        public EditProductWindow(object parameter)
        {
            InitializeComponent();

            Product product = (Product)parameter;
            ProductName = product.Name;
            Description = product.Description;
            FullDescription = product.FullDescription;
            Price = product.Price;
            ImageUrl = product.ImageUrl;

            SaveChangesCommand = new RelayCommand(o => ExecuteSaveChangesCommand(parameter));
        }

        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        void ExecuteSaveChangesCommand(object parameter)
        {
            Product product = (Product)parameter;
            product.Name = ProductName;
            product.Description = Description;
            product.FullDescription = FullDescription;
            product.Price = Price;
            product.ImageUrl = ImageUrl;

            MessageBox.Show("Продукт изменен!");

            this.Close();
        }
    }
}
