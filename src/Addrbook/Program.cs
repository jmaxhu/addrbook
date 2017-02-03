using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace Addrbook
{
  /// <summary>
  /// 主程序
  /// </summary>
  public class Program
  {
    /// <summary>
    /// 主程序入口
    /// </summary>
    public static void Main(string[] args)
    {
      var config = new ConfigurationBuilder()
          .AddCommandLine(args)
          .AddEnvironmentVariables(prefix: "ASPNETCORE_")
          .Build();

      var host = new WebHostBuilder()
          .UseConfiguration(config)
          .UseKestrel()
          .UseContentRoot(Directory.GetCurrentDirectory())
          .UseIISIntegration()
          .UseStartup<Startup>()
          .Build();

      host.Run();
    }
  }
}
