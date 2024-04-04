using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Order.CreateOrder
{
    internal record class CreateOrderCommand(string Buyer, string ProductName, string ServerId) : IRequest;
}
