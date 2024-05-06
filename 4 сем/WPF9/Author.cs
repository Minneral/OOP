using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF9;

public partial class Author
{
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public int AuthorID { get; set; }
    public string AuthorName { get; set; }
    public List<Book> Books { get; set; }
    public Author(int authorID, string authorName, List<Book> books)
    {
        AuthorID = authorID;
        AuthorName = authorName;
        Books = books;
    }
    public Author(int authorID, string authorName)
    {
        AuthorID = authorID;
        AuthorName = authorName;
        Books = new List<Book>();
    }
    public Author(string authorName)
    {
        AuthorName = authorName;
        Books = new List<Book>();
    }
    public Author()
    {
        Books = new List<Book>();
    }
}
