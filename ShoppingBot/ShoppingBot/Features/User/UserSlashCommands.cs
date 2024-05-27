﻿using DSharpPlus.SlashCommands;
using MediatR;
using ShoppingBot.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.User
{
    [SlashCommandGroup("user", "User operations")]
    internal partial class UserSlashCommands : CommandModule
    {
        public UserSlashCommands(IMediator mediator) : base(mediator)
        {
        }
    }
}