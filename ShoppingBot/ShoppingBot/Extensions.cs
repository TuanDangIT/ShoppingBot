using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShoppingBot.DAL;
using ShoppingBot.DAL.Repositories;
using ShoppingBot.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;
using FluentValidation;

namespace ShoppingBot
{
    internal static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ShoppingBotDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("Postgres"));
                //options.UseSqlServer(configuration.GetConnectionString("MSSQL")); 
            });
            //Migrate(services);
            services.AddSingleton<ShoppingBot>();
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddHostedService<BotDisconnectHandler>();
            services.AddHostedService<DatabaseInitializer>();
            return services;
        }
        //private static void Migrate(IServiceCollection services)
        //{
        //    using var sp = services.BuildServiceProvider();
        //    using var scope = sp.CreateScope();
        //    var dbContext = sp.GetRequiredService<ShoppingBotDbContext>();
        //    if (dbContext.Database.GetPendingMigrations().Any())
        //    {
        //        dbContext.Database.Migrate();
        //    }
        //}
    }
}
