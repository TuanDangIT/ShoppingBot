using FluentValidation;
using ShoppingBot.DAL.Repositories.Interfaces;
using ShoppingBot.Shared;
using ShoppingBot.Shared.Abstractions;
using ShoppingBot.Shared.Errors;
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
        private readonly IValidator<EditProductPriceByNameCommand> _validator;

        public EditProductPriceByNameCommandHandler(IProductRepository productRepository,
            IValidator<EditProductPriceByNameCommand> validator)
        {
            _productRepository = productRepository;
            _validator = validator;
        }
        public async Task<Result> Handle(EditProductPriceByNameCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByNameAsync(request.Name);
            if (product == null)
            {
                return Result.Failure(ProductErrors.NotFound);
            }
            await _productRepository.EditProductPriceByNameAsync(product, request.Price);
            return Result.Success();
        }
    }
}
