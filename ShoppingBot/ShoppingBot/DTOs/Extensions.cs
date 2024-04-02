using ShoppingBot.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.DTOs
{
    internal static class Extensions
    {
        public static ProductDto AsDto(this Product product)
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
