using MediatR;
using ShoppingBot.DTOs;
using ShoppingBot.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Order.GetAllOrders
{
    internal record class GetAllOrdersQuery(int Page, string ServerId, string Username = default!) : IQuery<IEnumerable<OrderDto>>;
}
