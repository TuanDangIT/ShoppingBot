using ShoppingBot.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Product.EditProductImageUrlByName
{
    internal sealed record class EditProductImageUrlByNameCommand(string Name, string ImageUrl, string ServerId) : ICommand;
}
