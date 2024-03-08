using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Product.AddProduct
{
    internal record class AddProductCommand(string Name, string Price, string Description, string ImageUrl) : IRequest;
}
