﻿using ShoppingBot.DAL.Repositories.Interfaces;
using ShoppingBot.Shared;
using ShoppingBot.Shared.Abstractions;
using ShoppingBot.Shared.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Product.EditProductImageUrlByName
{
    internal class EditProductImageUrlByNameCommandHandler : ICommandHandler<EditProductImageUrlByNameCommand>
    {
        private readonly IProductRepository _productRepository;

        public EditProductImageUrlByNameCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Result> Handle(EditProductImageUrlByNameCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByNameAsync(request.Name);
            if (product == null)
            {
                return Result.Failure(ProductErrors.NotFound);
            }
            await _productRepository.EditProductImageUrlByNameAsync(product, request.ImageUrl);
            return Result.Success();
        }
    }
}
