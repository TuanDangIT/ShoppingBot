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
using ShoppingBot.Features.Product.EditProductPriceByName;
using ShoppingBot.Shared;
using ShoppingBot.Behaviors;
using ShoppingBot.Features.Product.AddProduct;
using ShoppingBot.Shared.Behaviors;
using ShoppingBot.Shared.Interceptors;

namespace ShoppingBot
{
    internal static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ShoppingBotDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("Postgres"));
                options.AddInterceptors(new UpdateAuditableInterceptor());
                //options.UseSqlServer(configuration.GetConnectionString("MSSQL")); 
            });
            services.AddSingleton<ShoppingBot>();
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.AddOpenBehavior(typeof(ExceptionHandlingBehavior<,>));
                cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
                cfg.AddOpenBehavior(typeof(TransactionBehavior<,>));
            });
            services.Scan(scan =>
            {
                scan.FromAssemblyOf<AddProductCommand>()
                .AddClasses(classes => classes.AssignableTo(typeof(IValidator<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime();
            });
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddHostedService<BotDisconnectHandler>();
            services.AddHostedService<DatabaseInitializer>();
            return services;
        }
    }
}
