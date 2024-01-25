using Book.Api.Entities;

namespace Book.Api.IRepositories
{
    public interface IProductRepos
    {
        public Task<List<Product>> GetAll();
        public Task<Product> GetById(Guid productId);
        public Task<Product> CreateNew(Product product);
        public Task<Product> Update(Product product);
        public Task<Product> Delete(Product product);
    }
}
