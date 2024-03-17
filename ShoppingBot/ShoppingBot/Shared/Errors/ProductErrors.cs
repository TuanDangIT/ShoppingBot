using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Shared.Errors
{
    internal static class ProductErrors
    {
        public static readonly Error ValidationError = new Error("product-validation-error", "product validation failed");
    }
}
