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
        public async Task CreateProductAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteByNameAsync(string name)
        {
            var productToDelete = await GetByNameAsync(name);
            _dbContext.Remove(productToDelete);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditByNameAsync(string name, Product product)
        {
            var productToEdit = await GetByNameAsync(name);
            product.Name = productToEdit.Name;
            product.Description = productToEdit.Description;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public Task<Product> GetByNameAsync(string name) => _dbContext.Products.FirstAsync(x => x.Name == name);
    }
}
