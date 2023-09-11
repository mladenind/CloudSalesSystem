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
            CreateMap<AccountLicense, AccountLicenseDto>()
                .ForMember(license => license.ExpirationDate, opt => {
                    opt.PreCondition(src => src.ExpirationDate.HasValue);
                    opt.MapFrom(src => DateOnly.FromDateTime((DateTime)src.ExpirationDate!));
                });
        }
    }
}
