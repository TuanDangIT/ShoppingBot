using ShoppingBot.DAL.Repositories;
using ShoppingBot.DTOs;
using ShoppingBot.Shared;
using ShoppingBot.Shared.Abstractions;
using ShoppingBot.Shared.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Order.EditOrderProductById
{
    internal class EditOrderProductByIdCommandHandler : ICommandHandler<EditOrderProductByIdCommand>
    {
        private readonly ProductRepository _productRepository;
        private readonly OrderRepository _orderRepository;

        public EditOrderProductByIdCommandHandler(ProductRepository productRepository, OrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }
        public async Task<Result> Handle(EditOrderProductByIdCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByNameAsync(request.Name, request.ServerId);
            if(product is null)
            {
                return Result.Failure(ProductErrors.NotFound);
            }
            var order = await _orderRepository.GetOrderByIdAsync(request.Id, request.ServerId);
            if (order is null)
            {
                return Result.Failure(OrderErrors.NotFound);
            }
            var change = await _orderRepository.EditOrderProductAsync(order, product);
            if(change is 0)
            {
                return Result.Failure(OrderErrors.NotUpdated);
            }
            return Result.Success();

        }
    }
}
