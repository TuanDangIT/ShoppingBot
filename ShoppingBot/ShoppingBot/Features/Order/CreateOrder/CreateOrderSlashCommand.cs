using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.Attributes;
using ShoppingBot.Entities;
using ShoppingBot.Features.Order.CreateOrder;
using ShoppingBot.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Order
{
    internal partial class OrderSlashCommands
    {
        [SlashCommand("create-order", "Create an order")]
        [SlashRequirePermissions(DSharpPlus.Permissions.Administrator)]
        public async Task CreateOrder(InteractionContext ctx,
            [Option("product-name", "Product name for an order")] string productName,
            [Option("client-username", "Client username")] string username)
        {
            await Create<Entities.Order>(ctx, new CreateOrderCommand(username, productName, ctx.Guild.Id.ToString()));
        }
        [SlashCommand("buy-product", "Buy a product")]
        public async Task BuyProduct(InteractionContext ctx,
            [Option("product-name", "Product name for an order")] string productName)
        {
            await Create<Entities.Order>(ctx, new CreateOrderCommand(ctx.User.Username, productName, ctx.Guild.Id.ToString()));
        }
    }
}
