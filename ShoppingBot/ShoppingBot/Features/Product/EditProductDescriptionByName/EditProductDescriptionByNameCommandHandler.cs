using ShoppingBot.DAL.Repositories.Interfaces;
using ShoppingBot.Shared;
using ShoppingBot.Shared.Abstractions;
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
            await _productRepository.EditProductDescriptionByNameAsync(request.Name, request.Description);
            return Result.Success();
        }
    }
}
