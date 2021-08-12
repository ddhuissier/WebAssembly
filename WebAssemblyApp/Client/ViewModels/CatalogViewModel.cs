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
    public class CatalogViewModel : ICatalogViewModel
    {
        public List<Product> Products { get; set; }

        private HttpClient _httpClient;

        public CatalogViewModel()
        {
                
        }

        public CatalogViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task GetProducts()
        {
            List<Product> products =  await _httpClient.GetFromJsonAsync<List<Product>>("api/products");
            LoadCurrentObject(new CatalogViewModel() { Products = products });
         }
        private void LoadCurrentObject(CatalogViewModel catalogViewModel)
        {
            Products = catalogViewModel.Products;
        }

        public static implicit operator CatalogViewModel(List<Product> products)
        {
            return new CatalogViewModel
            {
                Products = products
            };
        }

        public static implicit operator Catalog(CatalogViewModel catalogViewModel)
        {
            return new Catalog
            {
                Products = catalogViewModel.Products
            };
        }
    }
}
