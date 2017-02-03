using Microsoft.EntityFrameworkCore;
using Addrbook.Models;

namespace Addrbook.Data
{
  /// <summary>
  /// AddreBook DbContext
  /// </summary>
  public class AddrBookDbContext : DbContext
  {
    /// <summary>
    /// DbContext 构造函数
    /// </summary>
    public AddrBookDbContext(DbContextOptions<AddrBookDbContext> options)
        : base(options)
    { }

    /// <summary>
    /// 员工 DbSet
    /// </summary>
    public DbSet<Stuff> Stuffs { get; set; }

    /// <summary>
    /// 部门
    /// </summary>
    public DbSet<Department> Departments { get; set; }

    /// <summary>
    /// config model
    /// </summary>
    protected override void OnModelCreating(ModelBuilder builder)
    {
      // builder.Entity<Department>().ToTable("Departments");
    }
  }
}
