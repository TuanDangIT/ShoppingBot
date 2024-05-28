using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using ShoppingBot.Features.User.CreateUser;
using ShoppingBot.Features.User.DeleteUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.User
{
    internal partial class UserSlashCommands
    {
        [SlashCommand("delete-user", "Delete yourself")]
        public async Task DeleteUser(InteractionContext ctx)
        {
            await Delete<Entities.User>(ctx, new DeleteUserCommand(ctx.User.Username, ctx.Guild.Id.ToString()));
            //await ctx.DeferAsync();
            //var result = await _mediator.Send(new DeleteUserCommand(ctx.User.Username, ctx.Guild.Id.ToString()));
            //DiscordEmbedBuilder outputEmbed;
            //if (!result.IsFailure)
            //{
            //    outputEmbed = new DiscordEmbedBuilder()
            //    {
            //        Color = DiscordColor.Green,
            //        Title = $"User operation reponse",
            //        Description = $"User delete operation successed",
            //    };
            //}
            //else
            //{
            //    outputEmbed = new DiscordEmbedBuilder()
            //    {
            //        Color = DiscordColor.Red,
            //        Title = $"User operation reponse",
            //        Description = $"User delete operation failed",
            //    };
            //}
            //await ctx.EditResponseAsync(new DiscordWebhookBuilder()
            //    .AddEmbed(outputEmbed));
        }
    }
}
