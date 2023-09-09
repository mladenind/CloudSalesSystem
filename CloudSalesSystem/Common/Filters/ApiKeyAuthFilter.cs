using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using CloudSalesSystem.Common.Interfaces;
using CloudSalesSystem.Common.Utils;

namespace CloudSalesSystem.Common.Filters
{
    public class ApiKeyAuthFilter : IAuthorizationFilter
    {
        private readonly IApiKeyValidator _apiKeyValidator;
        public ApiKeyAuthFilter(IApiKeyValidator apiKeyValidator)
        {
            _apiKeyValidator = apiKeyValidator;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string userApiKey = context.HttpContext.Request.Headers[Constants.ApiKeyHeader].ToString();
            if (string.IsNullOrWhiteSpace(userApiKey))
            {
                context.Result = new BadRequestResult();
                return;
            }

            if (!_apiKeyValidator.IsApiKeyValid(userApiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }
    }
}
