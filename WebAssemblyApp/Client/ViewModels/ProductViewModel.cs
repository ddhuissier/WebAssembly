using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebAssemblyApp.Client.ViewModels.Contracts;
using WebAssemblyApp.Shared.Models;

namespace WebAssemblyApp.Client.ViewModels
{
    public class ProductViewModel : IProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProductPicDataUrl { get; set; }
        public byte[] Image { get; set; }
        public string Message { get; set; }
        private HttpClient _httpClient;

        public ProductViewModel()
        {
                
        }

        public ProductViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task UpdateProduct()
        {
            Product product = this;
            await _httpClient.PutAsJsonAsync("api/products/"+ product.Id, product);
            this.Message = "Product updated successfully";
        }

        public async Task GetProduct(int id)
        {
            Product product =  await _httpClient.GetFromJsonAsync<Product>("api/products/"+ id);
            LoadCurrentObject(product);
            this.Message = "Product loaded successfully";
        }
        private void LoadCurrentObject(ProductViewModel productViewModel)
        {
            Id = productViewModel.Id;
            Name = productViewModel.Name;
            Description = productViewModel.Description;
            Image = productViewModel.Image;
            ProductPicDataUrl = productViewModel.ProductPicDataUrl;
        }
        public static implicit operator ProductViewModel(Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Image = product.Image,
                ProductPicDataUrl = product.ProductPicDataUrl
            };
        }

        public static implicit operator Product(ProductViewModel productViewModel)
        {
            return new Product
            {
                Id = productViewModel.Id,
                Name = productViewModel.Name,
                Description = productViewModel.Description,
                Image = productViewModel.Image,
                ProductPicDataUrl = productViewModel.ProductPicDataUrl
            };
        }
    }
}
