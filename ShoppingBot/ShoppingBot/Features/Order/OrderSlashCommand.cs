using DSharpPlus.SlashCommands;
using MediatR;
using ShoppingBot.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Order
{
    [SlashCommandGroup("order", "Order operations")]
    internal partial class OrderSlashCommand : CommandModule
    {
        public OrderSlashCommand(IMediator mediator) : base(mediator)
        {
        }
    }
}
