using DSharpPlus.SlashCommands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Shared
{
    internal class CommandModule : ApplicationCommandModule
    {
        protected readonly IMediator _mediator;

        public CommandModule(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
