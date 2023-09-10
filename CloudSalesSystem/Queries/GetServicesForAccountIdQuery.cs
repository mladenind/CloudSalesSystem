using CloudSalesSystem.Models.DTOs;
using MediatR;

namespace CloudSalesSystem.Queries
{
    public class GetServicesForAccountIdQuery : IRequest<List<AccountLicenseDto>>
    {
        public int Id { get; set; }
    }
}
