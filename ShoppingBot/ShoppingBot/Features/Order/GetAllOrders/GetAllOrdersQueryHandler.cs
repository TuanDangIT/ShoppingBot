using MediatR;
using ShoppingBot.DAL.Repositories;
using ShoppingBot.DAL.Repositories.Interfaces;
using ShoppingBot.DTOs;
using ShoppingBot.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingBot.Shared.Abstractions;
using ShoppingBot.Shared.Errors;

namespace ShoppingBot.Features.Order.GetAllOrders
{
    internal class GetAllOrdersQueryHandler : IQueryHandler<GetAllOrdersQuery, IEnumerable<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetAllOrdersQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result<IEnumerable<OrderDto>>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var result = request.Username is null ? 
                await _orderRepository.GetAllOrderAsync(request.Page, request.ServerId, x => x.Product, x => x.User) :
                (await _orderRepository.GetAllOrderAsync(request.Page, request.ServerId, x => x.Product, x => x.User)).Where(x => x.User.Username == request.Username);
            if (result.Count() == 0 || result is null)
            {
                return Result.Failure<IEnumerable<OrderDto>>(OrderErrors.NotFound);
            }

            return Result.Success(result.Select(x => x.AsDto()));
        }
    }
}
