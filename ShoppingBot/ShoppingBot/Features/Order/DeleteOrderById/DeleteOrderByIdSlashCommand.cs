using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
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
            await ctx.DeferAsync();
            DiscordEmbedBuilder outputEmbed;
            var serverId = ctx.Guild.Id;
            var result = await _mediator.Send(new DeleteOrderByIdCommand(Guid.Parse(id), serverId.ToString()));
            if (result.IsFailure)
            {
                outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Red,
                    Title = $"Order operation response",
                    Description = "Order delete operation failed",
                    Footer = new DiscordEmbedBuilder.EmbedFooter()
                    {
                        Text = $"Additional information: \n" +
                        $"{result.Error.Code}: {result.Error.Description}"
                    }
                };
            }
            else
            {
                outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Green,
                    Title = $"Order operation response",
                    Description = "Order delete operation successed"
                };
            }
            await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(outputEmbed));
        }
    }
}
