﻿using MediatR;
using ShoppingBot.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Order.GetOrderById
{
    internal record class GetOrderByIdQuery(Guid Id) : IRequest<OrderDto>;
}