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
        public async Task<IEnumerable<ServiceDto>> GetServices()
        {
            return await _mediator.Send(new GetAvailableServicesQuery());
        }

        [HttpPost("{accountId}")]
        public async Task<IActionResult> OrderService(int accountId, [FromBody] AccountLicenseDto accountLicenseDto)
        {
            try
            {
                await _mediator.Send(new CreateAccountLicenseCommand(accountId, accountLicenseDto));
                return NoContent();
            }
            catch (Exception ex) 
            {   
                return BadRequest(ex.Message);
            }          
        }
    }
}
