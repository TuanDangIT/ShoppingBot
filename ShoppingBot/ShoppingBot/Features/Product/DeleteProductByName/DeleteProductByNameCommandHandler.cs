using ShoppingBot.DAL.Repositories.Interfaces;
using ShoppingBot.Shared;
using ShoppingBot.Shared.Abstractions;
using ShoppingBot.Shared.Errors;
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
            var changes = await _productRepository.DeleteByNameAsync(request.Name);
            if(changes is 0)
            {
                return Result.Failure(ProductErrors.NotDeleted);
            }
            return Result.Success();
        }
    }
}
