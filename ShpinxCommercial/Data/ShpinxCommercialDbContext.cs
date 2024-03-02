using Microsoft.EntityFrameworkCore;
using Models;

namespace ShpinxCommercial.Data
{
    public class ShpinxCommercialDbContext : DbContext
    {
        public ShpinxCommercialDbContext(DbContextOptions<ShpinxCommercialDbContext> options) : base(options)
        {
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
