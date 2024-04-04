using MediatR;
using ShoppingBot.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Order.GetAllOrders
{
    internal record class GetAllOrdersQuery : IRequest<IEnumerable<OrderDto>>;
}
