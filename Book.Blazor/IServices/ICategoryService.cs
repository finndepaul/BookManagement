using Book.Models.Dtos;
using Book.Models.Requests;

namespace Book.Blazor.IServices
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAll();
        Task<CategoryDto> GetById(Guid categoryId);
        Task<bool> CreateNew(CategoryCreateRequest request);
        Task<bool> Update(Guid categoryId, CategoryUpdateRequest product);
        Task<bool> Delete(Guid categoryId);


    }
}
