using ShoppingBot.DTOs;
using ShoppingBot.Entities;
using ShoppingBot.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Product.GetAllProducts
{
    internal record class GetAllProductsQuery(int Page, string ServerId) : IQuery<IEnumerable<ProductDto>>;
}
