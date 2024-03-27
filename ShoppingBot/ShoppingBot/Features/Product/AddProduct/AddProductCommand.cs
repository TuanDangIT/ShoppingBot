using MediatR;
using ShoppingBot.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Product.AddProduct
{
    internal record class AddProductCommand(string Name, double Price, string Description, string ImageUrl, string ServerId) : ICommand;
}
