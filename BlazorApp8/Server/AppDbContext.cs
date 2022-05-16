using Microsoft.EntityFrameworkCore;
using BlazorApp8.Shared;

namespace BlazorApp8.Server
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        //public AppDbContext() : base("AppDbContext")
        //{
        //}


        public DbSet<Customer> Customer { get; set; }
        public DbSet<Product> Product{ get; set; }
    }
}
