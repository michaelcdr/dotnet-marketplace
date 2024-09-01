using DotnetMarketplace.Core.Communication;
using DotnetMarketplace.Core.Exceptions;
using System.Text;
using System.Text.Json;

namespace DotnetMarketplace.Core.Services
{
    public abstract class ServiceBase
    {
        protected bool HandleResponseErrors(HttpResponseMessage response) 
        {
            switch ((int)response.StatusCode)
            {
                case 401:
                case 403:
                case 404:
                case 500:
                    throw new CustomHttpRequestException(response.StatusCode);

                case 400:
                    return false;
            }

            response.EnsureSuccessStatusCode();
            return true;
        }

        protected async Task<T> Deserialize<T>(HttpResponseMessage responseMessage)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<T>(await responseMessage.Content.ReadAsStringAsync(), options);
        }

        protected StringContent FormatContent(object data)
        {
            return new StringContent(
                JsonSerializer.Serialize(data),
                Encoding.UTF8,
                "application/json");
        }
    }
}
