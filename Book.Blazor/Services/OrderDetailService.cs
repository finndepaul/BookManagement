using Book.Blazor.IServices;
using Book.Models.Dtos;
using Book.Models.Requests;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace Book.Blazor.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        public HttpClient _http;

        public OrderDetailService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<OrderDetailDto>> GetAll(Guid OrderId)
        {
            return await _http.GetFromJsonAsync<List<OrderDetailDto>>($"/OrderId?OrderId={OrderId}");
        }
        public async Task<OrderDetailDto> GetById(Guid OrderDetailId)
        {
            return await _http.GetFromJsonAsync<OrderDetailDto>($"/api/OrderDetails/{OrderDetailId}");
        }
        public async Task<bool> CreateNew(OrderDetailCreateRequest request)
        {
            var result = await _http.PostAsJsonAsync("/api/OrderDetails", request);
            return result.IsSuccessStatusCode;
        }
        public async Task<bool> Update(Guid OrderDetailId, OrderDetailUpdateRequest request)
        {
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var result = await _http.PatchAsync($"/api/OrderDetails/{OrderDetailId}", content);
            return result.IsSuccessStatusCode;
        }
        public async Task<bool> Delete(Guid OrderDetailId)
        {
            var result = await _http.DeleteAsync($"/api/OrderDetails/{OrderDetailId}");
            return result.IsSuccessStatusCode;
        }
        
    }
}
