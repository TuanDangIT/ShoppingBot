using MediatR;
using ShoppingBot.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShoppingBot.Features.Order.CreateOrder
{
    internal record class CreateOrderCommand(string Username, string ProductName, string ServerId) : Shared.Abstractions.ICommand;
}
