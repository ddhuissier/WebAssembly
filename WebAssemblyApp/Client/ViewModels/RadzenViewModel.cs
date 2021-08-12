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
    public class RadzenViewModel : IRadzenViewModel
    {
        public List<Product> Products { get; set; }

        private HttpClient _httpClient;

        public RadzenViewModel()
        {
                
        }

        public RadzenViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task GetProducts()
        {
            List<Product> products =  await _httpClient.GetFromJsonAsync<List<Product>>("api/products");
            LoadCurrentObject(new RadzenViewModel() { Products = products });
         }

        public async Task GetProduct(int id)
        {
            Product product = await _httpClient.GetFromJsonAsync<Product>("api/products/"+id);
            var radzenViewModel = new RadzenViewModel();
            radzenViewModel.Products.Add(product);
            LoadCurrentObject(radzenViewModel);
        }
        private void LoadCurrentObject(RadzenViewModel radzenViewModel)
        {
            Products = radzenViewModel.Products;
        }

        public static implicit operator RadzenViewModel(List<Product> products)
        {
            return new RadzenViewModel
            {
                Products = products
            };
        }

        public static implicit operator RadzenComponent(RadzenViewModel radzenViewModel)
        {
            return new RadzenComponent
            {
                Products = radzenViewModel.Products
            };
        }
    }
}
