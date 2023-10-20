using Hirad23.Domain.Catalog;
using Microsoft.EntityFrameworkCore;


namespace Hirad23.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        public DbSet<Item> Items { get; set; }
    }
}
