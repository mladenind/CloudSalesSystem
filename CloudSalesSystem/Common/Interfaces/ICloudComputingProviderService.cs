using CloudSalesSystem.Models;

namespace CloudSalesSystem.Common.Interfaces
{
    public interface ICloudComputingProviderService
    {
        public Task<List<Service>> GetServices();
    }
}
