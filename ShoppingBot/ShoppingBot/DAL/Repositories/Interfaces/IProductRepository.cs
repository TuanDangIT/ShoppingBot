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
        Task EditProductPriceByNameAsync(Product product, double price);
        Task EditProductDescriptionByNameAsync(Product product, string description);
        Task EditProductImageUrlByNameAsync(Product product, string imageUrl);
        Task DeleteByNameAsync(string name);
        Task CreateProductAsync(Product product);
    }
}
