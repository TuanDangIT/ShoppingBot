using Microsoft.EntityFrameworkCore;
using ShoppingBot.DAL.Repositories.Interfaces;
using ShoppingBot.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.DAL.Repositories
{
    internal class OrderRepository : IOrderRepository
    {
        private readonly ShoppingBotDbContext _dbContext;

        public OrderRepository(ShoppingBotDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateOrderAsync(Order order)
        {
            await _dbContext.AddAsync(order);
            return await _dbContext.SaveChangesAsync();
        }

        public Task<int> DeleteOrderByIdAsync(Guid id, string serverId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Order>> GetAllOrderAsync(int page, string serverId)
        {
            int pageSize = 5;
            var products = await _dbContext.Orders
                .AsNoTracking()
                .Where(x => x.ServerId == serverId)
                .ToListAsync();
            return products.Skip(pageSize * (page - 1))
                .Take(pageSize).ToList();
        }

        public Task<Order?> GetOrderByIdAsync(Guid id, string serverId)
        {
            var order = _dbContext.Orders
                .Include(x => x.Product)
                .Where(x => x.ServerId == serverId)
                .FirstOrDefault(x => x.Id == id);

            return Task.FromResult(order);
        }
    }
}
