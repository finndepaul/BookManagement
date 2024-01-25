using Book.Blazor.IServices;
using Book.Models.Dtos;
using Book.Models.Requests;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace Book.Blazor.Services
{
    public class OrderService : IOrderService
    {
        public HttpClient _http;

        public OrderService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<OrderDto>> GetAll()
        {
            return await _http.GetFromJsonAsync<List<OrderDto>>("/api/Orders");
        }

        public async Task<OrderDto> GetById(Guid OrderId)
        {
            return await _http.GetFromJsonAsync<OrderDto>($"/api/Orders/{OrderId}");
        }

        public async Task<bool> CreateNew(OrderCreateRequest request)
        {
            var result = await _http.PostAsJsonAsync("/api/Orders", request);
            return result.IsSuccessStatusCode;
        }
        public async Task<bool> Update(Guid OrderId, OrderUpdateRequest request)
        {
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var result = await _http.PatchAsync($"/api/Orders/{OrderId}", content);
            return result.IsSuccessStatusCode;
        }
        public async Task<bool> Delete(Guid OrderId)
        {
            var result = await _http.DeleteAsync($"/api/Orders/{OrderId}");
            return result.IsSuccessStatusCode;
        }

        
    }
}
