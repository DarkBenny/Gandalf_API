using Gandalf.Admin.Models;
using Gandalf.Admin.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Gandalf.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService productService;
        private readonly CategoryService categoryService;

        public ProductsController(ProductService productService, CategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        // GET: ProductController
        public async Task<ActionResult> Index()
        {
            var products = await productService.GetProducts();

            return View(products);
        }

        // GET: ProductsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var product = await productService.GetProduct(id);

            if (product == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {

            ViewBag.CategoriesList = categoryService.GetCategories();

            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await productService.CreateProduct(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: CProductsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var product = await productService.GetProduct(id);

            if (product == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Product product)
        {
            if (ModelState.IsValid)
            {
                await productService.UpdateProduct(id, product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: ProductsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var product = await productService.GetProduct(id);

            return View(product);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            await productService.DeleteProduct(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
