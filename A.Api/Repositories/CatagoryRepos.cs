using Book.Api.Context;
using Book.Api.Entities;
using Book.Api.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Book.Api.Repositories
{
    public class CatagoryRepos : ICatagoryRepos
    {
        private readonly BookDbContext _context;

        public CatagoryRepos(BookDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAll()
        {
            var category = await _context.Categories
                .ToListAsync();

            return category;
        }

        public async Task<Category> GetById(Guid categoryId)
        {
            return await _context.Categories.FindAsync(categoryId);
        }
        public async Task<Category> CreateNew(Category category)
        {
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }
        public async Task<Category> Update(Category category)
        {
            _context.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }
        public async Task<Category> Delete(Category category)
        {
            _context.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
