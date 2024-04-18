using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.Attributes;
using ShoppingBot.DTOs;
using ShoppingBot.Features.Order.GetOrderById;
using ShoppingBot.Features.Product.GetProductByName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Order
{
    internal partial class OrderSlashCommands
    {
        [SlashCommand("get-order-by-id", "Get a order by id")]
        [SlashRequirePermissions(DSharpPlus.Permissions.Administrator)]
        public async Task GetOrderById(InteractionContext ctx,
            [Option("id", "Order id")] string id)
        {
            await Get<OrderDto>(ctx, new GetOrderByIdQuery(id, ctx.Guild.Id.ToString()));
        }
    }
}
