using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAssemblyApp.Client.ViewModels.Contracts
{
    public interface IProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string Message { get; set; }

        public Task UpdateProduct();
        public Task GetProduct(int id);
    }
}
