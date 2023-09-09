using AutoMapper;
using CloudSalesSystem.Models;
using CloudSalesSystem.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CloudSalesSystem.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly IMapper _mapper;
        public CustomerController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("Accounts")]
        public async Task<List<AccountDto>> GetAccounts()
        {
            using var db = new ApplicationDbContext();
            var accounts = await db.Accounts.Where(x => x.CustomerId == CurrentCustomer.Id).ToListAsync();
            return _mapper.Map<List<Account>, List<AccountDto>>(accounts);
        }
    }
}