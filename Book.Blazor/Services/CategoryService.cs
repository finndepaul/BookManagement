using Book.Blazor.IServices;
using Book.Models.Dtos;
using Book.Models.Requests;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Book.Blazor.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _http;

        public CategoryService(HttpClient httpClient)
        {
            _http = httpClient;
        }
        public async Task<List<CategoryDto>> GetAll()
        {
            var result = await _http.GetFromJsonAsync<List<CategoryDto>>("/api/Categories");
            return result;
        }
        public async Task<CategoryDto> GetById(Guid categoryId)
        {
            var result = await _http.GetFromJsonAsync<CategoryDto>($"/api/Categories/{categoryId}");
            return result;
        }
        public async Task<bool> CreateNew(CategoryCreateRequest request)
        {
            var result = await _http.PostAsJsonAsync("/api/Categories", request);
            return result.IsSuccessStatusCode;
        }
        public async Task<bool> Update(Guid categoryId, CategoryUpdateRequest request)
        {
            //var result = await _http.PatchAsync($"/api/Categories/{categoryId}", request);
            //return result.IsSuccessStatusCode;
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var result = await _http.PatchAsync($"/api/Categories/{categoryId}", content);
            return result.IsSuccessStatusCode;
        }


        public async Task<bool> Delete(Guid categoryId)
        {
            var result = await _http.DeleteAsync($"/api/Categories/{categoryId}");
            return result.IsSuccessStatusCode;
        }




    }
}
