using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using ShoppingBot.Features.Product.DeleteProductByName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Product
{
    internal partial class ProductSlashCommands
    {
        [SlashCommand("delete-product", "Delete a product")]
        public async Task DeleteProductByName(InteractionContext ctx,
            [Option("name", "Item name")] string name)
        {
            await ctx.DeferAsync();
            var outputEmbed = new DiscordEmbedBuilder();
            var result = await _mediator.Send(new DeleteProductByNameCommand(name));
            if (result.IsFailure)
            {
                outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Red,
                    Title = $"Product operation response",
                    Description = "Product delete operation failed",
                    Footer = new DiscordEmbedBuilder.EmbedFooter()
                    {
                        Text = $"Additional information: \n{result.Error.Code}: {result.Error.Description}"
                    }
                };
            }
            else
            {
                outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Green,
                    Title = $"Product operation response",
                    Description = "Product delete operation successed"
                };
            }
            await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(outputEmbed));
        }
    }
}
