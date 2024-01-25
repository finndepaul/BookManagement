using Book.Blazor.IServices;
using Book.Models.Dtos;
using Book.Models.Requests;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace Book.Blazor.Services
{
    public class ProductService : IProductService
    {
        public HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<ProductDto>> GetAll()
        {
            return await _http.GetFromJsonAsync<List<ProductDto>>("/api/Products");
        }

        public async Task<ProductDto> GetById(Guid productId)
        {
            return await _http.GetFromJsonAsync<ProductDto>($"/api/Products/{productId}");
        }
        public async Task<bool> CreateNew(ProductCreateRequest request)
        {

            var result = await _http.PostAsJsonAsync("/api/Products", request);
            return result.IsSuccessStatusCode;
        }
        public async Task<bool> Update(Guid productId, ProductUpdateRequest request)
        {
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var result = await _http.PatchAsync($"/api/Products/{productId}", content);
            return result.IsSuccessStatusCode;
        }
        public async Task<bool> Delete(Guid productId)
        {
            var result = await _http.DeleteAsync($"/api/Products/{productId}");
            return result.IsSuccessStatusCode;
        }
    }
}
