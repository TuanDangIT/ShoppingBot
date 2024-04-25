using ShoppingBot.DAL.Repositories.Interfaces;
using ShoppingBot.Features.Product;
using ShoppingBot.Shared;
using ShoppingBot.Shared.Abstractions;
using ShoppingBot.Shared.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Order.CreateOrder
{
    internal class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(IProductRepository productRepository,
            IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }
        public async Task<Result> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByNameAsync(request.ProductName, request.ServerId);
            if(product is null)
            {
                return Result.Failure(ProductErrors.NotFound);
            }
            var change = await _orderRepository.CreateOrderAsync(new Entities.Order()
            {
                Id = Guid.NewGuid(),
                Buyer = request.Buyer,
                ServerId = request.ServerId,
                ProductId = product.Id,
            });
            if(change is 0)
            {
                return Result.Failure(OrderErrors.NotCreated);
            }
            return Result.Success();

        }
    }
}
