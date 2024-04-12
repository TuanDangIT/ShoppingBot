using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.Attributes;
using ShoppingBot.Features.Order.GetOrderById;
using ShoppingBot.Features.Product.GetProductByName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Order
{
    internal partial class OrderSlashCommands
    {
        [SlashCommand("get-order-by-id", "Get a order by id")]
        [SlashRequirePermissions(DSharpPlus.Permissions.Administrator)]
        public async Task GetOrderById(InteractionContext ctx,
            [Option("id", "Order id")] string id)
        {
            await ctx.DeferAsync();
            var serverId = ctx.Guild.Id;
            var result = await _mediator.Send(new GetOrderByIdQuery(Guid.Parse(id), serverId.ToString()));
            DiscordEmbedBuilder outputEmbed;
            if (result.IsSuccess && result.Value != null)
            {
                outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Green,
                    Title = $"{result.Value.Id}",
                    Description = $"{result.Value.Product.Name}",
                    Footer = new DiscordEmbedBuilder.EmbedFooter()
                    {
                        Text = $"Last updated : {result.Value.LastUpdatedAt} (UTC +02:00), Created at: {result.Value.CreatedAt} (UTC +02:00)"
                    }
                }.AddField(nameof(result.Value.Product), result.Value.Product.Name, true);
            }
            else
            {
                outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Red,
                    Title = $"Order operation response",
                    Description = $"Order get operation failed",
                    Footer = new DiscordEmbedBuilder.EmbedFooter()
                    {
                        Text = $"Additional information: \n" +
                        $"{result.Error.Code}: {result.Error.Description}"
                    }

                };
            }
            await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(outputEmbed));
        }
    }
}
