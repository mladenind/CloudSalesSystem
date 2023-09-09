using AutoMapper;
using CloudSalesSystem.Common.Interfaces;
using CloudSalesSystem.Models;
using CloudSalesSystem.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CloudSalesSystem.Controllers.v1
{
    public class ServicesController: BaseController
    {
        private readonly IMapper _mapper;
        private readonly ICloudComputingProviderService _cloudComputingProviderService;
        public ServicesController(IMapper mapper, ICloudComputingProviderService cloudComputingProviderService)
        {
            _mapper = mapper;
            _cloudComputingProviderService = cloudComputingProviderService;
        }

        [HttpGet("")]
        public async Task<IEnumerable<ServiceDto>> GetServices()
        {
            var services = await _cloudComputingProviderService.GetServices();
            return _mapper.Map<List<Service>, List<ServiceDto>>(services);
        }
    }
}
