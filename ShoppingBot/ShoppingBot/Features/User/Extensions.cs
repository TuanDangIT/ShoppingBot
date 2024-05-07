using ShoppingBot.Features.User.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.User
{
    internal static class Extensions
    {
        public static UserDto AsDto(this Entities.User user)
        {
            return new UserDto()
            {
                Username = user.Username,
            };
        }
    }
}
