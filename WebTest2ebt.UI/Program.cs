using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTest2ebt.BusinessLogicLayer.Managers;
using WebTest2ebt.BusinessLogicLayer.Models;
using WebTest2ebt.DataAccessLayer.Models.Identity;
using WebTest2ebt.UI.AppConfiguration;

namespace WebTest2ebt.UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var userManager = services.GetRequiredService<UserManager<IdentityBuyer>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                var storageManager = services.GetRequiredService<StorageManager>();
                Storage storage = new Storage { Name = "Склад" };
                await storageManager.Add(storage);
                await IdentityInitializer.InitializeAsync(userManager, roleManager/*, storageManager*/);
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
