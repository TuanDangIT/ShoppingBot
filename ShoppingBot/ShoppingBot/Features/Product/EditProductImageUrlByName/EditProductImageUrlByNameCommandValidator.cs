using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Product.EditProductImageUrlByName
{
    internal class EditProductImageUrlByNameCommandValidator : AbstractValidator<EditProductImageUrlByNameCommand>
    {
        public EditProductImageUrlByNameCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(20);
        }
    }
}
