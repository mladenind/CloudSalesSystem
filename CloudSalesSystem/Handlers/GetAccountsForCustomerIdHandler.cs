using AutoMapper;
using CloudSalesSystem.Models;
using CloudSalesSystem.Models.DTOs;
using CloudSalesSystem.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CloudSalesSystem.Handlers
{
    public class GetAccountsForCustomerIdHandler: IRequestHandler<GetAccountsForCustomerIdQuery, List<AccountDto>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAccountsForCustomerIdHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<AccountDto>> Handle(GetAccountsForCustomerIdQuery query, CancellationToken cancellationToken)
        {
            var accounts = await _context.Accounts.Where(x => x.CustomerId == query.Id).ToListAsync();
            return _mapper.Map<List<Account>, List<AccountDto>>(accounts);
        }
    }
}
