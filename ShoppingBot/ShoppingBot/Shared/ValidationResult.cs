using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Shared
{
    internal class ValidationResult : Result, IValidationResult
    {
        public Error[] Errors { get; }
        public ValidationResult(Error[] errors) : base(false, IValidationResult.ValidationError)
        {
            Errors = errors;
        }
        public static ValidationResult WithErrors(Error[] errors) => new ValidationResult(errors);
    }
}
