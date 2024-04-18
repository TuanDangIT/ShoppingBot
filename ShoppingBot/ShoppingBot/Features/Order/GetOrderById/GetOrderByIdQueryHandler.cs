using MediatR;
using ShoppingBot.DAL.Repositories;
using ShoppingBot.DAL.Repositories.Interfaces;
using ShoppingBot.DTOs;
using ShoppingBot.Shared.Errors;
using ShoppingBot.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingBot.Shared.Abstractions;

namespace ShoppingBot.Features.Order.GetOrderById
{
    internal class GetOrderByIdQueryHandler : IQueryHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result<OrderDto>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            if(Guid.TryParse(request.GuidId, out var guidParsed))
            {
                return Result.Failure<OrderDto>(OrderErrors.NotGuidFormat);
            }
            var order = await _orderRepository.GetOrderByIdAsync(guidParsed, request.ServerId);
            if (order is null)
            {
                return Result.Failure<OrderDto>(OrderErrors.NotFound);
            }
            return Result.Success(order.AsDto());
        }
    }
}
