using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using ShoppingBot.Features.Product.GetAllProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Product
{
    internal partial class ProductSlashCommands
    {
        [SlashCommand("get-all-products", "Get all products")]
        public async Task GetAllProducts(InteractionContext ctx)
        {
            //uproszczona wersja na razie
            await ctx.DeferAsync();
            var results = await _mediator.Send(new GetAllProductsQuery());
            StringBuilder resultsStringBuilder = new StringBuilder();
            foreach (var item in results.Value)
            {
                resultsStringBuilder.Append($"{item.Name}, {item.Price} \n");
            }
            var outputEmbed = new DiscordEmbedBuilder
            {
                Color = DiscordColor.Green,
                Title = $"Product operation response",
                Description = resultsStringBuilder.ToString()
            };
            await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(outputEmbed));
        }
    }
}
