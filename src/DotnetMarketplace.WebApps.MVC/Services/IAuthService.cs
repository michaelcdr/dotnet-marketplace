using DotnetMarketplace.WebApps.MVC.Models;
using System.Text;
using System.Text.Json;

namespace DotnetMarketplace.WebApps.MVC.Services
{
    public interface IAuthService
    {
        Task<string> Login(LoginModel loginModel);
    }
    
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _httpClient.BaseAddress = new Uri("https://localhost:7070/");
        }

        public async Task<string> Login(LoginModel loginModel)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(loginModel, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                }),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync("Auth/Login", content);

            string retorno = await response.Content.ReadAsStringAsync();

            return retorno;
        }
    }
}
