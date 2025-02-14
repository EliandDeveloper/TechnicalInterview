
using Microsoft.EntityFrameworkCore;
using Technical.Domain.Entities;

namespace Technical.Infraestructure.Context
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
        {
        }

        public DbSet<Products> Products { get; set; }
    }
}
