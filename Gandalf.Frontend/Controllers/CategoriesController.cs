using Gandalf.Frontend.Models;
using Gandalf.Frontend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gandalf.Frontend.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CategoryServiceFront service;

        public CategoriesController(CategoryServiceFront service)
        {
            this.service = service;
        }

        // GET: CategoriesController
        public async Task<ActionResult> Index()
        {
            var categories = await service.GetCategories();

            return View(categories);
        }

        // GET: CategoriesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var category = await service.GetCategory(id);

            if (category == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

    }
}
