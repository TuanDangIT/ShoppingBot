using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using MediatR;
using ShoppingBot.DAL.Repositories;
using ShoppingBot.Features.Product.AddProduct;
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
        public async Task TestSlashCommand(InteractionContext ctx, string Name, double Price, string Description, string ImageUrl)
        {
            await ctx.DeferAsync();
            var result = await _mediator.Send(new AddProductCommand(Name, Price, Description, ImageUrl));
            if (result.IsSuccess)
            {
                var outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Green,
                    Title = "Add product result message",
                    Description = "Product successfully created!"
                };
                await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(outputEmbed));
            }
            else
            {
                var outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Green,
                    Title = "Add product result message",
                    Description = "Unable to add a product!"
                };
                await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(outputEmbed));
            }

        }
    }
}
