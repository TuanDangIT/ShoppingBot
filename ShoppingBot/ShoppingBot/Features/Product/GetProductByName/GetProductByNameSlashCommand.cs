using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using Newtonsoft.Json.Linq;
using ShoppingBot.DTOs;
using ShoppingBot.Features.Product.GetProductByName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Product
{
    internal partial class ProductSlashCommands
    {
        [SlashCommand("get-product-by-name", "Get a product by name")]
        public async Task GetProductByName(InteractionContext ctx,
            [Option("name", "Item name")] string name)
        {
            await Get<ProductDto>(ctx, new GetProductByNameQuery(name, ctx.Guild.Id.ToString()));
        }
    }
}
