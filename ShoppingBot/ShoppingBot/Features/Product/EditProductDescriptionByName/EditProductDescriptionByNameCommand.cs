using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShoppingBot.Features.Product.EditProductDescriptionByName
{
    internal sealed record class EditProductDescriptionByNameCommand(string Name, string Description, string ServerId) : Shared.Abstractions.ICommand;
}
