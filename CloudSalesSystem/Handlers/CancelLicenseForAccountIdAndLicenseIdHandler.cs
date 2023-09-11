using CloudSalesSystem.Commands;
using CloudSalesSystem.Common.Interfaces;
using CloudSalesSystem.Models;
using MediatR;
using Serilog;

namespace CloudSalesSystem.Handlers
{
    public class CancelLicenseForAccountIdAndLicenseIdHandler : IRequestHandler<CancelServiceForAccountIdAndLicenseIdCommand>
    {
        private readonly ICloudComputingProviderService _cloudComputingProviderService;
        private readonly ApplicationDbContext _context;

        public CancelLicenseForAccountIdAndLicenseIdHandler(ICloudComputingProviderService cloudComputingProviderService, ApplicationDbContext context)
        {
            _cloudComputingProviderService = cloudComputingProviderService;
            _context = context;
        }

        public async Task Handle(CancelServiceForAccountIdAndLicenseIdCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var services = await _cloudComputingProviderService.GetServices();
                var selectedService = services.Where(service => service.Id.Equals(command.LicenseId)).FirstOrDefault();
                if (selectedService is null)
                {
                    Log.Warning($"Customer tried to cancel the license with Id {command.LicenseId} which is not included in the list of the available services.");
                    throw new ArgumentException("The software license you have selected is unavailable for cancellation right now.");
                }

                var existingService = _context.AccountLicenses.Where(license => license.LicenseId.Equals(command.LicenseId) && license.AccountId == command.AccountId && license.IsActive && (license.ExpirationDate == null || license.ExpirationDate > DateTime.UtcNow)).FirstOrDefault();
                if (existingService is null)
                {
                    Log.Warning($"Customer tried to cancel the license with Id {command.LicenseId} which he doesn't own.");
                    throw new ArgumentException("You cannot cancel software that you don't already own. Please try purchasing it first.");
                }

                existingService.IsActive = false;
                existingService.ExpirationDate = DateTime.UtcNow;
                existingService.UpdatedDate = DateTime.UtcNow;

                await _context.SaveChangesAsync(cancellationToken);
                return;
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw new Exception("Technical Error. Please try again.");
            }
        }
    }
}
