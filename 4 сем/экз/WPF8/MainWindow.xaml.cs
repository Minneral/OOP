using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace WPF8;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    string connectionString;
    string dataBaseName = "WPF8";
    SqlConnection connection;
    ObservableCollection<Product> products;
    public ObservableCollection<Product> Products
    {
        get { return products; }
        set
        {
            products = value;
            OnPropertyChanged();
        }
    }
    ObservableCollection<Product> productsShow = new ObservableCollection<Product>();
    int currentBeginIndex;
    public RelayCommand GetProductsCommand { get; set; }
    public RelayCommand InitAppFromDBCommand { get; set; }
    public RelayCommand InsertProductCommand { get; set; }
    public RelayCommand DeleteSelectedProductsCommand { get; set; }
    public RelayCommand EditProductCommand { get; set; }

    public RelayCommand NextPageCommand { get; set; }
    public RelayCommand PrevPageCommand { get; set; }
    public RelayCommand SortProductCommand { get; set; }
    public MainWindow()
    {
        InitializeComponent();

        Products = new ObservableCollection<Product>();
        currentBeginIndex = 0;
        nextBtn.IsEnabled = false;
        prevBtn.IsEnabled = false;

        connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

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
        InsertProductCommand = new RelayCommand(o => ExecuteInsertProductCommand());
        DeleteSelectedProductsCommand = new RelayCommand(o => ExecuteDeleteSelectedProductsCommand());
        EditProductCommand = new RelayCommand(o => ExecuteEditProductCommand());
        NextPageCommand = new RelayCommand(o => ExecuteNextPageCommand());
        PrevPageCommand = new RelayCommand(o => ExecutePrevPageCommand());
        SortProductCommand = new RelayCommand(o => ExecuteSortProductCommand());
    }

    void ExecuteGetProductsCommand()
    {
        Products.Clear();
        productsShow.Clear();
        connection.Open();
        var command = new SqlCommand("GetProducts", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        var reader = command.ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                string description = reader.GetString(2);
                string fullDescription = reader.GetString(3);
                float price = (float)reader.GetDecimal(4);
                string url = reader.GetString(5);

                Products.Add(new Product(id, name, description, fullDescription, url, price));
            }
        }

        if (Products.Count > 0)
        {
            dataGrid.ItemsSource = productsShow;
            currentBeginIndex = 0;

            if (Products.Count > 20)
            {
                nextBtn.IsEnabled = true;
            }

            for (int i = 0; i < Products.Count; i++)
            {
                if (i == 20)
                    break;
                productsShow.Add(Products[i]);
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

        foreach (var item in products)
        {
            mainProd.Add(item);
        }
    }
    public void AddProduct(Product product)
    {
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            SqlCommand cmd1 = connection.CreateCommand();
            cmd1.Transaction = transaction;
            cmd1.CommandText = @"INSERT INTO Товары (Название_продукта, Описание, Полное_описание, Цена) 
                     VALUES (@name, @description, @fullDescription, @price);
                     SELECT SCOPE_IDENTITY();";
            cmd1.Parameters.AddWithValue("@name", product.Name);
            cmd1.Parameters.AddWithValue("@description", product.Description);
            cmd1.Parameters.AddWithValue("@fullDescription", product.FullDescription);
            cmd1.Parameters.AddWithValue("@price", Convert.ToDecimal(product.Price));
            int productId = Convert.ToInt32(cmd1.ExecuteScalar());

            SqlCommand cmd2 = connection.CreateCommand();
            cmd2.Transaction = transaction;
            cmd2.CommandText = @"INSERT INTO Изображения (id_продукта, Ссылка_на_изображение) 
                     VALUES (@productId, @url)";
            cmd2.Parameters.AddWithValue("@productId", productId);
            cmd2.Parameters.AddWithValue("@url", product.ImageUrl);
            cmd2.ExecuteNonQuery();


            Product.identity = productId;
            Products.Add(new Product(productId, product.Name, product.Description, product.FullDescription, product.ImageUrl, product.Price));
            UpdateShowCollection();
            transaction.Commit();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            MessageBox.Show(ex.Message);
        }

        connection.Close();
    }
    public void EditProduct(Product product)
    {
        if (dataGrid.SelectedItems.Count == 1)
        {
            connection.Open();
            Product old = (Product)dataGrid.SelectedItems[0];

            SqlCommand command = new SqlCommand("EditProduct", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

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

            command.Parameters.AddWithValue("@id", old.Id);

            command.ExecuteNonQuery();

            old.Name = product.Name;
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

                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    SqlCommand cmd1 = connection.CreateCommand();
                    cmd1.Transaction = transaction;
                    cmd1.CommandText = @"DELETE FROM Изображения
		                                    WHERE	(Изображения.id_продукта = @id);";
                    cmd1.Parameters.AddWithValue("@id", product.Id);
                    cmd1.ExecuteNonQuery();

                    SqlCommand cmd2 = connection.CreateCommand();
                    cmd2.Transaction = transaction;
                    cmd2.CommandText = @"DELETE FROM Товары WHERE	(Товары.Id = @id);";
                    cmd2.Parameters.AddWithValue("@id", product.Id);
                    cmd2.ExecuteNonQuery();


                    Products.Remove(product);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show(ex.Message);
                }

            }
            UpdateShowCollection();
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
    void ExecuteSortProductCommand()
    {
        string sCommand = @"SELECT Товары.id [ID], Товары.Название_продукта[Название], Товары.Описание [Описание], Товары.Полное_описание [Полное описание], Товары.Цена [Цена], Изображения.Ссылка_на_изображение[URL] 
                FROM Товары 
                INNER JOIN Изображения ON Товары.id = Изображения.id_продукта ORDER BY Товары.Название_продукта;";

        Products.Clear();
        productsShow.Clear();
        connection.Open();
        var command = new SqlCommand(sCommand, connection);
        var reader = command.ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                string description = reader.GetString(2);
                string fullDescription = reader.GetString(3);
                float price = (float)reader.GetDecimal(4);
                string url = reader.GetString(5);

                Products.Add(new Product(id, name, description, fullDescription, url, price));
            }
        }

        if (Products.Count > 0)
        {
            dataGrid.ItemsSource = productsShow;
            currentBeginIndex = 0;

            if (Products.Count > 20)
            {
                nextBtn.IsEnabled = true;
            }

            for (int i = 0; i < Products.Count; i++)
            {
                if (i == 20)
                    break;
                productsShow.Add(Products[i]);
            }
            dataGrid.SelectedIndex = currentBeginIndex;
            dataGrid.Focus();
        }
        reader.Close();
        connection.Close();

    }

    void UpdateShowCollection()
    {
        productsShow.Clear();
        if (currentBeginIndex == products.Count && currentBeginIndex >= 20)
            currentBeginIndex -= 20;
        if (products.Count - currentBeginIndex <= 20)
            nextBtn.IsEnabled = false;
        else
            nextBtn.IsEnabled = true;
        if (currentBeginIndex == 0)
            prevBtn.IsEnabled = false;
        else
            prevBtn.IsEnabled = true;

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

    void ExecuteNextPageCommand()
    {
        productsShow.Clear();
        prevBtn.IsEnabled = true;
        currentBeginIndex += 20;
        if (products.Count - currentBeginIndex <= 20)
            nextBtn.IsEnabled = false;

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

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


        // ---
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            if (!DatabaseExists(connection, dataBaseName))
            {
                CreateDatabase(connection, dataBaseName);
                this.connectionString = $"Data Source={connection.DataSource};Initial Catalog={dataBaseName};Integrated Security=true";
                using (SqlConnection connection2 = new SqlConnection(connectionString))
                {
                    connection2.Open();
                    CreateDatabaseTables(connection2);
                    connection2.Close();
                }
            }
            else
            {
                this.connectionString = $"Data Source={connection.DataSource};Initial Catalog={dataBaseName};Integrated Security=true";
            }


            connection.Close();
        }

        connection = new SqlConnection(connectionString);


        //for (int i = 0; i < 100; i++)
        //    AddProduct(new Product($"name{i}", "description", "full", "url", 10));
    }
    private bool DatabaseExists(SqlConnection connection, string databaseName)
    {
        string query = $"SELECT COUNT(*) FROM sys.databases WHERE name = '{databaseName}'";
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            int result = (int)command.ExecuteScalar();
            return result > 0;
        }
    }

    private void CreateDatabase(SqlConnection connection, string databaseName)
    {
        string query = $"CREATE DATABASE {databaseName}";
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.ExecuteNonQuery();
        }
    }

    private void CreateDatabaseTables(SqlConnection connection)
    {
        string createTablesQuery = @"
            CREATE TABLE Товары
            (
                id INT IDENTITY(1,1) PRIMARY KEY,
                Название_продукта VARCHAR(100) NOT NULL,
                Описание VARCHAR(255) NOT NULL,
                Полное_описание TEXT NOT NULL,
                Цена DECIMAL(10, 2) NOT NULL
            );

            CREATE TABLE Изображения
            (
                id INT IDENTITY(1,1) PRIMARY KEY,
                id_продукта INT NOT NULL FOREIGN KEY REFERENCES Товары(id),
                Ссылка_на_изображение VARCHAR(255) NOT NULL
            );";

        string createProcedureQuery = @"
            CREATE PROCEDURE GetProducts
            AS
            BEGIN
                SELECT Товары.id [ID], Товары.Название_продукта[Название], Товары.Описание [Описание], Товары.Полное_описание [Полное описание], Товары.Цена [Цена], Изображения.Ссылка_на_изображение[URL] 
                FROM Товары 
                INNER JOIN Изображения ON Товары.id = Изображения.id_продукта;
            END;";

        string createSecondProcedureQuery = @"
            CREATE PROCEDURE EditProduct
                @id INT,
            	@name_new VARCHAR(100),
                @description_new VARCHAR(255),
            	@fullDescription_new TEXT,
            	@price_new Decimal,
            	@url_new VARCHAR(255)
            AS
            
            UPDATE Изображения
            	SET Изображения.Ссылка_на_изображение = @url_new
            		WHERE	(Изображения.id_продукта = @id);
            
            UPDATE Товары
            	SET Товары.Название_продукта = @name_new,
            		Товары.Описание = @description_new,
            		Товары.Полное_описание = @fullDescription_new,
            		Товары.Цена = @price_new
            		WHERE	(Товары.id = @id);";

        using (SqlCommand command = new SqlCommand(createTablesQuery, connection))
        {
            command.ExecuteNonQuery();
        }

        using (SqlCommand command = new SqlCommand(createProcedureQuery, connection))
        {
            command.ExecuteNonQuery();
        }

        using (SqlCommand command = new SqlCommand(createSecondProcedureQuery, connection))
        {
            command.ExecuteNonQuery();
        }

    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
}
