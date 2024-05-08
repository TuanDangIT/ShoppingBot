using DSharpPlus.SlashCommands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.User
{
    [SlashCommandGroup("user", "User operations")]
    internal partial class UserSlashCommands : ApplicationCommandModule
    {
        private readonly IMediator _mediator;

        public UserSlashCommands(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
