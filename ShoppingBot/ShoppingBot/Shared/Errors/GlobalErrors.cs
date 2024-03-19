using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Shared.Errors
{
    internal static class GlobalErrors
    {
        public static readonly Error GlobalError = new Error("global-error", "Something went wrong");
    }
}
