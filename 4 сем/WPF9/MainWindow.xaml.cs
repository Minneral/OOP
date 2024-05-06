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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SelectedBooks = new List<Book>();
            SelectedAuthors = new List<Author>();
        }

        public List<Book> SelectedBooks { get; set; }
        public List<Author> SelectedAuthors { get; set; }


        public void Books_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedBooks.Clear();
            DataGrid dataGrid = (DataGrid)sender;
            foreach(var item in dataGrid.SelectedItems)
            {
                var obj = item as Book;
                SelectedBooks.Add(obj);
            }

            ViewModel.Books_SelectionChanged(sender);
        }

        public void Authors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedAuthors.Clear();
            DataGrid dataGrid = (DataGrid)sender;
            foreach (var item in dataGrid.SelectedItems)
            {
                var obj = item as Author;
                SelectedAuthors.Add(obj);
            }

            ViewModel.Authors_SelectionChanged(sender);
        }

        public List<Book> gets()
        {
            return null;
        }
    }
}
