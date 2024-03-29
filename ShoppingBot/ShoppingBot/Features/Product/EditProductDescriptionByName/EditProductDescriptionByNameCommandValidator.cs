﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Product.EditProductDescriptionByName
{
    internal class EditProductDescriptionByNameCommandValidator : AbstractValidator<EditProductDescriptionByNameCommand>
    {
        public EditProductDescriptionByNameCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(20);
            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200);
        }
    }
}
