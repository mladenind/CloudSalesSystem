using MediatR;

namespace CloudSalesSystem.Commands
{
    public class CancelServiceForAccountIdAndLicenseIdCommand : IRequest
    {
        public int AccountId { get; set; }
        public string LicenseId { get; set; } = string.Empty;
    }
}
