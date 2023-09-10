using AutoMapper;
using CloudSalesSystem.Models.DTOs;
using CloudSalesSystem.Models;
using CloudSalesSystem.Queries;
using Microsoft.EntityFrameworkCore;
using MediatR;
 
namespace CloudSalesSystem.Handlers
{
    public class GetServicesForAccountIdHandler : IRequestHandler<GetServicesForAccountIdQuery, List<AccountLicenseDto>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetServicesForAccountIdHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<AccountLicenseDto>> Handle(GetServicesForAccountIdQuery query, CancellationToken cancellationToken)
        {
            var accountLicenses = await _context.AccountLicenses.Where(license => license.AccountId == query.Id && license.IsLicenseActive()).ToListAsync();
            return _mapper.Map<List<AccountLicense>, List<AccountLicenseDto>>(accountLicenses);
        }
    }
}
