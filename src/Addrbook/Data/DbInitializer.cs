using System;
using System.IO;
using System.Linq;
using Addrbook.Models;
using Microsoft.EntityFrameworkCore;

namespace Addrbook.Data
{
  /// <summary>
  /// Db 初始化
  /// </summary>
  public class DbInitializer
  {
    /// <summary>
    /// 初始化方法
    /// <param name="context">EF DbContext</param>
    /// <param name="reset">是否重新创建数据库, 默认为false</param>
    /// </summary>
    public static void Initialize(AddrBookDbContext context, bool reset = false)
    {
      context.Database.EnsureCreated();

      if (reset)
      {
        context.Database.ExecuteSqlCommand("delete from public.\"Stuffs\"");
        context.Database.ExecuteSqlCommand("delete from public.\"Departments\"");
        // TODO: add more
      }

      // 初始化部门及人员
      InitStuff(context);
    }

    /// <summary>
    /// 初始化部门及人员
    /// </summary>
    private static void InitStuff(AddrBookDbContext context)
    {
      if (context.Stuffs.Any())
      {
        return;
      }
      else
      {
        var path = Path.Combine(System.AppContext.BaseDirectory, "../../../Data/Addrbook.csv");
        if (!File.Exists(path))
        {
          throw new Exception($"文件 {path} 不存在");
        }
        var lines = File.ReadLines(path);
        var lineCount = 0;
        foreach (var line in lines)
        {
          lineCount++;
          if (lineCount == 1)
          {
            continue;
          }

          var parts = line.Split(',');
          if (parts.Length < 10)
          {
            continue;
          }

          var department = new Department { Name = parts[2].Trim() };
          var dbDep = context.Departments.FirstOrDefault(x => x.Name == department.Name);
          if (dbDep == null)
          {
            context.Departments.Add(department);
            context.SaveChanges();
          }
          else
          {
            department.Id = dbDep.Id;
          }

          var stuff = new Stuff
          {
            DepartmentId = department.Id,
            Name = parts[1].Trim(),
            Sex = parts[3].Trim(),
            Phone = parts[4].Trim(),
            InnerPhone = parts[5].Trim(),
            VirtualPhone = parts[6].Trim(),
            Office = parts[7].Trim(),
            PhonePort = parts[8].Trim(),
            CellPhone = parts[9].Trim()
          };

          context.Stuffs.Add(stuff);
        }
        context.SaveChanges();
      }
    }
  }
}
