﻿using Gandalf.Frontend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gandalf.Frontend.ViewComponents;

public class ProductDropdownViewComponent : ViewComponent
{
    private readonly ProductService service;

    public ProductDropdownViewComponent(ProductService service)
    {
        this.service = service;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var products = await service.GetProducts();

        return View(products);
    }
}
