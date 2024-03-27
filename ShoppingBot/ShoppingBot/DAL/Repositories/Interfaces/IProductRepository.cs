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
        Task<IEnumerable<Product>>GetAllAsync(int page, string serverId);
        Task<Product?>GetByNameAsync(string name, string serverId);
        Task<int> EditProductPriceByNameAsync(Product product, double price);
        Task<int> EditProductDescriptionByNameAsync(Product product, string description);
        Task<int> EditProductImageUrlByNameAsync(Product product, string imageUrl);
        Task<int> DeleteByNameAsync(Product product);
        Task<int> CreateProductAsync(Product product);
    }
}
