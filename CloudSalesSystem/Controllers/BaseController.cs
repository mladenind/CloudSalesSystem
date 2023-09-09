using CloudSalesSystem.Common.Attributes;
using CloudSalesSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloudSalesSystem.Controllers
{
    [ApiKey]
    public class BaseController: ControllerBase
    {
        public Customer CurrentCustomer
        {
            get
            {
                var db = new ApplicationDbContext();
                return db.Customers.Where(x => x.Name.Equals("Main User")).First();
            }
        }
    }
}
