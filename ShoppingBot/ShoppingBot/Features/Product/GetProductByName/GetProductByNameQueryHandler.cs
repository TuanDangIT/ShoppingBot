using ShoppingBot.DAL.Repositories.Interfaces;
using ShoppingBot.DTOs;
using ShoppingBot.Shared;
using ShoppingBot.Shared.Abstractions;
using ShoppingBot.Shared.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Product.GetProductByName
{
    internal class GetProductByNameQueryHandler : IQueryHandler<GetProductByNameQuery, ProductDto>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByNameQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Result<ProductDto>> Handle(GetProductByNameQuery request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.GetByNameAsync(request.Name);
            if (result == null)
            {
                return Result.Failure<ProductDto>(ProductErrors.NotFound);
            }
            return Result.Success(result.AsDto());
        }
    }
}
