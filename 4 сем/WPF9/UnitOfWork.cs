using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF9;

public class UnitOfWork
{
    private MyDbContext _db;
    private BookRepository bookRepository;
    private AuthorRepository authorRepository;

    public UnitOfWork(MyDbContext dbContext)
    {
        _db = dbContext;
    }

    public BookRepository Book
    {
        get
        {
            if (bookRepository == null)
                bookRepository = new BookRepository(_db);
            return bookRepository;
        }
    }

    public AuthorRepository Author
    {
        get
        {
            if (authorRepository == null)
                authorRepository = new AuthorRepository(_db);
            return authorRepository;
        }
    }

    public void Save()
    {
        _db.SaveChanges();
    }

    private bool disposed = false;

    public virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            this.disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

}
