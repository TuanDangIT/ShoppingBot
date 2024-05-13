using ShoppingBot.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Order
{
    internal static class Extensions
    {
        public static OrderDto AsDto(this Entities.Order order)
        {
            return new OrderDto()
            {
                Id = order.Id,
                Product = order.Product,
                CreatedAt = order.CreatedAt,
                LastUpdatedAt = order.LastUpdatedAt,
            };
        }
    }
}
