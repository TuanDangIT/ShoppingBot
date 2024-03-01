using DSharpPlus.CommandsNext;
using DSharpPlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.DependencyInjection;

namespace ShoppingBot
{
    internal class ShoppingBot
    {
        private readonly IServiceProvider _serviceProvider;
        private DiscordClient _client { get; set; } = default!;
        private CommandsNextExtension _commands { get; set; } = default!;
        private Config _config { get; set; } = default!;
        public ShoppingBot(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            using StreamReader streamReader = new StreamReader("config.json");
            string json = streamReader.ReadToEnd();
            _config = JsonConvert.DeserializeObject<Config>(json)!;
        }
        public async Task RunAsync()
        {
            _client = await CreateClient();
            _client.Ready += OnClientReady;
            var commandsConfig = new CommandsNextConfiguration()
            {
                StringPrefixes = new string[] { _config.prefix },
                EnableMentionPrefix = true,
                EnableDms = true,
                EnableDefaultHelp = false,
                Services = _serviceProvider
            };
            _commands = _client.UseCommandsNext(commandsConfig);
            await _client.ConnectAsync();
            await Task.Delay(-1);
        }
        private static async Task<DiscordClient> CreateClient()
        {
            using StreamReader streamReader = new StreamReader("config.json");
            string json = await streamReader.ReadToEndAsync();
            var config = JsonConvert.DeserializeObject<Config>(json);
            var discordConfiguration = new DiscordConfiguration()
            {
                Intents = DiscordIntents.All,
                Token = config!.token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
            };
            return new DiscordClient(discordConfiguration);
        }

        private static Task OnClientReady(DiscordClient sender, DSharpPlus.EventArgs.ReadyEventArgs args)
        {
            return Task.CompletedTask;
        }
    }
    internal sealed class Config
    {
        public string token { get; set; } = default!;
        public string prefix { get; set; } = default!;
    }
}
