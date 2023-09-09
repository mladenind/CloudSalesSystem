using CloudSalesSystem.Common.Interfaces;

namespace CloudSalesSystem.Common.Utils
{
    public class ApiKeyValidator: IApiKeyValidator
    {
        private readonly IConfiguration _configuration;

        public ApiKeyValidator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool IsApiKeyValid(string userApiKey)
        {
            if (string.IsNullOrWhiteSpace(userApiKey))
            {
                return false;
            }

            var apiKey = _configuration.GetValue<string>(Constants.ApiKeyName);
            if (apiKey is null || apiKey != userApiKey)
            {
                return false;
            }
                
            return true;
        }
    }
}
