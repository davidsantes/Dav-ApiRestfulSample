using ApiRestful.Service.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiRestful.Service.Contexts
{
    public class InventoryContext : DbContext
    {
        public DbSet<ProductEntity> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server=.\\SQLEXPRESS; Database=InventoryDb; Integrated Security=True");
            }
        }
    }
}
