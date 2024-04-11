using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Order.DeleteOrderById
{
    internal class DeleteOrderByIdCommandValidator : AbstractValidator<DeleteOrderByIdCommand>
    {
        public DeleteOrderByIdCommandValidator()
        {
            RuleFor(x => x.ServerId)
                .NotEmpty()
                .NotNull();
        }
    }
}
