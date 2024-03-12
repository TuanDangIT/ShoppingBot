using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.SlashCommands;
using ShoppingBot.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Commands
{
    internal class TestCommands : BaseCommandModule
    {
        private readonly ShoppingBotDbContext _dbContext;

        public TestCommands(ShoppingBotDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [Command("test")]
        public async Task TestCommand(CommandContext ctx)
        {
            await _dbContext.Products.AddAsync(new Entities.Product()
            {
                Name = "1",
                Price = 1,
                Description = "2",
                ImageUrl = "1"
            });
            await _dbContext.SaveChangesAsync();
            await ctx.Channel.SendMessageAsync("ShoppingBot working...");
        }
    }
}
