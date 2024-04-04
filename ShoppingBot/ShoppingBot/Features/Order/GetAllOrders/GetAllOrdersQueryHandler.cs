using MediatR;
using ShoppingBot.DAL.Repositories.Interfaces;
using ShoppingBot.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Order.GetAllOrders
{
    internal class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetAllOrdersQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        Task<IEnumerable<OrderDto>> IRequestHandler<GetAllOrdersQuery, IEnumerable<OrderDto>>.Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
