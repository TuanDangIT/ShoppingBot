using DSharpPlus.SlashCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Commands
{
    internal class TestSlashCommands : ApplicationCommandModule
    {
        [SlashCommand("test", "testing slash command")]
        public async Task TestSlashCommand(InteractionContext ctx)
        {
            await ctx.Interaction.CreateResponseAsync(DSharpPlus.InteractionResponseType.ChannelMessageWithSource,
            new DSharpPlus.Entities.DiscordInteractionResponseBuilder()
            .WithContent("ShoppingBot working..."));
        }
    }
}
