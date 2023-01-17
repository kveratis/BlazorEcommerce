using System.Net.Http.Json;

namespace BlazorEcommerce.Services
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(UserRegister request);
    }

    public sealed class AuthService : IAuthService
    {
        private const string RegisterEndpoint = "/api/auth/register";

        private readonly HttpClient _http;

        public AuthService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ServiceResponse<int>> Register(UserRegister request)
        {
            var result = await _http.PostAsJsonAsync(RegisterEndpoint, request);

            return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
        }
    }
}
