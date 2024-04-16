using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.Attributes;
using ShoppingBot.DTOs;
using ShoppingBot.Features.Order.GetAllOrders;
using ShoppingBot.Features.Product.GetAllProducts;
using ShoppingBot.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Order
{
    internal partial class OrderSlashCommands
    {
        [SlashCommand("get-all-orders", "Get all orders")]
        [SlashRequirePermissions(DSharpPlus.Permissions.Administrator)]
        public async Task GetAllOrders(InteractionContext ctx)
        {
            await GetAll<OrderDto>(ctx, EntityCode.Order);
            //await ctx.DeferAsync();
            //int i = 1;
            //var pageList = new List<Page>();
            //var interactivity = ShoppingBot._client.GetInteractivity();
            //IEnumerable<OrderDto> orderDtos = new List<OrderDto>();
            //do
            //{
            //    StringBuilder sb = new StringBuilder();
            //    var serverId = ctx.Guild.Id;
            //    var results = await _mediator.Send(new GetAllOrdersQuery(i, serverId.ToString()));
            //    if (results.IsFailure)
            //    {
            //        break;
            //    }
            //    foreach (var item in results.Value)
            //    {
            //        sb.Append($"{item.Id}, {item.Buyer}, {item.Product.Name} \n");
            //    }
            //    var page = new Page("", new DiscordEmbedBuilder
            //    {
            //        Color = DiscordColor.Green,
            //        Title = $"Order operation response",
            //        Description = sb.ToString()
            //    });
            //    pageList.Add(page);
            //    i++;
            //} while (true);
            //if (pageList.Count == 0)
            //{
            //    var outputEmbed = new DiscordEmbedBuilder()
            //    {
            //        Color = DiscordColor.Green,
            //        Title = $"Prder operation response",
            //        Description = "Order list is empty"
            //    };
            //    await ctx.EditResponseAsync(new DiscordWebhookBuilder()
            //        .AddEmbed(outputEmbed));
            //}
            //else
            //{
            //    await ctx.Channel.SendPaginatedMessageAsync(ctx.Member, pageList);
            //}
        }
    }
}
