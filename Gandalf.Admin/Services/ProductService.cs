using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gandalf.Frontend.Models;

namespace Gandalf.Frontend.Services
{
    public class ProductService
    {
        private readonly HttpClient httpClient;

        public ProductService(HttpClient httpClient)
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

        public async Task CreateProduct(Product product)
        {
            var response = await httpClient.PostAsJsonAsync("/api/products", new Product { Name = product.Name, CategoryId = product.CategoryId, ImageLink = product.ImageLink });
            response?.EnsureSuccessStatusCode();
        }

        public async Task UpdateProduct(int id, Product product)
        {
            var response = await httpClient.PutAsJsonAsync($"/api/products/{id}", product);
            response?.EnsureSuccessStatusCode();
        }

        public async Task DeleteProduct(int id)
        {
            var response = await httpClient.DeleteAsync($"/api/products/{id}");
            response?.EnsureSuccessStatusCode();
        }
    }
}
