using Book.Models.Dtos;
using Book.Models.Requests;

namespace Book.Blazor.IServices
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAll();
        Task<ProductDto> GetById(Guid productId);
        Task<bool> CreateNew(ProductCreateRequest request);
        Task<bool> Update(Guid productId, ProductUpdateRequest request);
        Task<bool> Delete(Guid productId);
    }
}
