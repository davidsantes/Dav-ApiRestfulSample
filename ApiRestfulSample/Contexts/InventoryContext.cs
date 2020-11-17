using ApiRestfulSample.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiRestfulSample.Contexts
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options):base(options)
        {

        }

        public DbSet<ProductEntity> Products { get; set; }
    }
}
