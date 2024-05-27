using ShoppingBot.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShoppingBot.Features.User.CreateUser
{
    internal record class CreateUserCommand(string Username, string ServerId) : Shared.Abstractions.ICommand;
}
