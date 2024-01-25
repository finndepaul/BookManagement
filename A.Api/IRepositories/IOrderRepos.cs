using Book.Api.Entities;

namespace Book.Api.IRepositories
{
    public interface IOrderRepos
    {
        public Task<List<Order>> GetAll();
        public Task<Order> GetById(Guid OrderId);
        public Task<Order> CreateNew(Order Order);
        public Task<Order> Update(Order Order);
        public Task<Order> Delete(Order Order);
    }
}
