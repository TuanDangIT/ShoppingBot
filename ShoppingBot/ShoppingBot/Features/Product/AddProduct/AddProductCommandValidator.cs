using FluentValidation;
using ShoppingBot.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Product.AddProduct
{
    internal class AddProductCommandValidator : AbstractValidator<AddProductCommand>
    {
        public AddProductCommandValidator(ShoppingBotDbContext dbContext)
        {
            RuleFor(x => x.Name)
                .MaximumLength(20)
                .Custom((value, context) =>
                {
                    if (dbContext.Products.Any(x => x.Name == value))
                    {
                        context.AddFailure("Name", "The name is taken");
                    }
                });
            RuleFor(x => x.Description)
                .MaximumLength(200);
            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0);
        }
    }
}
