using CloudSalesSystem.Commands;
using CloudSalesSystem.Models.DTOs;
using CloudSalesSystem.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CloudSalesSystem.Controllers.v1
{
    public class ServicesController: BaseController
    {
        private readonly IMediator _mediator;
        public ServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetServices()
        {
            return Ok(await _mediator.Send(new GetAvailableServicesQuery()));
        }

        [HttpGet("{accountId}")]
        public async Task<IActionResult> GetServicesForAccount(int accountId)
        {
            return Ok(await _mediator.Send(new GetServicesForAccountIdQuery() { Id = accountId }));
        }

        [HttpPost("{accountId}")]
        public async Task<IActionResult> OrderServiceForAccount(int accountId, [FromBody] AccountLicenseDto accountLicenseDto)
        {
            try
            {
                await _mediator.Send(new CreateServiceForAccountIdCommand(accountId, accountLicenseDto));
                return NoContent();
            }
            catch (Exception ex) 
            {   
                return BadRequest(ex.Message);
            }          
        }

        [HttpPut("{accountId}")]
        public async Task<IActionResult> UpdateServiceForAccount(int accountId, [FromBody] AccountLicenseDto accountLicenseDto)
        {
            try
            {
                await _mediator.Send(new UpdateServiceForAccountIdCommand(accountId, accountLicenseDto));
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
