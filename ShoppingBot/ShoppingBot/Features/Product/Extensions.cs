using ShoppingBot.DTOs;
using ShoppingBot.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Product
{
    internal static class Extensions
    {
        public static ProductDto AsDto(this Entities.Product product)
        {
            return new ProductDto()
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                ServerId = product.ServerId,
                LastUpdatedAt = product.LastUpdatedAt,
                CreatedAt = product.CreatedAt,
            };
        }
    }
}
