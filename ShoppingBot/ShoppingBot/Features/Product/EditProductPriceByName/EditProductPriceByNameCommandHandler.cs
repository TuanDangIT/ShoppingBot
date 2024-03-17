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
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (validationResult.IsValid)
            {
                await _productRepository.EditProductPriceByNameAsync(request.Name, request.Price);
                return Result.Success();
            }
            return Result.Failure(ProductErrors.ValidationError);
        }
    }
}
