using System.Collections;
using Gandalf.Frontend.Models;

namespace Gandalf.Frontend.Services;

public class CategoryServiceFront
{
    private readonly HttpClient httpClient;

    public CategoryServiceFront(HttpClient httpClient)
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

}
