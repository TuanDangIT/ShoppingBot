using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ShoppingBot.Features.Product.AddProduct;
using ShoppingBot.Shared;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.SlashCommands.Attributes;
using ShoppingBot.Entities;
namespace ShoppingBot.Features.Product
{
    internal partial class ProductSlashCommands
    {
        [SlashCommand("add-product", "Add a product")]
        [SlashRequirePermissions(DSharpPlus.Permissions.Administrator)]
        public async Task AddProduct(InteractionContext ctx, [Option("name", "Item name")] string name,
            [Option("price", "Item price")] double price, [Option("description", "Item description")] string description, [Option("image-url", "Url link to the image")] string imageUrl)
        {
            await Create<Entities.Product>(ctx, new AddProductCommand(name, price, description, imageUrl, ctx.Guild.Id.ToString()));
        }
    }
}
