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
        Task<IEnumerable<Product>>GetAll();
        Task<Product>GetByName(string name);
        Task EditByName(string name, Product product);
        Task DeleteByName(string name);
        Task CreateProduct(Product product);
    }
}
