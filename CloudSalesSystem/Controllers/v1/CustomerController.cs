using CloudSalesSystem.Models.DTOs;
using CloudSalesSystem.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CloudSalesSystem.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CustomerController: BaseController
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Accounts")]
        public async Task<List<AccountDto>> GetAccounts()
        {
            return await _mediator.Send(new GetAccountsForCustomerIdQuery() { Id = CurrentCustomer.Id});
        }
    }
}
