using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF9;

public class MyDbContext : DbContext
{
	public DbSet<Book> Books { get; set; }
	public DbSet<Author> Authors { get; set; }
 //   public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
	//{
        
 //   }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    }
}
