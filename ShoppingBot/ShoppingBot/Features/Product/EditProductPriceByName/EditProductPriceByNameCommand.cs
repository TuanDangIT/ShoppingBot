using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShoppingBot.Features.Product.EditProductPriceByName
{
    internal sealed record class EditProductPriceByNameCommand(string Name, double Price) : Shared.Abstractions.ICommand;
}
