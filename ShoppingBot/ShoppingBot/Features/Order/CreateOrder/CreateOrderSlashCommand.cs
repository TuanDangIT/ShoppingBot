using DSharpPlus.SlashCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Order
{
    internal partial class OrderSlashCommands
    {
        [SlashCommand("create-order", "Create an order")]
        public async Task GetOrderById(InteractionContext ctx,
            [Option("product-name", "Product name for an order")] string productName)
        {

        }
    }
}
