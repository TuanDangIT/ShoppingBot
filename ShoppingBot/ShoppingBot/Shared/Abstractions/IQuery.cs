﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Shared.Abstractions
{
    internal interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {

    }
}
