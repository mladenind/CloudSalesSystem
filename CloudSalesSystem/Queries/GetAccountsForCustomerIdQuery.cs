using CloudSalesSystem.Models.DTOs;
using MediatR;

namespace CloudSalesSystem.Queries
{
    public class GetAccountsForCustomerIdQuery: IRequest<List<AccountDto>>
    {
        public int Id { get; set; }
    }
}
