using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ShoppingBot.DAL.Repositories.Interfaces;
using ShoppingBot.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.DAL.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly ShoppingBotDbContext _dbContext;

        public UserRepository(ShoppingBotDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CreateUser(User user)
        {
            await _dbContext.Users.AddAsync(user);
            var change = await _dbContext.SaveChangesAsync();
            return change;
        }

        public async Task<int> DeleteUser(User user)
        {
            _dbContext.Users.Remove(user);
            var change = await _dbContext.SaveChangesAsync();
            return change;
        }

        public async Task<User?> GetUser(string username, string serverId)
        {
            return await _dbContext.Users
                .Where(x => x.ServerId == serverId)
                .FirstOrDefaultAsync(x => x.Username == username);
        }
    }
}
