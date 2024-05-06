using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF9;

public class AuthorRepository : IRepository<Author>
{
    private readonly MyDbContext _dbContext;

    public AuthorRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Author entity)
    {
        _dbContext.Authors.Add(entity);
    }

    public void Delete(int id)
    {
        Author auhtor = _dbContext.Authors.Find(id);
        if (auhtor != null)
            _dbContext.Authors.Remove(auhtor);
    }

    public Author GetById(int id)
    {
        return _dbContext.Authors.Find(id);
    }

    public IEnumerable<Author> GetItemsList()
    {
        return _dbContext.Authors;
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }

    public void Update(Author entity)
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
