using DSharpPlus.SlashCommands;
using MediatR;
using ShoppingBot.Features.Product.AddProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Commands
{
    [SlashCommandGroup("product", "product operations")]
    internal class ProductSlashCommands : ApplicationCommandModule
    {
        private readonly IMediator _mediator;

        public ProductSlashCommands(IMediator mediator)
        {
            _mediator = mediator;
        }
        [SlashCommand("add-product", "add product")]
        public async Task AddProduct(InteractionContext ctx)
        {
            //var result = await _mediator.Send(new AddProductCommand(name, Double.Parse(price), description, imageUrl));
            var result = await _mediator.Send(new AddProductCommand("1", 1, "1", "1"));
            if (result.IsFailure)
            {
                await ctx.Interaction.CreateResponseAsync(DSharpPlus.InteractionResponseType.ChannelMessageWithSource,
                    new DSharpPlus.Entities.DiscordInteractionResponseBuilder()
                        .WithContent("Operation failed"));
            }

            await ctx.Interaction.CreateResponseAsync(DSharpPlus.InteractionResponseType.ChannelMessageWithSource,
                new DSharpPlus.Entities.DiscordInteractionResponseBuilder()
                    .WithContent("Product successfully added!"));
        }
    }
}
