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
        private readonly ShoppingBotDbContext _dbContext;

        public TestSlashCommands(ShoppingBotDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [SlashCommand("test", "testing slash command")]
        public async Task TestSlashCommand(InteractionContext ctx)
        {
            await _dbContext.Products.AddAsync(new Entities.Product()
            {
                Name = "1",
                Price = 1,
                Description = "2",
                ImageUrl = "1"
            });
            await ctx.Interaction.CreateResponseAsync(DSharpPlus.InteractionResponseType.ChannelMessageWithSource,
            new DSharpPlus.Entities.DiscordInteractionResponseBuilder()
            .WithContent("ShoppingBot working..."));
        }
    }
}
