using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.SlashCommands;
using ShoppingBot.DTOs;
using ShoppingBot.Features.Product.GetAllProducts;
using ShoppingBot.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Product
{
    internal partial class ProductSlashCommands
    {
        [SlashCommand("get-all-products", "Get all products")]
        public async Task GetAllProducts(InteractionContext ctx)
        {
            await ctx.DeferAsync();
            int i = 1;
            var pageList = new List<Page>();
            var interactivity = ShoppingBot._client.GetInteractivity();
            IEnumerable<ProductDto> productDtos = new List<ProductDto>();
            do
            {
                StringBuilder sb = new StringBuilder();
                var serverId = ctx.Guild.Id;
                var results = await _mediator.Send(new GetAllProductsQuery(i, serverId.ToString()));
                if (results.IsFailure)
                {
                    break;
                }
                foreach (var item in results.Value)
                {
                    sb.Append($"{item.Name}, {item.Price} \n");
                }
                var page = new Page("", new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Green,
                    Title = $"Product operation response",
                    Description = sb.ToString()
                });
                pageList.Add(page);
                i++;
            } while (true);
            await ctx.Channel.SendPaginatedMessageAsync(ctx.Member, pageList);
        }
    }
}
