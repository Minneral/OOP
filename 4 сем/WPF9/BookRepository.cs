using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF9;

public class BookRepository : IRepository<Book>
{
    private readonly MyDbContext _dbContext;

    public BookRepository(MyDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public void Add(Book entity)
    {
        _dbContext.Books.Add(entity);
    }

    public void Delete(int id)
    {
        Book book = _dbContext.Books.Find(id);
        if (book != null)
            _dbContext.Books.Remove(book);
    }

    public Book GetById(int id)
    {
        return _dbContext.Books.Find(id);
    }

    public IEnumerable<Book> GetItemsList()
    {
        return _dbContext.Books;
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }

    public void Update(Book entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
    }

    private bool disposed = false;
    public virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
        this.disposed = true;
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
