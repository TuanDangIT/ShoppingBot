using ShoppingBot.Entities;
using ShoppingBot.Features.Order.GetAllOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.DAL.Repositories.Interfaces
{
    internal interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrderAsync();
        Order GetOrderByIdAsync(Guid id);
        Task<int> DeleteOrderByIdAsync(Guid id);
    }
}
