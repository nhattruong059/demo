using Microsoft.AspNetCore.Mvc;
using ProductClient.Models;
using ProductClient.Services;

namespace ProductClient.Controllers
{
    public class ProdController : Controller
    {
        IProdService service;

        public ProdController(IProdService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            var prod = await service.FindAll();
            return View(prod);
        }

        public async Task<IActionResult> Search(string name)
        {
            var prod = await service.Search(name);
            return View("Index", prod);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDto dto)
        {
            if (ModelState.IsValid)
            {
                await service.Create(dto);
                return RedirectToAction("Index");
            }
            return View(dto);
        }
    }
}
