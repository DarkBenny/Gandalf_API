using Gandalf.Admin.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gandalf.Admin.ViewComponents;

public class CategoryDropdownViewComponent : ViewComponent
{
    private readonly CategoryService service;

    public CategoryDropdownViewComponent(CategoryService service)
    {
        this.service = service;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var categories = await service.GetCategories();

        return View(categories);
    }
}
