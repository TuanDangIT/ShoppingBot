using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.Attributes;
using ShoppingBot.Features.Order.CreateOrder;
using ShoppingBot.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Order
{
    internal partial class OrderSlashCommands
    {
        [SlashCommand("create-order", "Create an order")]
        [SlashRequirePermissions(DSharpPlus.Permissions.Administrator)]
        public async Task CreateOrder(InteractionContext ctx,
            [Option("product-name", "Product name for an order")] string productName)
        {
            await ctx.DeferAsync();
            var serverId = ctx.Guild.Id;
            var buyerName = ctx.User.Username;
            var result = await _mediator.Send(new CreateOrderCommand(buyerName, productName, serverId.ToString()));
            var outputEmbed = new DiscordEmbedBuilder();
            if (result.IsFailure)
            {
                IValidationResult validationResult = (IValidationResult)result;
                StringBuilder resultsStringBuilder = new StringBuilder();
                foreach (var error in validationResult.Errors)
                {
                    resultsStringBuilder.Append($"{error.Code}: {error.Description}\n");
                }
                outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Red,
                    Title = $"Order operation response",
                    Description = $"Order operation failed!",
                    Footer = new DiscordEmbedBuilder.EmbedFooter()
                    {
                        Text = "Additional information:\n" +
                        $"{resultsStringBuilder}"
                    }
                };
            }
            else
            {
                outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Green,
                    Title = $"Order operation response",
                    Description = $"Order operation successed!"
                };
            }

            await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(outputEmbed));
        }
    }
}
