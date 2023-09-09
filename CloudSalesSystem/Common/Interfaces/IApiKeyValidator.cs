namespace CloudSalesSystem.Common.Interfaces
{
    public interface IApiKeyValidator
    {
        bool IsApiKeyValid(string apiKey);
    }
}
