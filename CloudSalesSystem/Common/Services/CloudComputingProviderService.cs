using CloudSalesSystem.Common.Interfaces;
using CloudSalesSystem.Models;

namespace CloudSalesSystem.Common.Services
{
    public class CloudComputingProviderService: ICloudComputingProviderService
    {
        private readonly List<Service> serviceList = new List<Service>()
        {
            new Service()
            {
                Name = "Microsoft Office",
                Description = "Microsoft Office Package",
                MaxQuantity = 99,
                Id = "9796266c-2b5c-47ed-b2d5-ebccc6e19d57"
            },
            new Service()
            {
                Name = "McAfee Total Protection",
                Description = "Antivirus Software",
                MaxQuantity = 99,
                Id = "7942c045-7ec9-42fb-816f-aefa5ef0b0c8"
            },
            new Service()
            {
                Name = "Adobe Photoshop 2023",
                Description = "Graphic Designer Tool",
                Id = "971418a5-f33e-4be7-9026-d4689f5df5ea"
            },
            new Service()
            {
                Name = "WinRAR",
                Description = "Zipping tool. Has anyone ever bought this?",
                Id = "f8fc8ab5-8046-472b-9b14-b0d329a3279e"
            },
            new Service()
            {
                Name = "AutoCAD",
                Description = "For engineers",
                MaxQuantity = 9,
                Id = "4369572b-b0d3-4576-861d-432d784387a6"
            }
        };

        public async Task<List<Service>> GetServices()
        {
            await Task.Delay(500);
            return serviceList;
        }
    }
}
