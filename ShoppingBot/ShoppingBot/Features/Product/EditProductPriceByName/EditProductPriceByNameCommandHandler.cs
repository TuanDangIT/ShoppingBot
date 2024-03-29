﻿using FluentValidation;
using ShoppingBot.DAL.Repositories.Interfaces;
using ShoppingBot.Shared;
using ShoppingBot.Shared.Abstractions;
using ShoppingBot.Shared.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
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
            var product = await _productRepository.GetByNameAsync(request.Name, request.ServerId);
            if (product == null)
            {
                return Result.Failure(ProductErrors.NotFound);
            }
            var changes = await _productRepository.EditProductPriceByNameAsync(product, request.Price);
            if (changes is 0)
            {
                return Result.Failure(ProductErrors.NotUpdated);
            }
            return Result.Success();
        }
    }
}
