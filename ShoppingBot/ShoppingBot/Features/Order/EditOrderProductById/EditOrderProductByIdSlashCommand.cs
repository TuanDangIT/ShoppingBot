﻿using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.Attributes;
using ShoppingBot.Features.Order.EditOrderProductById;
using ShoppingBot.Features.Product.EditProductDescriptionByName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Order
{
    internal partial class OrderSlashCommands
    {
        [SlashCommand("edit-order-product", "Edit a order's product")]
        [SlashRequirePermissions(DSharpPlus.Permissions.Administrator)]
        public async Task EditOrderProduct(InteractionContext ctx, [Option("name", "Item name")] string name
            , [Option("id", "Order id")] string id)
        {
            Guid.TryParse(id, out var guidParsed);
            await   Edit<Entities.Order>(ctx, new EditOrderProductByIdCommand(name, ctx.Guild.Id.ToString(), guidParsed));
            //await ctx.DeferAsync();
            //DiscordEmbedBuilder outputEmbed;
            //var serverId = ctx.Guild.Id;
            //var result = await _mediator.Send(new EditOrderProductByIdCommand(name, serverId.ToString(), Guid.Parse(id)));
            //if (result.IsFailure)
            //{
            //    outputEmbed = new DiscordEmbedBuilder
            //    {
            //        Color = DiscordColor.Green,
            //        Title = $"Order operation response",
            //        Description = "Order edit operation failed",
            //        Footer = new DiscordEmbedBuilder.EmbedFooter()
            //        {
            //            Text = $"Additional information: \n" +
            //            $"{result.Error.Code}: {result.Error.Description}"
            //        }
            //    };
            //}
            //else
            //{
            //    outputEmbed = new DiscordEmbedBuilder
            //    {
            //        Color = DiscordColor.Green,
            //        Title = $"Order operation response",
            //        Description = "Order edit operation successed"
            //    };
            //}
            //await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(outputEmbed));
        }
    }
}
