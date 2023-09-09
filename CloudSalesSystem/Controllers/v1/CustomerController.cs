using AutoMapper;
using CloudSalesSystem.Models.DTOs;
using CloudSalesSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CloudSalesSystem.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CustomerController: BaseController
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
