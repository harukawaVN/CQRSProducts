using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DataContext.DataManager.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.DataContext.DataManager
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options)
          : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

    }
}
