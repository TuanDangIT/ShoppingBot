using ShoppingBot.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Order.DeleteOrderById
{
    internal record class DeleteOrderByIdCommand(Guid Id, string ServerId) : ICommand;
}
