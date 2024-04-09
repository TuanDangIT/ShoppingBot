using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
            var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == order.ProductId);
            await _dbContext.AddAsync(order);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteOrderByIdAsync(Guid id, string serverId)
        {
            var order = new Order()
            {
                Id = id,
                ServerId = serverId
            };
            var entry = _dbContext.Attach(order);
            entry.State = EntityState.Deleted;
            var change = await _dbContext.SaveChangesAsync();
            return change;

        }

        public async Task<IEnumerable<Order>> GetAllOrderAsync(int page, string serverId)
        {
            int pageSize = 5;
            var products = await _dbContext.Orders
                .Include(x => x.Product)
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
