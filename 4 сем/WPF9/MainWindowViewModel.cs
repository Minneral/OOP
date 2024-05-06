using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPF9;

public class MainWindowViewModel : INotifyPropertyChanged
{
    private string authorName;
    private string bookName;
    private string bookDescription;
    private List<Book> bookList;
    private List<Author> authorList;


    public string AuthorName
    {
        get { return authorName; }
        set
        {
            authorName = value;
            OnPropertyChanged();
        }
    }
    public string BookName
    {
        get { return bookName; }
        set
        {
            bookName = value;
            OnPropertyChanged();
        }
    }
    public string BookDescription
    {
        get { return bookDescription; }
        set
        {
            bookDescription = value;
            OnPropertyChanged();
        }
    }
    public List<Book> BooksList
    {
        get { return bookList; }
        set
        {
            bookList = value;
            OnPropertyChanged();
        }
    }
    public List<Author> AuthorsList
    {
        get { return authorList; }
        set
        {
            authorList = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<string> BooksNameList { get; set; }
    public ObservableCollection<string> AuthorsNameList { get; set; }


    public RelayCommand AddBookCommand { get; set; }
    public RelayCommand DeleteBookCommand { get; set; }
    public RelayCommand UpdateBookCommand { get; set; }
    public RelayCommand SearchBookCommand { get; set; }
    public RelayCommand AddAuthorCommand { get; set; }
    public RelayCommand DeleteAuhtorCommand { get; set; }
    public RelayCommand UpdateAuthorCommand { get; set; }
    public RelayCommand SearchAuthorCommand { get; set; }


    public ObservableCollection<Book> SelectedBooks { get; set; }
    public ObservableCollection<Author> SelectedAuthors { get; set; }

    private string bookSearchName;

    public string BookSearchName
    {
        get { return bookSearchName; }
        set
        {
            bookSearchName = value;
            OnPropertyChanged();
        }
    }
    private string authorSearchName;

    public string AuthorSearchName
    {
        get { return authorSearchName; }
        set
        {
            authorSearchName = value;
            OnPropertyChanged();
        }
    }

    private string bookSearchDesc;

    public string BookSearchDesc
    {
        get { return bookSearchDesc; }
        set
        {
            bookSearchDesc = value;
            OnPropertyChanged();
        }
    }





    public MainWindowViewModel()
	{
        bookSearchName = String.Empty;
        bookSearchDesc = String.Empty;
        authorSearchName = String.Empty;
        BooksNameList = new ObservableCollection<string>();
        AuthorsNameList = new ObservableCollection<string>();

        Read();
        AddBookCommand = new RelayCommand(o => ExecuteAddBookCommand());
        AddAuthorCommand = new RelayCommand(o => ExecuteAddAuthorCommand());
        DeleteBookCommand = new RelayCommand(o => ExecuteDeleteBookCommand());
        DeleteAuhtorCommand = new RelayCommand(o => ExecuteDeleteAuthorCommand());
        UpdateBookCommand = new RelayCommand(o => ExecuteUpdateBookCommand());
        UpdateAuthorCommand = new RelayCommand(o => ExecuteUpdateAuthorCommand());
        SearchBookCommand = new RelayCommand(o => ExecuteSearchBookCommand());
        SearchAuthorCommand = new RelayCommand(o => ExecuteSearchAuthorCommand());
    }

    private void Read()
    {
        using (var dbContext = new MyDbContext())
        {
            BooksList = dbContext.Books.ToList<Book>();
            AuthorsList = dbContext.Authors.ToList<Author>();
        }

        BooksNameList.Clear();
        AuthorsNameList.Clear();

        foreach (var item in BooksList)
        {
            BooksNameList.Add(item.Title);
        }
        foreach(var item in AuthorsList)
        {
            AuthorsNameList.Add(item.AuthorName);
        }
    }

    public void ExecuteAddBookCommand()
    {
        try
        {
            var mw = (MainWindow)Application.Current.MainWindow;

            if(bookName == String.Empty || BookDescription == String.Empty)
            {
                throw new ArgumentException();
            }

            Book book = new Book(BookName, BookDescription);

            using (var dbContext = new MyDbContext())
            {
                foreach (string item in mw.AuthorsListBox.SelectedItems)
                {
                    book.Authors.Add(dbContext.Authors.Find(authorList.First(t => t.AuthorName == item).AuthorID));
                }
                dbContext.Books.Add(book);
                dbContext.SaveChanges();
            }

            Read();
        }
        catch(Exception ex)
        {
            MessageBox.Show("Ошибка!\n" + ex.Message);
        }
    }

    public void ExecuteAddAuthorCommand()
    {
        try
        {
            var mw = (MainWindow)Application.Current.MainWindow;

            if (AuthorName == String.Empty)
            {
                throw new ArgumentException();
            }

            Author author = new Author(AuthorName);

            using (var dbContext = new MyDbContext())
            {
                foreach (string item in mw.BooksListBox.SelectedItems)
                {
                    author.Books.Add(dbContext.Books.Find(BooksList.First(t => t.Title == item).BookID));
                }
                dbContext.Authors.Add(author);
                dbContext.SaveChanges();
            }

            Read();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка!\n" + ex.Message);
        }
    }

    public void ExecuteDeleteBookCommand()
    {
        var mw = (MainWindow)Application.Current.MainWindow;
        var selected = mw.SelectedBooks;

        if (selected.Count > 0)
        {
            using (var dbContext = new MyDbContext())
            {
                foreach (var item in selected)
                {
                    dbContext.Books.Remove(item);
                }
                dbContext.SaveChanges();
            }

            Read();
        }
        else
        {
            MessageBox.Show("Выберите по крайней мере один элемент!");
        }
    }

    public void ExecuteDeleteAuthorCommand()
    {
        var mw = (MainWindow)Application.Current.MainWindow;
        var selected = mw.SelectedAuthors;

        if (selected.Count > 0)
        {
            using (var dbContext = new MyDbContext())
            {
                foreach (var item in selected)
                {
                    dbContext.Authors.Remove(item);
                }
                dbContext.SaveChanges();
            }

            Read();
        }
        else
        {
            MessageBox.Show("Выберите по крайней мере один элемент!");
        }
    }

    public void ExecuteUpdateBookCommand()
    {
        var mw = (MainWindow)Application.Current.MainWindow;
        var selected = mw.SelectedBooks;

        if(selected.Count == 1)
        {
            Book item = (Book)selected[0];
            item.Title = BookName;
            item.Description = BookDescription;

            if(mw.AuthorsListBox.SelectedItems.Count > 0)
                item.Authors.Add(AuthorsList.First(t => t.AuthorName == mw.AuthorsListBox.SelectedItem));

            using(var dbContext = new MyDbContext())
            {
                dbContext.Update(item);
                dbContext.SaveChanges();
            }
            Read();
        }
        else
        {
            MessageBox.Show("Выберите только один элемент!");
        }
    }

    public void ExecuteUpdateAuthorCommand()
    {
        var mw = (MainWindow)Application.Current.MainWindow;
        var selected = mw.SelectedAuthors;

        if (selected.Count == 1)
        {
            Author item = (Author)selected[0];
            item.AuthorName = AuthorName;


            if (mw.BooksListBox.SelectedItems.Count > 0)
                item.Books.Add(BooksList.First(t => t.Title == mw.AuthorsListBox.SelectedItem));

            using (var dbContext = new MyDbContext())
            {
                dbContext.Update(item);
                dbContext.SaveChanges();
            }
            Read();
        }
        else
        {
            MessageBox.Show("Выберите только один элемент!");
        }
    }

    public void ExecuteSearchBookCommand()
    {
        using(var dbContext = new MyDbContext())
        {
            BooksList = dbContext.Books.Where(t => t.Title.ToLower().Contains(BookSearchName.ToLower())).Where(t => t.Description.ToLower().Contains(BookSearchDesc.ToLower())).ToList<Book>();
        }
    }
    public void ExecuteSearchAuthorCommand()
    {
        using (var dbContext = new MyDbContext())
        {
            AuthorsList = dbContext.Authors.Where(t => t.AuthorName.ToLower().Contains(authorSearchName.ToLower())).ToList<Author>();
        }
    }

    public void Authors_SelectionChanged(object sender)
    {
        DataGrid grid = (DataGrid)sender;
        Author author = null;
        if (grid.SelectedItems.Count == 1)
        {
            author = (Author)grid.SelectedItem;
        }
        else
        {
            if (grid.SelectedItems.Count != 0)
            {
                author = (Author)grid.SelectedItems[grid.SelectedItems.Count - 1];
            }
        }

        if (author != null)
        {
            AuthorName = author.AuthorName;
        }
    }

    public void Books_SelectionChanged(object sender)
    {
        var mw = (MainWindow)Application.Current.MainWindow;
        DataGrid grid = (DataGrid)sender;
        Book book = null;

        if(grid.SelectedItems.Count == 1)
        {
            book = (Book)grid.SelectedItem;
        }
        else
        {
            if (grid.SelectedItems.Count != 0)
            {
                book = (Book)grid.SelectedItems[grid.SelectedItems.Count - 1];
            }
        }

        if(book != null)
        {
            BookName = book.Title;
            BookDescription = book.Description;
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

}
