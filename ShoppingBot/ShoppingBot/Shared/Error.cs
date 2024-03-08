using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Shared
{
    internal sealed record class Error(string Code, string? Description = null)
    {
        public static readonly Error None = new Error(string.Empty);
        public static implicit operator Result(Error error) => Result.Failure(error);
    }
}
