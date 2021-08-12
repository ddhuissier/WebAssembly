using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssemblyApp.Shared.Models;

namespace WebAssemblyApp.Server.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> Get();
        Task<Product> Get(int id);
        Task<Product> Create(Product Product);
        Task Update(Product Product);
        Task Delete(int id);
    }
}
