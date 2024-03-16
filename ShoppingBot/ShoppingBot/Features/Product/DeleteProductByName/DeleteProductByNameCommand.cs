using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShoppingBot.Features.Product.DeleteProductByName
{
    internal sealed record class DeleteProductByNameCommand(string Name) : Shared.Abstractions.ICommand;
}
