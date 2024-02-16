using Book.Api.Entities;

namespace Book.Api.IRepositories
{
    public interface IUserRepos
    {
        Task<User> CreateNew(User user);
    }
}
