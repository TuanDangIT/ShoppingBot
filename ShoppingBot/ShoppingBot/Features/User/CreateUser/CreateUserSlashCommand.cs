using DSharpPlus.SlashCommands;
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
        }
    }
}
