using CloudSalesSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CloudSalesSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : BaseController
    {

        [HttpGet("accounts")]
        public async Task<List<Account>> GetAccounts()
        {
            using var db = new ApplicationDbContext();
            return await db.Accounts.ToListAsync();
        }
    }
}