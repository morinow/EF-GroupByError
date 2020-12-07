namespace SampleApp
{
  using Microsoft.AspNetCore.Hosting;
  using Microsoft.Extensions.DependencyInjection;
  using Microsoft.Extensions.Hosting;
  using SampleApp.Database;

  public class Program
  {
    public static void Main(string[] args)
    {
      var host = Program.CreateHostBuilder(args).Build();
      
      var context = host.Services.CreateScope().ServiceProvider.GetRequiredService<SampleDbContext>();
      context.Database.EnsureCreated();
      
      host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
      return Host.CreateDefaultBuilder(args)
                 .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
  }
}