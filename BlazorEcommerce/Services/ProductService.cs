using System.Net.Http.Json;

namespace BlazorEcommerce.Services
{
    public interface IProductService
    {
        List<Product> Products { get; set; }

        Task GetProductsAsync();
        Task<ServiceResponse<Product>> GetProductAsync(int productId);
    }

    public sealed class ProductService : IProductService
    {
        private const string GetProductsEndpoint = "/api/product";

        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }

        public List<Product> Products { get; set; } = new List<Product>();

        public async Task GetProductsAsync()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>(GetProductsEndpoint);

            if (result?.Data is not null)
            {
                Products = result.Data;
            }
        }

        public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"{GetProductsEndpoint}/{productId}");

            return result;
        }
    }
}
