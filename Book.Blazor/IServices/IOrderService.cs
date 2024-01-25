using Book.Models.Dtos;
using Book.Models.Requests;

namespace Book.Blazor.IServices
{
    public interface IOrderService
    {
        Task<List<OrderDto>> GetAll();
        Task<OrderDto> GetById(Guid OrderId);
        Task<bool> CreateNew(OrderCreateRequest request);
        Task<bool> Update(Guid OrderId, OrderUpdateRequest request);
        Task<bool> Delete(Guid OrderId);
    }
}
