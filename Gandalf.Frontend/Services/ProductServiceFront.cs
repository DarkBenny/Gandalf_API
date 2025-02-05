using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gandalf.Frontend.Models;

namespace Gandalf.Frontend.Services
{
    public class ProductServiceFront
    {
        private readonly HttpClient httpClient;

        public ProductServiceFront(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Product>?> GetProducts()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Product>>("/api/products");
        }

        public async Task<Product?> GetProduct(int id)
        {
            return await httpClient.GetFromJsonAsync<Product?>($"/api/products/{id}");
        }

        //public async Task<IEnumerable<Product>?> GetProductsByCategory(int id)
        //{
        //    return await httpClient.GetFromJsonAsync<IEnumerable<Product>>("/api/products");
        //}


    }
}
