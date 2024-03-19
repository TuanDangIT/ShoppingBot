
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShoppingBot;

using IHost host = CreateHostBuilder(args)
    .Build();
var serviceProvider = host.Services.CreateScope().ServiceProvider;
var bot = serviceProvider.GetRequiredService<ShoppingBot.ShoppingBot>();
AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
{
    Console.WriteLine("An exception has been thrown: " + e.GetType());
}

bot.RunAsync(host).Wait();
IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration(app =>
        {
            app.AddJsonFile("appsettings.json", true, true);
        })
        .ConfigureServices((context, services) =>
        {
            services.AddApplication(context.Configuration);
        });
}