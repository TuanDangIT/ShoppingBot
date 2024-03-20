using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using ShoppingBot.Features.Product.EditProductDescriptionByName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Product
{
    internal partial class ProductSlashCommands
    {
        [SlashCommand("edit-product-description", "Edit a product's description")]
        public async Task EditProductDescriptionByName(InteractionContext ctx, [Option("name", "Item name")] string name
            , [Option("description", "Item description")] string description)
        {
            await ctx.DeferAsync();
            var outputEmbed = new DiscordEmbedBuilder();
            var result = await _mediator.Send(new EditProductDescriptionByNameCommand(name, description));
            if (result.IsFailure)
            {
                outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Green,
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
