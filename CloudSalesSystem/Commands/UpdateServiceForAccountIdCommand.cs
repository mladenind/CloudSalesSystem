using CloudSalesSystem.Models.DTOs;
using MediatR;

namespace CloudSalesSystem.Commands
{
    public class UpdateServiceForAccountIdCommand : IRequest
    {
        public UpdateServiceForAccountIdCommand(int accountId, AccountLicenseDto accountLicenseDto)
        {
            AccountId = accountId;
            LicenseId = accountLicenseDto.LicenseId;
            Name = accountLicenseDto.Name;
            Quantity = accountLicenseDto.Quantity;
            ExpirationDate = accountLicenseDto.ExpirationDate;
        }

        public int AccountId { get; set; }
        public string LicenseId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public DateTime? ExpirationDate { get; set; }   
    }
}
