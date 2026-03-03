using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Mre.tecnologia.util.lib.Logger;
using Serilog;
using System.Reflection;

namespace Mre.OTI.Presupuesto.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SerilogConfig.ConfigureLog(Assembly.GetExecutingAssembly().GetName().Name);
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).UseSerilog();
    }
}
