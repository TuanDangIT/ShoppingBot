using MediatR;
using ShoppingBot.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Order
{
    internal class OrderSlashCommand : CommandModule
    {
        public OrderSlashCommand(IMediator mediator) : base(mediator)
        {
        }
    }
}
