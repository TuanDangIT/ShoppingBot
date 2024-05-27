using ShoppingBot.Entities;
using ShoppingBot.Features.User.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.User.GetUser
{
    internal record class GetUserQuery(string Username, string ServerId) : Shared.Abstractions.IQuery<UserDto>;
}
