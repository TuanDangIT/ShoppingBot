using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using ShoppingBot.Features.Product.EditProductPriceByName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Product
{
    internal partial class ProductSlashCommands
    {
        [SlashCommand("edit-product-price", "Edit a product's price")]
        public async Task EditProductPriceByName(InteractionContext ctx, [Option("name", "Item name")] string name,
            [Option("price", "Item price")] double price)
        {
            await ctx.DeferAsync();
            var outputEmbed = new DiscordEmbedBuilder();
            var result = await _mediator.Send(new EditProductPriceByNameCommand(name, price));
            if (result.IsFailure)
            {
                outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Red,
                    Title = $"Product operation response",
                    Description = "Product edit operation failed"
                };
            }
            else
            {
                outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Green,
                    Title = $"Product operation response",
                    Description = "Product edit operation successed"
                };
            }
            await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(outputEmbed));
        }

    }
}