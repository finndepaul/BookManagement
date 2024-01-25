using Book.Api.Entities;

namespace Book.Api.IRepositories
{
    public interface ICatagoryRepos
    {
        public Task<List<Category>> GetAll();
        public Task<Category> GetById(Guid categoryId);
        public Task<Category> CreateNew(Category category);
        public Task<Category> Update(Category category);
        public Task<Category> Delete(Category category);
    }
}
