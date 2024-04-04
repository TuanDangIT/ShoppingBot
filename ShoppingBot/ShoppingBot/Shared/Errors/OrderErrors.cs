using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Shared.Errors
{
    internal static class OrderErrors
    {
        public static readonly Error NotCreated = new Error("order-not-created", "Order not created");
    }
}
