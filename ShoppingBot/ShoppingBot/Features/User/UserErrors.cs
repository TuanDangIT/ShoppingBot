using ShoppingBot.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.User
{
    internal class UserErrors
    {
        public static readonly Error ValidationError = new Error("product-validation-error", "Product validation failed");
        public static readonly Error NotFound = new Error("user-not-found", "User not found");
        public static readonly Error NotCreated = new Error("user-not-created", "User not created");
        public static readonly Error NotDeleted = new Error("product-not-deleted", "Product not deleted");
        public static readonly Error NotUpdated = new Error("product-not-found", "Product not updated");
    }
}
