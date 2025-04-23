using Hirad23.Domain.Catalog;
using Microsoft.EntityFrameworkCore;


//seeds the database with initial sample data

namespace Hirad23.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ModelBuilder builder)
        {
            builder.Entity<Item>().HasData(
                new Item("Shirt", "Ohio State shirt.", "Nike", 29.99m)
                {
                    Id = 1
                },
                new Item("Shorts", "Ohio State shorts.", "Nike", 44.99m)
                {
                    Id = 2
                }

            );
        }
    }
}
