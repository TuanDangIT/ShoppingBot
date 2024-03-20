using DSharpPlus.SlashCommands;
using ShoppingBot.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Commands
{
    internal class TestSlashCommands : ApplicationCommandModule
    {
        [SlashCommand("test", "Testing slash command")]
        public async Task TestSlashCommand(InteractionContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Shoppinh bot working...");
        }
    }
}
