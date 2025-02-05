using Gandalf.Frontend.Models;
using Gandalf.Frontend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gandalf.Frontend.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductServiceFront service;

        public ProductsController(ProductServiceFront service)
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

        public async Task<ActionResult> ProductsByCategory(int id)
        {
            var products = await service.GetProducts();

            return View(products);
        }

    }
}
