using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.Attributes;
using ShoppingBot.Features.Order.EditOrderProductById;
using ShoppingBot.Features.Product.EditProductDescriptionByName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Order
{
    internal partial class OrderSlashCommands
    {
        [SlashCommand("edit-order-product", "Edit a order's product")]
        [SlashRequirePermissions(DSharpPlus.Permissions.Administrator)]
        public async Task EditOrderProduct(InteractionContext ctx, [Option("name", "Item name")] string name
            , [Option("id", "Order id")] string id)
        {
            await   Edit<Entities.Order>(ctx, new EditOrderProductByIdCommand(id, name, ctx.Guild.Id.ToString()));
        }
    }
}
