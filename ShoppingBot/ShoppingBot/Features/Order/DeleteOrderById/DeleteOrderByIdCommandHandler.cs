using ShoppingBot.DAL.Repositories;
using ShoppingBot.DAL.Repositories.Interfaces;
using ShoppingBot.Shared;
using ShoppingBot.Shared.Abstractions;
using ShoppingBot.Shared.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Order.DeleteOrderById
{
    internal class DeleteOrderByIdCommandHandler : ICommandHandler<DeleteOrderByIdCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderByIdCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Result> Handle(DeleteOrderByIdCommand request, CancellationToken cancellationToken)
        {
            var change = await _orderRepository.DeleteOrderByIdAsync(request.Id, request.ServerId);
            if(change is 0)
            {
                return Result.Failure(OrderErrors.NotDeleted);
            }
            return Result.Success();
        }
    }
}
