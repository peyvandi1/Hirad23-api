using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Hirad23.Data;

namespace Hirad23.api.Data;

public class StoreContextFactory : IDesignTimeDbContextFactory<StoreContext>
{
  public StoreContext CreateDbContext(string[] args)
    {
      var optionsBuilder = new DbContextOptionsBuilder<StoreContext>();

      optionsBuilder.UseSqlite("Data Source=../Registration.sqlite");

      return new StoreContext(optionsBuilder.Options);
    }
}
