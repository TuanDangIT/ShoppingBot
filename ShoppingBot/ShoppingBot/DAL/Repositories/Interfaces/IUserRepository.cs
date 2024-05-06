using ShoppingBot.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.DAL.Repositories.Interfaces
{
    internal interface IUserRepository
    {
        Task<int> CreateUser(User user);
        Task<int> DeleteUser(string username);
        Task<User?> GetUser(string username);
    }
}
