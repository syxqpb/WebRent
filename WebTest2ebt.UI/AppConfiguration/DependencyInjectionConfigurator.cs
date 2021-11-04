using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebTest2ebt.BusinessLogicLayer.Interfaces;
using WebTest2ebt.BusinessLogicLayer.Managers;
using WebTest2ebt.BusinessLogicLayer.Mapper;
using WebTest2ebt.BusinessLogicLayer.Models;
using WebTest2ebt.BusinessLogicLayer.Validation;
using WebTest2ebt.DataAccessLayer.Context;
using WebTest2ebt.DataAccessLayer.Models;
using WebTest2ebt.DataAccessLayer.Models.Identity;
using WebTest2ebt.DataAccessLayer.Repositories;
using WebTest2ebt.UI.Mappers;
using WebTest2ebt.UI.Models;

namespace WebTest2ebt.UI.AppConfiguration
{
    public static class DependencyInjectionConfigurator
    {
        public static void ConfigureAppServices(this IServiceCollection services, IConfiguration config)
        {
            var businessAssembly = Assembly.Load("PhotoRent.BusinessLogicLayer");

            services.AddDbContext<PhotoRentContext>(options => options.UseSqlServer(config.GetConnectionString("RentConnection")))
                .Scan(scan => scan.FromAssemblies(businessAssembly)
                                      .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Manager")))
                                      .AsSelf()
                                      .WithScopedLifetime())
                    .Scan(scan => scan.FromAssemblies(businessAssembly)
                                      .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Validator")))
                                      .AsImplementedInterfaces()
                                      .WithTransientLifetime())
                    .AddScoped(typeof(IRepository<>), typeof(PhotoRentRepository<>))
                    .AddAutoMapper(typeof(PhotoRentProfile), typeof(ViewModelsProfile));

            services.AddTransient<IPageManager<Equipment>, EquipmentManager>();
            services.AddTransient<IPageManager<Cart>, BuyerManager>();
            services.AddTransient<IPageMasterManager<Master>, MasterManager>();
            services.AddTransient<BuyerManager, BuyerManager>();
            services.AddTransient<IManager<Equipment>, EquipmentManager>();
            services.AddTransient<IManager<Storage>, StorageManager>();
            services.AddTransient<IManager<Camera>, CameraManager>();
            services.AddTransient<IManager<FlashBulb>, FlashBulbManager>(); 
            services.AddTransient<IManager<Lens>, LensManager>(); 
            services.AddTransient<IManager<Battery>, BatteryManager>(); 
            services.AddTransient<IManager<Microphone>, MicrophoneManager>(); 
            services.AddTransient<IManager<Cart>, CartManager>(); 
            services.AddTransient<IManager<Master>, MasterManager>(); 
            services.AddTransient<IValidator<Buyer>, BuyerValidator>();
            services.AddTransient<IValidator<Equipment>, EquipmentValidator>();
            services.AddTransient<IValidator<Storage>, StorageValidator>();
            services.AddTransient<IValidator<Camera>, CameraValidator>();
            services.AddTransient<IValidator<FlashBulb>, FlashBulbValidator>();
            services.AddTransient<IValidator<Lens>, LensValidator>();
            services.AddTransient<IValidator<Battery>, BatteryValidator>();
            services.AddTransient<IValidator<Microphone>, MicrophoneValidator>();
            services.AddTransient<IValidator<Cart>, CartValidator>();
            services.AddTransient<IValidator<Master>, MasterValidator>();

            services.AddIdentity<IdentityBuyer, IdentityRole>(options => { options.Password.RequireNonAlphanumeric = false; })
                    .AddEntityFrameworkStores<PhotoRentContext>();
        }
    }
}
//"RentConnection"