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

        public Task<int> CreateOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteOrderByIdAsync(Guid id, string serverId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAllOrderAsync(string serverId)
        {
            throw new NotImplementedException();
        }

        public Order GetOrderByIdAsync(Guid id, string serverId)
        {
            throw new NotImplementedException();
        }
    }
}
