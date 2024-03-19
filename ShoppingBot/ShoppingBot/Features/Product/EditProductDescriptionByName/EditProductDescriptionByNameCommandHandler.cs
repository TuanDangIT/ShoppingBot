using ShoppingBot.DAL.Repositories.Interfaces;
using ShoppingBot.Shared;
using ShoppingBot.Shared.Abstractions;
using ShoppingBot.Shared.Errors;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Product.EditProductDescriptionByName
{
    internal class EditProductDescriptionByNameCommandHandler : ICommandHandler<EditProductDescriptionByNameCommand>
    {
        private readonly IProductRepository _productRepository;

        public EditProductDescriptionByNameCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Result> Handle(EditProductDescriptionByNameCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByNameAsync(request.Name);
            if(product == null)
            {
                return Result.Failure(ProductErrors.NotFound);
            }
            var changes = await _productRepository.EditProductDescriptionByNameAsync(product, request.Description);
            if(changes is 0)
            {
                return Result.Failure(ProductErrors.NotUpdated);
            }
            return Result.Success();
        }
    }
}
