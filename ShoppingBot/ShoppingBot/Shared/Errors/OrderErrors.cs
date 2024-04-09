using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Shared.Errors
{
    internal static class OrderErrors
    {
        public static readonly Error ValidationError = new Error("order-validation-error", "Order validation failed");
        public static readonly Error NotCreated = new Error("order-not-created", "Order not created");
        public static readonly Error NotDeleted = new Error("order-not-deleted", "Order not deleted");
        public static readonly Error NotFound = new Error("order-not-found", "Order not found");
        public static readonly Error NotUpdated = new Error("order-not-found", "Order not updated");
    }
}
