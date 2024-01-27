using E_Commerce.Model;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) { }
        
        public DbSet<Product> product { get; set; }
        public DbSet<User> user { get; set; }

    }
}
