using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF9;

public partial class Book
{
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public int BookID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<Author> Authors { get; set; }
    public Book(int bookID, string title, string description, List<Author> authors)
    {
        BookID = bookID;
        Title = title;
        Description = description;
        Authors = authors;
    }
    public Book(string title, string description, List<Author> authors)
    {
        Title = title;
        Description = description;
        Authors = authors;
    }
    public Book(string title, string description)
    {
        Title = title;
        Description = description;
        Authors = new List<Author>();
    }
    public Book(int bookID, string title, string description)
    {
        BookID = bookID;
        Title = title;
        Description = description;
        Authors = new List<Author>();
    }
    public Book()
    {
        Authors = new List<Author>();
    }
}
