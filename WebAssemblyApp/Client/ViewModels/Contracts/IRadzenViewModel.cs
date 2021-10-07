using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssemblyApp.Shared.Models;

namespace WebAssemblyApp.Client.ViewModels.Contracts
{
    public interface IRadzenViewModel
    {
        public Product CurrentProduct { get; set; }
        public List<Product> Products { get; set; }

        public Task GetProducts();
        public Task GetProduct(int id);
        public Task AddProduct();
        public Task UpdateProduct(int id);
        public void DeleteProducts(List<Product> selectedProducts);
    }
}
