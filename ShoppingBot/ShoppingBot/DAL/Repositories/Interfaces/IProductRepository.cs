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
        Task EditProductPriceByNameAsync(string name, double price);
        Task EditProductDescriptionByNameAsync(string name, string description);
        Task EditProductImageUrlByNameAsync(string name, string imageUrl);
        Task DeleteByNameAsync(string name);
        Task CreateProductAsync(Product product);
    }
}
