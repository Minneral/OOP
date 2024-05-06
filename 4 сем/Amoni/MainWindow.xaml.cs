﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
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
using System.Windows.Navigation;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace Amoni
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private ObservableCollection<Product> products { get; } = new ObservableCollection<Product>();
        public RelayCommand DeleteProductCommand { get; }
        public RelayCommand EditProductCommand { get; }
        public RelayCommand AddProductCommand { get; }
        public RelayCommand ChangeLangEnCommand { get; }
        public RelayCommand ChangeLangRuCommand { get; }
        public RelayCommand SaveDataCommand { get; }
        public RelayCommand ImportDataCommand { get; }
        public XmlSerializer formatter;

        private string searchField;

        public string SearchField
        {
            get { return searchField; }
            set
            {
                searchField = value;
                OnPropertyChanged();
                Search();
            }
        }

        private string lowerPrice;

        public string LowerPrice
        {
            get { return lowerPrice; }
            set
            {
                lowerPrice = value;
                OnPropertyChanged();
                Search();
            }
        }

        private string upperPrice;

        public string UpperPrice
        {
            get { return upperPrice; }
            set
            {
                upperPrice = value;
                OnPropertyChanged();
                Search();
            }
        }



        public MainWindow()
        {
            InitializeComponent();
            LoadLanguageResources();
            LoadThemeResources();
            products.Add(new Product("Пепперони", "Вкусная", "Очень вкусная", "https://dodopizza-a.akamaihd.net/static/Img/Products/70834e6311c0483493bf2279dbc1718d_292x292.webp", 10));
            products.Add(new Product("Двойная пепперони", "Вкусная", "Очень вкусная", "https://dodopizza-a.akamaihd.net/static/Img/Products/68826b8afe1f45369e33db7b3ab44ef5_292x292.webp", 12));
            products.Add(new Product("Мясная", "Вкусная", "Очень вкусная", "https://dodopizza-a.akamaihd.net/static/Img/Products/4fa4de77d8a34912830cfdbedfaff698_292x292.webp", 14));
            products.Add(new Product("Сырная", "Вкусная", "Очень вкусная", "https://dodopizza-a.akamaihd.net/static/Img/Products/c04ab5bb5c824108ac857043bc8f8751_292x292.webp", 7));
            listView.ItemsSource = products;

            DeleteProductCommand = new RelayCommand(o => ExecuteDeleteProductCommand(o));
            EditProductCommand = new RelayCommand(o => ExecuteEditProductCommand(o));
            AddProductCommand = new RelayCommand(o => ExecuteAddProductCommand());
            ChangeLangEnCommand = new RelayCommand(o => ExecuteChangeLangEnCommand());
            ChangeLangRuCommand = new RelayCommand(o => ExecuteChangeLangRuCommand());
            SaveDataCommand = new RelayCommand(o => ExecuteSaveDataCommand());
            ImportDataCommand = new RelayCommand(o => ExecuteImportDataCommand());

            formatter = new XmlSerializer(typeof(List<Product>));


            StreamResourceInfo sri = Application.GetResourceStream(new Uri("pack://application:,,,/Resources/pointer.ani"));
            Cursor customCursor = new Cursor(sri.Stream);
            this.Cursor = customCursor;
        }

        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        void ExecuteDeleteProductCommand(object parameter)
        {
            var product = (Product)parameter;
            products.Remove(product);
        }

        void ExecuteAddProductCommand()
        {
            new AddProductWindow().ShowDialog();
        }

        void ExecuteEditProductCommand(object parameter)
        {
            var product = (Product)parameter;

            new EditProductWindow(product).ShowDialog();
        }
        void ExecuteSaveDataCommand()
        {
            SaveFileDialog file = new SaveFileDialog();
            if(file.ShowDialog() == true)
            {
                string fileName = file.FileName;

                using(FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    formatter.Serialize(fs, products.ToList());
                }

                MessageBox.Show("OK");
            }
        }

        void ExecuteImportDataCommand()
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == true)
            {
                string fileName = file.FileName;

                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    var list = (List<Product>)formatter.Deserialize(fs);

                    products.Clear();

                    foreach(var item in list)
                    {
                        products.Add(item);
                    }
                }

                MessageBox.Show("OK");
            }
        }

        void ExecuteChangeLangEnCommand()
        {
            var resourceFile = "/Resources/lang-en.xaml";

            // Загрузка русского словаря ресурсов
            var dictionary = new ResourceDictionary { Source = new Uri(resourceFile, UriKind.Relative) };
            Application.Current.Resources.MergedDictionaries[2] = dictionary;
            Application.Current.Resources.MergedDictionaries.Clear();
        }

        void ExecuteChangeLangRuCommand()
        {
            var resourceFile = "/Resources/lang-ru.xaml";

            // Загрузка русского словаря ресурсов
            var dictionary = new ResourceDictionary { Source = new Uri(resourceFile, UriKind.Relative) };
            Application.Current.Resources.MergedDictionaries[0] = dictionary;
        }

        void LoadLanguageResources()
        {
            // Determine the current culture of the application
            CultureInfo culture = CultureInfo.CurrentCulture;

            // Load the corresponding resource dictionary for the selected culture
            ResourceDictionary dict = new ResourceDictionary();

            if (culture.Name == "ru-BY")
            {
                dict.Source = new Uri("/Resources/lang-ru.xaml", UriKind.Relative);
            }
            else // Default to English if the selected culture is not supported
            {
                dict.Source = new Uri("/Resources/lang-en.xaml", UriKind.Relative);
            }

            // Merge the resource dictionary with the application's resources
            Application.Current.Resources.MergedDictionaries.Add(dict);
        }

        void LoadThemeResources()
        {
            ResourceDictionary dict = new ResourceDictionary();
            dict.Source = new Uri("/Resources/DarkTheme.xaml", UriKind.Relative);
            Application.Current.Resources.MergedDictionaries.Add(dict);
        }

        void ExecuteChangeThemeCommand()
        {
            var appRes = Application.Current.Resources;
            switch(appRes.MergedDictionaries[1].Source.ToString())
            {
                case "/Resources/LightTheme.xaml":
                    appRes.MergedDictionaries[1].Source = new Uri("Resources/DarkTheme.xaml", UriKind.Relative);
                    break;
                case "/Resources/DarkTheme.xaml":
                    appRes.MergedDictionaries[1].Source = new Uri("Resources/LightTheme.xaml", UriKind.Relative);
                    break;
            }
            var resourceFile = "/Resources/lang-ru.xaml";

            var dictionary = new ResourceDictionary { Source = new Uri(resourceFile, UriKind.Relative) };
            Application.Current.Resources.MergedDictionaries[0] = dictionary;
        }

        void Search()
        {
            List<Product> list = products.ToList<Product>();
            List<Product> result = new List<Product>();

            if (searchField != null && searchField != "")
            {
                result = list.Where(t => t.Name.ToLower().Contains(searchField.ToLower())).ToList();

                if (LowerPrice != null && lowerPrice != "")
                {
                    result = result.Where(t => t.Price >= double.Parse(lowerPrice)).ToList();
                }

                if (UpperPrice != null && upperPrice != "")
                {
                    result = result.Where(t => t.Price <= double.Parse(upperPrice)).ToList();
                }
            }
            else
            {
                if (LowerPrice != null && lowerPrice != "")
                {
                    result = list.Where(t => t.Price >= double.Parse(lowerPrice)).ToList();

                    if (UpperPrice != null && upperPrice != "")
                    {
                        result = result.Where(t => t.Price <= double.Parse(upperPrice)).ToList();
                    }
                }
                else
                {

                    if (UpperPrice != null && upperPrice != "")
                    {
                        result = list.Where(t => t.Price <= double.Parse(upperPrice)).ToList();

                        if (LowerPrice != null && lowerPrice != "")
                        {
                            result = result.Where(t => t.Price <= double.Parse(lowerPrice)).ToList();
                        }
                    }
                    else
                    {
                        result = list;
                    }
                }
            }

            listView.ItemsSource = new ObservableCollection<Product>(result);
        }

        public void AddProduct(object product)
        {
            products.Add((Product)product);
        }
    }
}
