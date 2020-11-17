using ApiRestful.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiRestful.Service.Contexts
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options):base(options)
        {

        }

        public DbSet<ProductEntity> Products { get; set; }
    }
}
