using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Order.EditOrderProductById
{
    internal class EditOrderProductByIdCommandValidator : AbstractValidator<EditOrderProductByIdCommand>
    {
        public EditOrderProductByIdCommandValidator()
        {
            RuleFor(x => x.ServerId)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull();
        }
    }
}
