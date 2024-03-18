using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Shared
{
    internal interface IValidationResult
    {
        public static readonly Error ValidationError = new("ValidationError", "A validation problem occured.");
        Error[] Errors { get; }
    }
}
