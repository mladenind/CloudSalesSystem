using CloudSalesSystem.Commands;
using CloudSalesSystem.Common.Interfaces;
using CloudSalesSystem.Models;
using MediatR;
using Serilog;

namespace CloudSalesSystem.Handlers
{
    public class UpdateServiceForAccountIdHandler : IRequestHandler<UpdateServiceForAccountIdCommand>
    {
        private readonly ICloudComputingProviderService _cloudComputingProviderService;
        private readonly ApplicationDbContext _context;

        public UpdateServiceForAccountIdHandler(ICloudComputingProviderService cloudComputingProviderService, ApplicationDbContext context)
        {
            _cloudComputingProviderService = cloudComputingProviderService;
            _context = context;
        }

        public async Task Handle(UpdateServiceForAccountIdCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var services = await _cloudComputingProviderService.GetServices();
                var selectedService = services.Where(service => service.Id.Equals(command.LicenseId)).FirstOrDefault();
                if (selectedService is null)
                {
                    Log.Warning($"Customer tried to update the license for the software {command.Name} with license id {command.LicenseId} which is not included in the list of the available services.");
                    throw new ArgumentException("The software license you have selected is unavailable for updating right now.");
                }

                if (selectedService.MaxQuantity != null && selectedService.MaxQuantity < command.Quantity)
                {
                    Log.Warning($"Customer tried to update ${command.Quantity} licenses for the software {command.Name} with license id {command.LicenseId} which is over the maximum amount of {selectedService.MaxQuantity}.");
                    throw new ArgumentException("You have exceeded the maximum amount of licenses for the selected software.");
                }

                var existingService = _context.AccountLicenses.Where(license => license.LicenseId.Equals(command.LicenseId) && license.AccountId == command.AccountId && license.IsActive && (license.ExpirationDate == null || license.ExpirationDate > DateTime.UtcNow)).FirstOrDefault();
                if (existingService is null) 
                {
                    Log.Warning($"Customer tried to update software {command.Name} with license id {command.LicenseId} which he doesn't own.");
                    throw new ArgumentException("You cannot modify software that you don't already own. Please try purchasing it first.");
                }

                if (command.ExpirationDate != null && existingService.ExpirationDate != null && command.ExpirationDate.Value.ToDateTime(TimeOnly.MinValue) < existingService.ExpirationDate)
                {
                    Log.Warning($"Customer tried to extend software {command.Name} with license id {command.LicenseId} to a prior date.");
                    throw new ArgumentException("You can only extend the software license.");
                }

                existingService.ExpirationDate = command.ExpirationDate.HasValue ? command.ExpirationDate.Value.ToDateTime(TimeOnly.MinValue) : null;
                existingService.Quantity = command.Quantity;
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
 