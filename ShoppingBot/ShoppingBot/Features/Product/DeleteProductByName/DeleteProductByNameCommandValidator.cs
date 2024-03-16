using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Product.DeleteProductByName
{
    internal class DeleteProductByNameCommandValidator : AbstractValidator<DeleteProductByNameCommand>
    {
        public DeleteProductByNameCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(20);
        }
    }
}
