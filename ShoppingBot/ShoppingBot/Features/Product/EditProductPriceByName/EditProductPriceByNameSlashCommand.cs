using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.Attributes;
using ShoppingBot.Features.Product.EditProductPriceByName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Product
{
    internal partial class ProductSlashCommands
    {
        [SlashCommand("edit-product-price", "Edit a product's price")]
        [SlashRequirePermissions(DSharpPlus.Permissions.Administrator)]
        public async Task EditProductPriceByName(InteractionContext ctx, [Option("name", "Item name")] string name,
            [Option("price", "Item price")] double price)
        {
            await Edit<Entities.Product>(ctx, new EditProductPriceByNameCommand(name, price, ctx.Guild.Id.ToString()));
            //await ctx.DeferAsync();
            //DiscordEmbedBuilder outputEmbed;
            //var serverId = ctx.Guild.Id;
            //var result = await _mediator.Send(new EditProductPriceByNameCommand(name, price, serverId.ToString()));
            //if (result.IsFailure)
            //{
            //    outputEmbed = new DiscordEmbedBuilder
            //    {
            //        Color = DiscordColor.Red,
            //        Title = $"Product operation response",
            //        Description = "Product edit operation failed",
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
            //        Title = $"Product operation response",
            //        Description = "Product edit operation successed"
            //    };
            //}
            //await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(outputEmbed));
        }

    }
}