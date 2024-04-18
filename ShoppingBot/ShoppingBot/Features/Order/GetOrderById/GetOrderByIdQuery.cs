using MediatR;
using ShoppingBot.DTOs;
using ShoppingBot.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Order.GetOrderById
{
    internal record class GetOrderByIdQuery(string GuidId, string ServerId) : IQuery<OrderDto>;
}
