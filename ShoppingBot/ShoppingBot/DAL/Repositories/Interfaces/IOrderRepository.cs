using ShoppingBot.Entities;
using ShoppingBot.Features.Order.GetAllOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.DAL.Repositories.Interfaces
{
    internal interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrderAsync(int page, string serverId, params Expression<Func<Order, object>>[] includes);
        Task<Order?> GetOrderByIdAsync(Guid id, string serverId);
        Task<int> DeleteOrderByIdAsync(Guid id, string serverId);
        Task<int> CreateOrderAsync(Order order);
        Task<int> EditOrderProductAsync(Order order, Product newProduct);
    }
}
