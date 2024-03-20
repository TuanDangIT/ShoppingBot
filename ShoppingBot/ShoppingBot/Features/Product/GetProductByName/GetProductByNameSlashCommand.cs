using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using ShoppingBot.Features.Product.GetProductByName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Product
{
    internal partial class ProductSlashCommands
    {
        [SlashCommand("get-product-by-name", "Get a product by name")]
        public async Task GetProductByName(InteractionContext ctx,
            [Option("name", "Item name")] string name)
        {
            await ctx.DeferAsync();
            var result = await _mediator.Send(new GetProductByNameQuery(name));
            var outputEmbed = new DiscordEmbedBuilder();
            if (result.IsSuccess && result.Value != null)
            {
                outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Green,
                    Title = $"Product operation response",
                    Description = $"{result.Value.Name}, {result.Value.Price}",

                };
                if (result.Value.ImageUrl != null && result.Value.ImageUrl.Contains("https"))
                {
                    outputEmbed.ImageUrl = result.Value.ImageUrl;
                }
            }
            else
            {
                outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Red,
                    Title = $"Product operation response",
                    Description = $"Product not found",

                };
            }
            await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(outputEmbed));
        }
    }
}
