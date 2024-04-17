using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.Attributes;
using ShoppingBot.Features.Product.EditProductDescriptionByName;
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
        [SlashCommand("edit-product-description", "Edit a product's description")]
        [SlashRequirePermissions(DSharpPlus.Permissions.Administrator)]
        public async Task EditProductDescriptionByName(InteractionContext ctx, [Option("name", "Item name")] string name
            , [Option("description", "Item description")] string description)
        {
            await Edit<Entities.Product>(ctx, new EditProductDescriptionByNameCommand(name, description, ctx.Guild.Id.ToString()));
        }
    }
}
