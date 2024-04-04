using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Order.CreateOrder
{
    internal class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.ServerId)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.ProductName)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Buyer)
                .NotNull()
                .NotEmpty();
        }
    }
}
