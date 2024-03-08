using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Shared.Abstractions
{
    internal interface ICommand : IRequest<Result>
    {
    }
    internal interface ICommand<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
