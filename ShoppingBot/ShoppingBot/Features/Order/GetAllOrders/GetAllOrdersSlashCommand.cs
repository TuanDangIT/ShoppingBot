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
        }
        [SlashCommand("get-all-orders", "Get all orders")]
        public async Task GetAllOrdersPerUser(InteractionContext ctx)
        {
            
        }
    }
}
