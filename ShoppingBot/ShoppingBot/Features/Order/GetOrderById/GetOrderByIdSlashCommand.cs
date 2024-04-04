using DSharpPlus.SlashCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Order
{
    internal partial class OrderSlashCommand
    {
        [SlashCommand("get-order-by-id", "Get a order by id")]
        public async Task GetOrderById(InteractionContext ctx,
            [Option("id", "Order id")] Guid id)
        {

        }
    }
}
