using ShoppingBot.DAL.Repositories.Interfaces;
using ShoppingBot.Shared;
using ShoppingBot.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Product.EditProductPriceByName
{
    internal class EditProductPriceByNameCommandHandler : ICommandHandler<EditProductPriceByNameCommand>
    {
        private readonly IProductRepository _productRepository;

        public EditProductPriceByNameCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Result> Handle(EditProductPriceByNameCommand request, CancellationToken cancellationToken)
        {
            await _productRepository.EditProductPriceByNameAsync(request.Name, request.Price);
            return Result.Success();
        }
    }
}
