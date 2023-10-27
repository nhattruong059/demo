using DemoAccountRole.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoAccountRole.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        AccountDbContext ctx;

        public AccountController(AccountDbContext ctx)
        {
            this.ctx = ctx;
        }

        [HttpPost]
        [Route("{email}/{password}")]
        public async Task<ActionResult<Account>> Login(string email, string password)
        {
            var acc = await ctx.Accounts!.SingleOrDefaultAsync(a=>a.Email == email && a.Password == password);
            if (acc != null)
            {
                return Ok(acc);
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<List<Account>>> FindAll()
        {
            return Ok(await ctx.Accounts!.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Create(Account acc)
        {
            ctx.Accounts!.Add(acc);
            return Ok(await ctx.SaveChangesAsync() > 0);
        }
    }
}
