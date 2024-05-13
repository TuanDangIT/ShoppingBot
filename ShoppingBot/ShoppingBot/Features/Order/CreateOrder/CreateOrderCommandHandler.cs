using ShoppingBot.DAL.Repositories.Interfaces;
using ShoppingBot.Features.Product;
using ShoppingBot.Features.User;
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
        private readonly IUserRepository _userRepository;

        public CreateOrderCommandHandler(IProductRepository productRepository,
            IOrderRepository orderRepository
            , IUserRepository userRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }
        public async Task<Result> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByNameAsync(request.ProductName, request.ServerId);
            if(product is null)
            {
                return Result.Failure(ProductErrors.NotFound);
            }
            if(product.Quantity != null && product.Quantity == 0)
            {
                return Result.Failure(ProductErrors.OutOfStock);
            }
            var user = await _userRepository.GetUser(request.Username);
            if(user is null)
            {
                return Result.Failure(UserErrors.NotFound);
            }
            var change = await _orderRepository.CreateOrderAsync(new Entities.Order()
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
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
