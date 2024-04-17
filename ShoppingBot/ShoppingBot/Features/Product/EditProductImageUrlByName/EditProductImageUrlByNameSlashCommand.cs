using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.Attributes;
using ShoppingBot.Features.Product.EditProductImageUrlByName;
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
        [SlashCommand("edit-product-imageurl", "Edit a product's image URL")]
        [SlashRequirePermissions(DSharpPlus.Permissions.Administrator)]
        public async Task EditProductImageUrlByName(InteractionContext ctx, [Option("name", "Item name")] string name
           , [Option("image-url", "Url link to the image")] string imageUrl)
        {
            await Edit<Entities.Product>(ctx, new EditProductImageUrlByNameCommand(name, imageUrl, ctx.Guild.Id.ToString()));
        }
    }
}
