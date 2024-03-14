using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot
{
    internal class BotDisconnectHandler : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public BotDisconnectHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            var bot = _serviceProvider.GetRequiredService<ShoppingBot>();
            await bot.DisconnectBotAsync();
        }
    }
}
