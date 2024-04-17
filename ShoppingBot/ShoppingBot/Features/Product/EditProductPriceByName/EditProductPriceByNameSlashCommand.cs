using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.Attributes;
using ShoppingBot.Features.Product.EditProductPriceByName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Product
{
    internal partial class ProductSlashCommands
    {
        [SlashCommand("edit-product-price", "Edit a product's price")]
        [SlashRequirePermissions(DSharpPlus.Permissions.Administrator)]
        public async Task EditProductPriceByName(InteractionContext ctx, [Option("name", "Item name")] string name,
            [Option("price", "Item price")] double price)
        {
            await Edit<Entities.Product>(ctx, new EditProductPriceByNameCommand(name, price, ctx.Guild.Id.ToString()));
        }

    }
}