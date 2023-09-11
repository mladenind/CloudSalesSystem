using CloudSalesSystem.Models.DTOs;
using CloudSalesSystem.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CloudSalesSystem.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CustomersController: BaseController
    {
        private readonly IMediator _mediator;
        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Accounts")]
        public async Task<IActionResult> GetAccountsForCustomer()
        {
            return Ok(await _mediator.Send(new GetAccountsForCustomerIdQuery() { Id = CurrentCustomer.Id}));
        }
    }
}
