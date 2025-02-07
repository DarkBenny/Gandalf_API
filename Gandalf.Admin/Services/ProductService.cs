using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gandalf.Admin.Models;

namespace Gandalf.Admin.Services
{
    public class ProductService
    {
        private readonly HttpClient httpClient;

        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Product>?> GetProducts()
        {
            return await httpClient.GetFromJsonAsync<List<Product>>("/api/products");
        }

        public async Task<Product?> GetProduct(int id)
        {
            return await httpClient.GetFromJsonAsync<Product?>($"/api/products/{id}");
        }

        public async Task CreateProduct(Product product)
        {
            var response = await httpClient.PostAsJsonAsync("/api/products", new Product { Name = product.Name, CategoryId = product.CategoryId, ImageLink = product.ImageLink, CategoryName = product.CategoryName});
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
