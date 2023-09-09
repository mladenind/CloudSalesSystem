using AutoMapper;
using CloudSalesSystem.Models;
using CloudSalesSystem.Models.DTOs;

namespace CloudSalesSystem.Common.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, AccountDto>();
            CreateMap<Service, ServiceDto>();
        }
    }
}
