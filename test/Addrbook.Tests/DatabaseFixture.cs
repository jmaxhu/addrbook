using System;
using Microsoft.EntityFrameworkCore;
using Addrbook.Data;

namespace Addrbook.Tests
{
  public class DatabaseFixture : IDisposable
  {
    private const string ConnString = "Host=localhost;Database=addrbook_test;Username=addrbook_admin;Password=2501162";

    /// <summary>
    /// DbContext
    /// </summary>
    public AddrBookDbContext DbContext { get; private set; }

    public DatabaseFixture()
    {
      var optBuilder = new DbContextOptionsBuilder<AddrBookDbContext>();
      optBuilder.UseNpgsql(ConnString);

      DbContext = new AddrBookDbContext(optBuilder.Options);

      DbInitializer.Initialize(DbContext, true);
    }

    public void Dispose()
    {
      DbContext.Dispose();
    }
  }
}