using ShoppingBot.DTOs;
using ShoppingBot.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Product.GetProductByName
{
    internal record class GetProductByNameQuery(string Name) : IQuery<ProductDto>;
}
