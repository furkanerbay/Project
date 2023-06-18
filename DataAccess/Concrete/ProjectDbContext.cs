using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<BookImage> BookImages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaim { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
