using Gandalf.Admin.Models;
using Gandalf.Admin.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gandalf.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService service;

        public ProductsController(ProductService service)
        {
            this.service = service;
        }

        // GET: ProductController
        public async Task<ActionResult> Index()
        {
            var products = await service.GetProducts();

            return View(products);
        }

        // GET: ProductsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var product = await service.GetProduct(id);

            if (product == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await service.CreateProduct(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: CProductsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var product = await service.GetProduct(id);

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
                await service.UpdateProduct(id, product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: ProductsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var product = await service.GetProduct(id);

            return View(product);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            await service.DeleteProduct(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
