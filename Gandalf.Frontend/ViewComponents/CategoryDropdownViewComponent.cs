﻿using Gandalf.Frontend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gandalf.Frontend.ViewComponents;

public class CategoryDropdownViewComponent : ViewComponent
{
    private readonly CategoryServiceFront service;

    public CategoryDropdownViewComponent(CategoryServiceFront service)
    {
        this.service = service;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var categories = await service.GetCategories();

        return View(categories);
    }
}
