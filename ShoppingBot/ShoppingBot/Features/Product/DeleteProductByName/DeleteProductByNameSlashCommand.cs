using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.Attributes;
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
        [SlashRequirePermissions(DSharpPlus.Permissions.Administrator)]
        public async Task DeleteProductByName(InteractionContext ctx,
            [Option("name", "Item name")] string name)
        {
            await Delete<Entities.Product>(ctx, new DeleteProductByNameCommand(name, ctx.Guild.Id.ToString()));
        }
    }
}
