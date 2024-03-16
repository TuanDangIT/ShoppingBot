using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Product.EditProductPriceByName
{
    internal class EditProductPriceByNameCommandValidator : AbstractValidator<EditProductPriceByNameCommand>
    {
        public EditProductPriceByNameCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Price)
                .NotNull()
                .NotEmpty()
                .GreaterThanOrEqualTo(0);
        }
    }
}
