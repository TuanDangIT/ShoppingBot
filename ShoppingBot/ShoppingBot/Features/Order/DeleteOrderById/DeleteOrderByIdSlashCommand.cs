using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using ShoppingBot.Entities;
using ShoppingBot.Features.Order.DeleteOrderById;

namespace ShoppingBot.Features.Order
{
    internal partial class OrderSlashCommands
    {
        [SlashCommand("delete-order-by-id", "Delete order by id")]
        [RequirePermissions(DSharpPlus.Permissions.Administrator)]
        public async Task DeleteOrderById(InteractionContext ctx,
            [Option("id", "Order id")] string id)
        {
            await Delete<Entities.Order>(ctx, new DeleteOrderByIdCommand(id, ctx.Guild.Id.ToString()));
        }
    }
}
