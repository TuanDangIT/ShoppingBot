using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShoppingBot.DAL;
using ShoppingBot.Features.Product.AddProduct;
using ShoppingBot.Features.Product.DeleteProductByName;
using ShoppingBot.Features.Product.EditProductDescriptionByName;
using ShoppingBot.Features.Product.EditProductImageUrlByName;
using ShoppingBot.Features.Product.EditProductPriceByName;
using ShoppingBot.Features.Product.GetAllProducts;
using ShoppingBot.Features.Product.GetProductByName;
using ShoppingBot.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Product
{
    [SlashCommandGroup("product", "Product operations")]
    internal partial class ProductSlashCommands : CommandModule
    {
        public ProductSlashCommands(IMediator mediator) : base(mediator)
        {
            
        }
    }
}
