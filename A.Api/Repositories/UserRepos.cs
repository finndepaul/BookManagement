using Book.Api.Context;
using Book.Api.Entities;
using Book.Api.IRepositories;

namespace Book.Api.Repositories
{
    public class UserRepos : IUserRepos
    {
        private readonly BookDbContext _db;

        public UserRepos(BookDbContext db)
        {
            _db = db;
        }

        public async Task<User> CreateNew(User user)
        {
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return user;
        }
    }
}
