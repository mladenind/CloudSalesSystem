﻿using CloudSalesSystem.Commands;
using CloudSalesSystem.Common.Interfaces;
using CloudSalesSystem.Models;
using MediatR;
using Serilog;

namespace CloudSalesSystem.Handlers
{
    public class CreateServiceForAccountIdHandler : IRequestHandler<CreateServiceForAccountIdCommand>
    {
        private readonly ICloudComputingProviderService _cloudComputingProviderService;
        private readonly ApplicationDbContext _context;

        public CreateServiceForAccountIdHandler(ICloudComputingProviderService cloudComputingProviderService, ApplicationDbContext context)
        {
            _cloudComputingProviderService = cloudComputingProviderService;
            _context = context;
        }

        public async Task Handle(CreateServiceForAccountIdCommand command, CancellationToken cancellationToken)
        {
            var services = await _cloudComputingProviderService.GetServices();
            var selectedService = services.Where(service => service.Id.Equals(command.LicenseId)).FirstOrDefault();
            if (selectedService is null)
            {
                Log.Warning($"Customer tried to purchase license for the software {command.Name} with license id {command.LicenseId} which is not included in the list of the available services.");
                throw new ArgumentException("The software license you have selected is unavailable for purchasing right now.");
            }

            if (selectedService.MaxQuantity != null && selectedService.MaxQuantity < command.Quantity)
            {
                Log.Warning($"Customer tried to purchase {command.Quantity} licenses for the software {command.Name} with license id {command.LicenseId} which is over the maximum amount of {selectedService.MaxQuantity}.");
                throw new ArgumentException("You have exceeded the maximum amount of licenses for the selected software.");
            }

            var existingService = _context.AccountLicenses.Where(license => license.LicenseId.Equals(command.LicenseId) && license.AccountId == command.AccountId && license.IsActive && (license.ExpirationDate == null || license.ExpirationDate > DateTime.UtcNow)).FirstOrDefault();
            if (existingService != null) 
            {
                Log.Warning($"Customer tried to purchase {command.Quantity} licenses for the software {command.Name} with license id {command.LicenseId} which he already owns.");
                throw new ArgumentException("You have already purchased this software license for this account. You can modify the existing license via another action.");
            }

            if (command.Quantity <= 0)
            {
                Log.Warning($"Customer tried to purchase an invalid amount of {command.Quantity} licenses for the software {command.Name} with license id {command.LicenseId}.");
                throw new ArgumentException("You cannot purchase an amount of licenses that is zero or lower");
            }

            _context.AccountLicenses.Add(new AccountLicense() { AccountId = command.AccountId, Quantity = command.Quantity, LicenseId = command.LicenseId, ExpirationDate = command.ExpirationDate.HasValue ? command.ExpirationDate.Value.ToDateTime(TimeOnly.MinValue) : null, Name = selectedService.Name });
            await _context.SaveChangesAsync(cancellationToken);
            return;
        }
    }
}
 