using ShoppingBot.DAL.Repositories.Interfaces;
using ShoppingBot.Shared;
using ShoppingBot.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Product.DeleteProductByName
{
    internal class DeleteProductByNameCommandHandler : ICommandHandler<DeleteProductByNameCommand>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductByNameCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Result> Handle(DeleteProductByNameCommand request, CancellationToken cancellationToken)
        {
            await _productRepository.DeleteByNameAsync(request.Name);
            return Result.Success();
        }
    }
}
