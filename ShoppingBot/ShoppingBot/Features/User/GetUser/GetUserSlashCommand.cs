using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using ShoppingBot.Features.User.GetUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.User
{
    internal partial class UserSlashCommands
    {
        [SlashCommand("get-user", "Get user information")]
        public async Task GetUser(InteractionContext ctx,
            [Option("username", "User's username")]string username)
        {
            await ctx.DeferAsync();
            var result = await _mediator.Send(new GetUserQuery(username));
            DiscordEmbedBuilder outputEmbed;
            if (!result.IsFailure)
            {
                outputEmbed = new DiscordEmbedBuilder()
                {
                    Color = DiscordColor.Green,
                    Title = $"User operation reponse",
                    Description = $"User: {result.Value.Username}",
                };
            }
            else
            {
                outputEmbed = new DiscordEmbedBuilder()
                {
                    Color = DiscordColor.Red,
                    Title = $"User operation reponse",
                    Description = $"User delete operation failed",
                };
            }
            await ctx.EditResponseAsync(new DiscordWebhookBuilder()
                .AddEmbed(outputEmbed));
        }
        [SlashCommand("get-me", "Get my information")]
        public async Task GetMe(InteractionContext ctx)
        {
            await ctx.DeferAsync();
            var result = await _mediator.Send(new GetUserQuery(ctx.User.Username));
            DiscordEmbedBuilder outputEmbed;
            if (!result.IsFailure)
            {
                outputEmbed = new DiscordEmbedBuilder()
                {
                    Color = DiscordColor.Green,
                    Title = $"User operation reponse",
                    Description = $"User: {result.Value.Username}",
                };
            }
            else
            {
                outputEmbed = new DiscordEmbedBuilder()
                {
                    Color = DiscordColor.Red,
                    Title = $"User operation reponse",
                    Description = $"User delete operation failed",
                };
            }
            await ctx.EditResponseAsync(new DiscordWebhookBuilder()
                .AddEmbed(outputEmbed));
        }
    }
}
