using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.SlashCommands;
using ShoppingBot.DTOs;
using ShoppingBot.Features.Product.GetAllProducts;
using ShoppingBot.Shared;
using ShoppingBot.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Product
{
    internal partial class ProductSlashCommands
    {
        [SlashCommand("get-all-products", "Get all products")]
        public async Task GetAllProducts(InteractionContext ctx)
        {
            await GetAll<ProductDto>(ctx, EntityCode.Product);
        }
    }
}
