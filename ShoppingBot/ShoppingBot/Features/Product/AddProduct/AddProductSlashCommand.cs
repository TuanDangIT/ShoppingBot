using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ShoppingBot.Features.Product.AddProduct;
namespace ShoppingBot.Features.Product
{
    internal partial class ProductSlashCommands
    {
        [SlashCommand("add-product", "Add a product")]
        public async Task AddProduct(InteractionContext ctx, [Option("name", "Item name")] string name,
            [Option("price", "Item price")] double price, [Option("description", "Item description")] string description, [Option("image-url", "Url link to the image")] string imageUrl)
        {
            await ctx.DeferAsync();
            var result = await _mediator.Send(new AddProductCommand(name, price, description, imageUrl));
            var outputEmbed = new DiscordEmbedBuilder();
            if (result.IsFailure)
            {
                outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Red,
                    Title = $"Product operation response",
                    Description = $"Product operation failed!"
                };
            }
            else
            {
                outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Green,
                    Title = $"Product operation response",
                    Description = $"Product operation successed!"
                };
            }


            await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(outputEmbed));
        }
    }
}
