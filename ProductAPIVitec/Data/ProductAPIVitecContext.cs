using Microsoft.EntityFrameworkCore;

namespace ProductAPIVitec.Models
{
    public class ProductAPIVitecContext : DbContext
    {
        public ProductAPIVitecContext (DbContextOptions<ProductAPIVitecContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Price> Price { get; set; }
        public DbSet<Subscription> Subscription { get; set; }
    }
}
