using DSharpPlus.CommandsNext;
using DSharpPlus.SlashCommands;
using MediatR;
using ShoppingBot.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Commands
{
    internal class ProductCommands : ApplicationCommandModule
    {
        private readonly IMediator _mediator;

        public ProductCommands(IMediator mediator)
        {
            _mediator = mediator;
        }
        [SlashCommand("add_product", "add product")]
        public async Task TestSlashCommand(InteractionContext ctx)
        {
            await ctx.DeferAsync();

        }
    }
}
