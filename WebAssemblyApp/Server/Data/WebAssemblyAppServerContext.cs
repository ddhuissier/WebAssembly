using Microsoft.EntityFrameworkCore;
using WebAssemblyApp.Shared.Models;

namespace WebAssemblyApp.Server.Data
{
    public class WebAssemblyAppServerContext : DbContext
    {
        public WebAssemblyAppServerContext (DbContextOptions<WebAssemblyAppServerContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
