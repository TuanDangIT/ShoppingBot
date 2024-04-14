using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using Newtonsoft.Json.Linq;
using ShoppingBot.DTOs;
using ShoppingBot.Features.Product.GetProductByName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Product
{
    internal partial class ProductSlashCommands
    {
        [SlashCommand("get-product-by-name", "Get a product by name")]
        public async Task GetProductByName(InteractionContext ctx,
            [Option("name", "Item name")] string name)
        {
            await Get<ProductDto>(ctx, new GetProductByNameQuery(name, ctx.Guild.Id.ToString()));
            //await ctx.DeferAsync();
            //var serverId = ctx.Guild.Id;
            //var result = await _mediator.Send(new GetProductByNameQuery(name, serverId.ToString()));
            //DiscordEmbedBuilder outputEmbed;
            //if (result.IsSuccess && result.Value != null)
            //{
            //    outputEmbed = new DiscordEmbedBuilder
            //    {
            //        Color = DiscordColor.Green,
            //        Title = $"{result.Value.Name}",
            //        Description = $"{result.Value.Description}",
            //        Footer = new DiscordEmbedBuilder.EmbedFooter()
            //        {
            //            Text = $"Last updated : {result.Value.LastUpdatedAt} (UTC +02:00), Created at: {result.Value.CreatedAt} (UTC +02:00)"
            //        }
            //    }.AddField(nameof(result.Value.Price), result.Value.Price.ToString("F"), true);

            //    if (result.Value.ImageUrl != null && result.Value.ImageUrl.Contains("https"))
            //    {
            //        outputEmbed.ImageUrl = result.Value.ImageUrl;
            //    }
            //}
            //else
            //{
            //    outputEmbed = new DiscordEmbedBuilder
            //    {
            //        Color = DiscordColor.Red,
            //        Title = $"Product operation response",
            //        Description = $"Product get operation failed",
            //        Footer = new DiscordEmbedBuilder.EmbedFooter()
            //        {
            //            Text = $"Additional information: \n" +
            //            $"{result.Error.Code}: {result.Error.Description}"
            //        }

            //    };
            //}
            //await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(outputEmbed));
        }
    }
}
