using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;


namespace ADONET
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
        DataSet table;
        SqlDataAdapter adapter;

        public MainWindow()
        {
            InitializeComponent();

            table = new DataSet();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                adapter = new SqlDataAdapter("SELECT FIO [ФИО], Course [Курс] FROM Students", connection);
                adapter.Fill(table);
                dataGrid.ItemsSource = table.Tables[0].DefaultView;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource.ToString();
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();

                command.CommandText = "DELETE FROM Students";
                command.ExecuteNonQuery();
                foreach (DataRow row in ((DataView)dataGrid.ItemsSource).Table.Rows)
                {
                    var cells = row.ItemArray;
                    command.CommandText = $"INSERT INTO Students(FIO, Course) VALUES ('{cells[0]}', {cells[1]})";
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
    }
}
