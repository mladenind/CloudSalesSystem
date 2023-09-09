using CloudSalesSystem.Common.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CloudSalesSystem.Common.Attributes
{
    public class ApiKeyAttribute : ServiceFilterAttribute
    {
        public ApiKeyAttribute()
        : base(typeof(ApiKeyAuthFilter))
        {
        }
    }
}
