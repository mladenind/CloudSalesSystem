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
    }
}
