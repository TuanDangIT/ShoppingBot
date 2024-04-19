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
            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0);
        }
    }
}
