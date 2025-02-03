using System.Collections;
using Gandalf.Admin.Models;

namespace Gandalf.Admin.Services;

public class CategoryService
{
    private readonly HttpClient httpClient;

    public CategoryService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<IEnumerable<Category>?> GetCategories()
    {
        return await httpClient.GetFromJsonAsync<IEnumerable<Category>>("/api/categories");
    }

    public async Task<Category?> GetCategory(int id)
    {
        return await httpClient.GetFromJsonAsync<Category?>($"/api/categories/{id}");
    }

    public async Task CreateCategory(string name)
    {
        var response = await httpClient.PostAsJsonAsync("/api/categories", new Category { Name = name });
        response?.EnsureSuccessStatusCode();
    }

    public async Task UpdateCategory(int id, Category category)
    {
        var response = await httpClient.PutAsJsonAsync($"/api/categories/{id}", category);
        response?.EnsureSuccessStatusCode();
    }

    public async Task DeleteCategory(int id)
    {
        var response = await httpClient.DeleteAsync($"/api/categories/{id}");
        response?.EnsureSuccessStatusCode();
    }
}
