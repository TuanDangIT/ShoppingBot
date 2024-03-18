using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Shared
{
    internal class ValidationResult<TValue> : Result<TValue>, IValidationResult
    {
        public Error[] Errors { get; }
        public ValidationResult(Error[] errors) : base(default!, false, IValidationResult.ValidationError)
        {
            Errors = errors;
        }
    }
}
