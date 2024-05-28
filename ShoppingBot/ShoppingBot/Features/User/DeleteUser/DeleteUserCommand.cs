using ShoppingBot.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.User.DeleteUser
{
    internal record class DeleteUserCommand(string Username, string ServerId) : Shared.Abstractions.ICommand;
}
