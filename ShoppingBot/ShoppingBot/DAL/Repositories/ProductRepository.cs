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
        public async Task CreateProduct(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteByName(string name)
        {
            var productToDelete = await GetByName(name);
            _dbContext.Remove(productToDelete);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditByName(string name, Product product)
        {
            var productToEdit = await GetByName(name);
            product.Name = productToEdit.Name;
            product.Description = productToEdit.Description;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public Task<Product> GetByName(string name) => _dbContext.Products.FirstAsync(x => x.Name == name);
    }
}
