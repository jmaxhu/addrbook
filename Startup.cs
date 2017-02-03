using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using addrbook.Service;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.EntityFrameworkCore;
using addrbook.Data;

namespace addrbook
{
  /// <summary>
  /// startup class
  /// </summary>
  public class Startup
  {
    /// <summary>
    /// startup constructor
    /// </summary>
    public Startup(IHostingEnvironment env)
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
          .AddEnvironmentVariables();
      Configuration = builder.Build();
    }

    /// <summary>
    /// 配置项
    /// </summary>
    public IConfigurationRoot Configuration { get; }

    /// <summary>
    /// service configure
    /// </summary>
    public void ConfigureServices(IServiceCollection services)
    {
      // Add framework services.
      services.AddMvc();

      services.AddSingleton<IStuffService, StuffService>();

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new Info
        {
          Title = "Stuff Api",
          Version = "v1",
          Description = "Swagger Doc for Stuff Api"
        });

        var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "addrbook.xml");
        c.IncludeXmlComments(filePath);
      });

      services.AddDbContext<AddrBookDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
    }

    /// <summary>
    /// middleware configure
    /// </summary>
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, AddrBookDbContext dbContext)
    {
      loggerFactory.AddConsole(Configuration.GetSection("Logging"));
      loggerFactory.AddDebug();

      app.UseMvc();

      app.UseSwagger();
      app.UseSwaggerUi(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API V1");
      });

      // 数据库初始化
      DbInitializer.Initialize(dbContext);
    }
  }
}
