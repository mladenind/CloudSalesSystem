using AutoMapper;
using CloudSalesSystem.Common.Interfaces;
using CloudSalesSystem.Models;
using CloudSalesSystem.Models.DTOs;
using CloudSalesSystem.Queries;
using MediatR;

namespace CloudSalesSystem.Handlers
{
    public class GetAvailableServicesHandler : IRequestHandler<GetAvailableServicesQuery, List<ServiceDto>>
    {
        private readonly ICloudComputingProviderService _cloudComputingProviderService;
        private readonly IMapper _mapper;

        public GetAvailableServicesHandler(ICloudComputingProviderService cloudComputingProviderService, IMapper mapper)
        {
            _cloudComputingProviderService = cloudComputingProviderService;
            _mapper = mapper;
        }

        public async Task<List<ServiceDto>> Handle(GetAvailableServicesQuery query, CancellationToken cancellationToken)
        {
            var services = await _cloudComputingProviderService.GetServices();
            return _mapper.Map<List<Service>, List<ServiceDto>>(services);
        }
    }
}
