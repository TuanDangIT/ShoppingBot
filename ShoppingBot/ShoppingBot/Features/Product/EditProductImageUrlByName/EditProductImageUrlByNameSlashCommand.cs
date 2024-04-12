using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.Attributes;
using ShoppingBot.Features.Product.EditProductImageUrlByName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Product
{
    internal partial class ProductSlashCommands
    {
        [SlashCommand("edit-product-imageurl", "Edit a product's image URL")]
        [SlashRequirePermissions(DSharpPlus.Permissions.Administrator)]
        public async Task EditProductImageUrlByName(InteractionContext ctx, [Option("name", "Item name")] string name
           , [Option("image-url", "Url link to the image")] string imageUrl)
        {
            await ctx.DeferAsync();
            DiscordEmbedBuilder outputEmbed;
            var serverId = ctx.Guild.Id;
            var result = await _mediator.Send(new EditProductImageUrlByNameCommand(name, imageUrl, serverId.ToString()));
            if (result.IsFailure)
            {
                outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Red,
                    Title = $"Product operation response",
                    Description = "Product edit operation failed",
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
                    Title = $"Product operation response",
                    Description = "Product edit operation successed"
                };
            }
            await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(outputEmbed));
        }
    }
}
