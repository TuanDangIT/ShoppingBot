using ShoppingBot.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.DAL.Repositories.Interfaces
{
    internal interface IProductRepository
    {
        Task<IEnumerable<Product>>GetAllAsync();
        Task<Product>GetByNameAsync(string name);
        Task EditByNameAsync(string name, Product product);
        Task DeleteByNameAsync(string name);
        Task CreateProductAsync(Product product);
    }
}
