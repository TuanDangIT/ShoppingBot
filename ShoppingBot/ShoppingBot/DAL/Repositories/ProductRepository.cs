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
    internal class ProductRepository : IProductRepository
    {
        private readonly ShoppingBotDbContext _dbContext;

        public ProductRepository(ShoppingBotDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CreateProductAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            var changes = await _dbContext.SaveChangesAsync();
            return changes;
        }

        public async Task<int> DeleteByNameAsync(Product product)
        {
            _dbContext.Remove(product);
            var changes = await _dbContext.SaveChangesAsync();
            return changes;
        }

        public async Task<int> EditProductPriceByNameAsync(Product product, double price)
        {
            product.Price = price;
            var changes = await _dbContext.SaveChangesAsync();
            return changes;
        }
        public async Task<int> EditProductDescriptionByNameAsync(Product product, string description)
        {
            product.Description = description;
            var changes = await _dbContext.SaveChangesAsync();
            return changes;
        }
        public async Task<int> EditProductImageUrlByNameAsync(Product product, string imageUrl)
        {
            product.ImageUrl = imageUrl;
            var changes = await _dbContext.SaveChangesAsync();
            return changes;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dbContext.Products
                .AsNoTracking()
                .ToListAsync();
        }

        public Task<Product?> GetByNameAsync(string name)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.Name == name);

            return Task.FromResult(product);
        }
    }
}
