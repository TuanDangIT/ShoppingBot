using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using ShoppingBot.Features.User.DTOs;
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
            [Option("username", "User's username")] string username)
        {
            await Get<UserDto>(ctx, new GetUserQuery(username, ctx.Guild.Id.ToString()));
        }
        [SlashCommand("get-me", "Get my information")]
        public async Task GetMe(InteractionContext ctx)
        {
            await Get<UserDto>(ctx, new GetUserQuery(ctx.User.Username, ctx.Guild.Id.ToString()));
        }
    }
}
