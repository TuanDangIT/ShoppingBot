using ShoppingBot.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Order.EditOrderProductById
{
    internal record class EditOrderProductByIdCommand(string Name, string ServerId, Guid Id) : ICommand;
}
