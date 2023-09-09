using AutoMapper;
using CloudSalesSystem.Models;
using CloudSalesSystem.Models.DTOs;

namespace CloudSalesSystem.Common.Utils
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Account, AccountDto>();
        }
    }
}
