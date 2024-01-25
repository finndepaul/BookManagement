using Book.Models.Dtos;
using Book.Models.Requests;

namespace Book.Blazor.IServices
{
    public interface IOrderDetailService
    {
        Task<List<OrderDetailDto>> GetAll(Guid OrderId);
        Task<OrderDetailDto> GetById(Guid OrderDetailId);
        Task<bool> CreateNew(OrderDetailCreateRequest request);
        Task<bool> Update(Guid OrderDetailId, OrderDetailUpdateRequest request);
        Task<bool> Delete(Guid OrderDetailId);
    }
}
