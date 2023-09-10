using CloudSalesSystem.Models.DTOs;
using MediatR;

namespace CloudSalesSystem.Queries
{
    public class GetAvailableServicesQuery : IRequest<List<ServiceDto>>
    {

    }
}
