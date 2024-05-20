﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ShoppingBot.DAL.Repositories.Interfaces;
using ShoppingBot.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            var product = await _dbContext.Products.FirstAsync(x => x.Id == order.ProductId);
            if(product.Quantity is not null)
            {
                product.Quantity--;
            }
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

        public async Task<int> EditOrderProductAsync(Order order, Product newProduct)
        {
            order.ProductId = newProduct.Id;
            var change = await _dbContext.SaveChangesAsync();
            return change;
        }

        public async Task<IEnumerable<Order>> GetAllOrderAsync(int page, string serverId, params Expression<Func<Order, object>>[] includes)
        {
            int pageSize = 5;
            var productsQueryable = _dbContext.Orders.AsQueryable();
            if(includes is not null)
            {
                foreach(var include in includes)
                {
                    productsQueryable = productsQueryable.Include(include);
                }
            }
            var products = await productsQueryable.AsNoTracking()
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
