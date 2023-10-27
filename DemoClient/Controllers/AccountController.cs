using DemoClient.Models;
using DemoClient.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoClient.Controllers
{
    public class AccountController : Controller
    {
        IAccountService service;

        public AccountController(IAccountService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            AccountDto? acc = await service.Login(email, password);
            if (acc != null && acc.Role == 1)
            {
                return RedirectToAction("FindAll");
            }
            if(acc != null && acc.Role == 0)
            {
                return RedirectToAction("AccountDetail", new {mailName = email});
            }
            return View();
        }


        public async Task<IActionResult> FindAll()
        {
            var acc = await service.FindAll();
            return View(acc);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AccountDto dto)
        {
            if (ModelState.IsValid)
            {
                await service.Create(dto);
                return RedirectToAction("FindAll");
            }
            return View(dto);
        }

        /*public async Task<IActionResult> AccountDetail(string mailName)
        {
            var acc = await service.FindAll(mailName);

        }*/
    }
}
