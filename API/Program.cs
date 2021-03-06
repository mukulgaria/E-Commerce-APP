using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Program
    {//applying migrations and creating databse at app startup
        public async static Task Main(string[] args)
        {
           var host =  CreateHostBuilder(args).Build();
            using(var scope = host.Services.CreateScope()){
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try{
                    var context = services.GetRequiredService<StoreContext>();
                    await context.Database.MigrateAsync();
                    await StoreContextSeedData.SeedAsync(context,loggerFactory);
                }
                catch(Exception e){
                    var logger =loggerFactory.CreateLogger<Program>();
                    logger.LogError(e,"An error occured in migration");
                }
            }
            host.Run();
        }
///work hard enjoy hard
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
