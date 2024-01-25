using Book.Api.Entities;

namespace Book.Api.IRepositories
{
    public interface IOrderDetailRepos
    {
        public Task<List<OrderDetail>> GetAll(Guid orderId);
        public Task<OrderDetail> GetById(Guid orderDetailId);
        public Task<OrderDetail> CreateNew(OrderDetail orderDetai);
        public Task<OrderDetail> Update(OrderDetail orderDetai);
        public Task<OrderDetail> Delete(OrderDetail orderDetai);
        
    }
}
