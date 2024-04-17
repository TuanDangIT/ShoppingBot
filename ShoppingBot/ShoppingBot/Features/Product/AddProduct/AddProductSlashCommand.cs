using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ShoppingBot.Features.Product.AddProduct;
using ShoppingBot.Shared;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.SlashCommands.Attributes;
using ShoppingBot.Entities;
namespace ShoppingBot.Features.Product
{
    internal partial class ProductSlashCommands
    {
        [SlashCommand("add-product", "Add a product")]
        [SlashRequirePermissions(DSharpPlus.Permissions.Administrator)]
        public async Task AddProduct(InteractionContext ctx, [Option("name", "Item name")] string name,
            [Option("price", "Item price")] double price, [Option("description", "Item description")] string description, [Option("image-url", "Url link to the image")] string imageUrl)
        {
            await Create<Entities.Product>(ctx, new AddProductCommand(name, price, description, imageUrl, ctx.Guild.Id.ToString()));
            //await ctx.DeferAsync();
            //var serverId = ctx.Guild.Id;
            //var result = await _mediator.Send(new AddProductCommand(name, price, description, imageUrl, serverId.ToString()));
            //var outputEmbed = new DiscordEmbedBuilder();
            //if (result.IsFailure)
            //{
            //    IValidationResult validationResult = (IValidationResult)result;
            //    StringBuilder resultsStringBuilder = new StringBuilder();
            //    foreach(var error in validationResult.Errors)
            //    {
            //        resultsStringBuilder.Append($"{error.Code}: {error.Description}\n");
            //    }
            //    outputEmbed = new DiscordEmbedBuilder
            //    {
            //        Color = DiscordColor.Red,
            //        Title = $"Product operation response",
            //        Description = $"Product operation failed!",
            //        Footer = new DiscordEmbedBuilder.EmbedFooter()
            //        {
            //            Text = "Additional information:\n" +
            //            $"{resultsStringBuilder}"
            //        }
            //    };
            //}
            //else
            //{
            //    outputEmbed = new DiscordEmbedBuilder
            //    {
            //        Color = DiscordColor.Green,
            //        Title = $"Product operation response",
            //        Description = $"Product operation successed!"
            //    };
            //}

            //await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(outputEmbed));
        }
    }
}
