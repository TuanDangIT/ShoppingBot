using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using ShoppingBot.Features.User.CreateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.User
{
    internal partial class UserSlashCommands
    {
        [SlashCommand("register-user", "Register yourself to conduct any operations")]
        public async Task CreateUser(InteractionContext ctx)
        {

            //await ctx.DeferAsync();
            //var result = await _mediator.Send(new CreateUserCommand(ctx.User.Username));
            //DiscordEmbedBuilder outputEmbed;
            //if (!result.IsFailure)
            //{
            //    outputEmbed = new DiscordEmbedBuilder()
            //    {
            //        Color = DiscordColor.Green,
            //        Title = $"User operation reponse",
            //        Description = $"User create operation successed",
            //    };
            //}
            //else
            //{
            //    outputEmbed = new DiscordEmbedBuilder()
            //    {
            //        Color = DiscordColor.Red,
            //        Title = $"User operation reponse",
            //        Description = $"User create operation failed",
            //    };
            //}
            //await ctx.EditResponseAsync(new DiscordWebhookBuilder()
            //    .AddEmbed(outputEmbed));
        }
    }
}
