using CloudSalesSystem.Commands;
using CloudSalesSystem.Common.Interfaces;
using CloudSalesSystem.Models;
using MediatR;
using Serilog;

namespace CloudSalesSystem.Handlers
{
    public class CreateAccountLicenseHandler : IRequestHandler<CreateAccountLicenseCommand>
    {
        private readonly ICloudComputingProviderService _cloudComputingProviderService;
        private readonly ApplicationDbContext _context;

        public CreateAccountLicenseHandler(ICloudComputingProviderService cloudComputingProviderService, ApplicationDbContext context)
        {
            _cloudComputingProviderService = cloudComputingProviderService;
            _context = context;
        }

        public async Task Handle(CreateAccountLicenseCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var services = await _cloudComputingProviderService.GetServices();
                var selectedService = services.Where(service => service.Id.Equals(command.LicenseId)).FirstOrDefault();
                if (selectedService is null)
                {
                    Log.Warning($"Customer tried to purchase license for the software ${command.Name} with license id ${command.LicenseId} which is not included in the list of the available services.");
                    throw new ArgumentException("The software license you have selected is unavailable for purchasing right now.");
                }

                if (selectedService.MaxQuantity != null && selectedService.MaxQuantity < command.Quantity)
                {
                    Log.Warning($"Customer tried to purchase ${command.Quantity} licenses for the software ${command.Name} with license id ${command.LicenseId} which is over the maximum amount of ${selectedService.MaxQuantity}.");
                    throw new ArgumentException("You have exceeded the maximum amount of licenses for the selected software.");
                }

                var existingService = _context.AccountLicenses.Where(license => license.LicenseId.Equals(command.LicenseId) && license.AccountId == command.AccountId).FirstOrDefault();
                if (existingService != null) 
                {
                    Log.Warning($"Customer tried to purchase ${command.Quantity} licenses for the software ${command.Name} with license id ${command.LicenseId} which he already owns.");
                    throw new ArgumentException("You have already purchased this software license for this account. You can modify the existing license via another action.");
                }

                _context.AccountLicenses.Add(new AccountLicense() { AccountId = command.AccountId, Quantity = command.Quantity, LicenseId = command.LicenseId, ExpirationDate = command.ExpirationDate, Name = selectedService.Name });
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
 