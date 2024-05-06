using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

namespace Amoni
{
    /// <summary>
    /// Логика взаимодействия для DataBaseWindow.xaml
    /// </summary>
    public partial class DataBaseWindow : Window
    {
        SqlConnection connection;
        ObservableCollection<Product> products = new ObservableCollection<Product>();
        ObservableCollection<Product> productsShow = new ObservableCollection<Product>();
        int currentBeginIndex;
        public RelayCommand GetProductsCommand { get; set; }
        public RelayCommand InitAppFromDBCommand { get; set; }
        public RelayCommand InsertProductCommand { get; set; }
        public RelayCommand DeleteSelectedProductsCommand { get; set; }
        public RelayCommand EditProductCommand { get; set; }

        public RelayCommand NextPageCommand { get; set; }
        public RelayCommand PrevPageCommand { get; set; }
        public DataBaseWindow()
        {
            InitializeComponent();

            dataGrid.ItemsSource = products;
            currentBeginIndex = 0;
            nextBtn.IsEnabled = false;
            prevBtn.IsEnabled = false;

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            try
            {
                connection = new SqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения к базе данных: " + ex.Message);
            }

            GetProductsCommand = new RelayCommand(o => ExecuteGetProductsCommand());
            InitAppFromDBCommand = new RelayCommand(o => ExecuteInitAppFromDBCommand());
            InsertProductCommand = new RelayCommand(o=> ExecuteInsertProductCommand());
            DeleteSelectedProductsCommand = new RelayCommand(o => ExecuteDeleteSelectedProductsCommand());
            EditProductCommand = new RelayCommand(o => ExecuteEditProductCommand());
            NextPageCommand = new RelayCommand(o => ExecuteNextPageCommand());
            PrevPageCommand = new RelayCommand(o => ExecutePrevPageCommand());
        }

        void ExecuteGetProductsCommand()
        {
            products.Clear();
            connection.Open();
            var command = new SqlCommand("sp_GetProducts", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string name = reader.GetString(0);
                    string description = reader.GetString(1);
                    string fullDescription = reader.GetString(2);
                    float price = (float)reader.GetDecimal(3);
                    string url = reader.GetString(4);

                    products.Add(new Product(name, description, fullDescription, url, price));
                }
            }

            if (products.Count > 0)
            {
                dataGrid.ItemsSource = productsShow;
                currentBeginIndex = 0;

                if(products.Count > 20)
                {
                    nextBtn.IsEnabled = true;
                }

                for(int i = 0; i < products.Count; i++)
                {
                    if (i == 20)
                        break;
                    productsShow.Add(products[i]);
                }
                dataGrid.SelectedIndex = currentBeginIndex;
                dataGrid.Focus();
            }
            reader.Close();
            connection.Close();
        }
        void ExecuteInitAppFromDBCommand()
        {
            var mainProd = ((MainWindow)Application.Current.MainWindow).products;
            mainProd.Clear();
            
            foreach(var item in products)
            {
                mainProd.Add(item);
            }
        }
        public void AddProduct(Product product)
        {
            connection.Open();

            SqlCommand command = new SqlCommand("sp_InsertProduct", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter nameParam = new SqlParameter
            {
                ParameterName = "@name",
                Value = product.Name
            };
            command.Parameters.Add(nameParam);

            SqlParameter descriptionParam = new SqlParameter
            {
                ParameterName = "@description",
                Value = product.Description
            };
            command.Parameters.Add(descriptionParam);

            SqlParameter fullDescriptionParam = new SqlParameter
            {
                ParameterName = "@fullDescription",
                Value = product.FullDescription
            };
            command.Parameters.Add(fullDescriptionParam);

            SqlParameter priceParam = new SqlParameter
            {
                ParameterName = "@price",
                Value = product.Price
            };
            command.Parameters.Add(priceParam);

            SqlParameter urlParam = new SqlParameter
            {
                ParameterName = "@url",
                Value = product.ImageUrl
            };
            command.Parameters.Add(urlParam);

            command.ExecuteNonQuery();

            products.Add(product);

            connection.Close();
        }
        public void EditProduct(Product product)
        {
            if(dataGrid.SelectedItems.Count == 1)
            {
                connection.Open();
                Product old = (Product)dataGrid.SelectedItems[0];

                SqlCommand command = new SqlCommand("sp_EditProduct", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = old.Name
                };
                command.Parameters.Add(nameParam);

                SqlParameter descriptionParam = new SqlParameter
                {
                    ParameterName = "@description",
                    Value = old.Description
                };
                command.Parameters.Add(descriptionParam);

                SqlParameter fullDescriptionParam = new SqlParameter
                {
                    ParameterName = "@fullDescription",
                    Value = old.FullDescription
                };
                command.Parameters.Add(fullDescriptionParam);

                SqlParameter priceParam = new SqlParameter
                {
                    ParameterName = "@price",
                    Value = old.Price
                };
                command.Parameters.Add(priceParam);

                SqlParameter urlParam = new SqlParameter
                {
                    ParameterName = "@url",
                    Value = old.ImageUrl
                };
                command.Parameters.Add(urlParam);

                // ---- new params

                SqlParameter nameParamNew = new SqlParameter
                {
                    ParameterName = "@name_new",
                    Value = product.Name
                };
                command.Parameters.Add(nameParamNew);

                SqlParameter descriptionParamNew = new SqlParameter
                {
                    ParameterName = "@description_new",
                    Value = product.Description
                };
                command.Parameters.Add(descriptionParamNew);

                SqlParameter fullDescriptionParamNew = new SqlParameter
                {
                    ParameterName = "@fullDescription_new",
                    Value = product.FullDescription
                };
                command.Parameters.Add(fullDescriptionParamNew);

                SqlParameter priceParamNew = new SqlParameter
                {
                    ParameterName = "@price_new",
                    Value = product.Price
                };
                command.Parameters.Add(priceParamNew);

                SqlParameter urlParamNew = new SqlParameter
                {
                    ParameterName = "@url_new",
                    Value = product.ImageUrl
                };
                command.Parameters.Add(urlParamNew);

                command.ExecuteNonQuery();

                old.Name=product.Name;
                old.Description = product.Description;
                old.FullDescription = product.FullDescription; ;
                old.Price = product.Price;
                old.ImageUrl = product.ImageUrl;

                MessageBox.Show("Изменения применены!");
                connection.Close();
            }
        }
        void ExecuteInsertProductCommand()
        {
            AddProductDBWindow wind = new AddProductDBWindow();
            wind.Owner = this;
            wind.Show();
        }
        void ExecuteDeleteSelectedProductsCommand()
        {
            if (dataGrid.SelectedItems.Count > 0)
            {

                connection.Open();

                for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
                {
                    Product product = (Product)dataGrid.SelectedItems[i];
                    products.Remove(product);

                    SqlCommand command = new SqlCommand("sp_DeleteProduct", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter nameParam = new SqlParameter
                    {
                        ParameterName = "@name",
                        Value = product.Name
                    };
                    command.Parameters.Add(nameParam);

                    SqlParameter descriptionParam = new SqlParameter
                    {
                        ParameterName = "@description",
                        Value = product.Description
                    };
                    command.Parameters.Add(descriptionParam);

                    SqlParameter fullDescriptionParam = new SqlParameter
                    {
                        ParameterName = "@fullDescription",
                        Value = product.FullDescription
                    };
                    command.Parameters.Add(fullDescriptionParam);

                    SqlParameter priceParam = new SqlParameter
                    {
                        ParameterName = "@price",
                        Value = product.Price
                    };
                    command.Parameters.Add(priceParam);

                    SqlParameter urlParam = new SqlParameter
                    {
                        ParameterName = "@url",
                        Value = product.ImageUrl
                    };
                    command.Parameters.Add(urlParam);

                    command.ExecuteNonQuery();

                }

                connection.Close();
            }
        }
        void ExecuteEditProductCommand()
        {
            if (dataGrid.SelectedItems.Count == 1)
            {
                EditProductDBWindow wind = new EditProductDBWindow(dataGrid.SelectedItems[0]);
                wind.Owner = this;
                wind.Show();
            }
            else
            {
                MessageBox.Show("Выберите только 1 элемент!");
            }
        }

        void ExecuteNextPageCommand()
        {
            productsShow.Clear();
            prevBtn.IsEnabled = true;
            currentBeginIndex += 20;
            if (products.Count - currentBeginIndex <= 20)
                nextBtn.IsEnabled = false;

            for(int i = currentBeginIndex, j = 0; i < products.Count; i++)
            {
                if (j == 20)
                    break;
                productsShow.Add(products[i]);
                j++;
            }

            dataGrid.ItemsSource = productsShow;
            dataGrid.SelectedIndex = 0;
            dataGrid.Focus();
        }

        void ExecutePrevPageCommand()
        {
            productsShow.Clear();
            currentBeginIndex -= 20;
            nextBtn.IsEnabled = true;
            if (currentBeginIndex == 0)
                prevBtn.IsEnabled = false;

            for (int i = currentBeginIndex, j = 0; i < products.Count; i++)
            {
                if (j == 20)
                    break;
                productsShow.Add(products[i]);
                j++;
            }

            dataGrid.ItemsSource = productsShow;
            dataGrid.SelectedIndex = 0;
            dataGrid.Focus();
        }

        bool IsNextAvailable(object o, bool b)
        {
            return nextBtn.IsEnabled;
        }

        bool IsPrevAvailable()
        {
            return prevBtn.IsEnabled;
        }
    }
}
