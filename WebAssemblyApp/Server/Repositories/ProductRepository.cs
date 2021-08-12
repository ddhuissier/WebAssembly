using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAssemblyApp.Server.Data;
using WebAssemblyApp.Shared.Models;

namespace WebAssemblyApp.Server.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly WebAssemblyAppServerContext _context;

        public ProductRepository(WebAssemblyAppServerContext context)
        {
            _context = context;
        }

        public async Task<Product> Create(Product Product)
        {
            _context.Product.Add(Product);
            await _context.SaveChangesAsync();

            return Product;
        }

        public async Task Delete(int id)
        {
            var ProductToDelete = await _context.Product.FindAsync(id);
            _context.Product.Remove(ProductToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> Get()
        {
            return await _context.Product.ToListAsync();
        }

        public async Task<Product> Get(int id)
        {
            return await _context.Product.FindAsync(id);
        }

        public async Task Update(Product Product)
        {
            _context.Entry(Product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
