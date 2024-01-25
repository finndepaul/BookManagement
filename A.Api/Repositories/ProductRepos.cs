using Book.Api.Context;
using Book.Api.Entities;
using Book.Api.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Book.Api.Repositories
{
    public class ProductRepos : IProductRepos
    {
        private readonly BookDbContext _context;

        public ProductRepos(BookDbContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetAll()
        {
            return await _context.Products
                .Include(x => x.Category)
                .ToListAsync();
        }
        public async Task<Product> GetById(Guid productId)
        {
            return await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.ProductId == productId);
        }
        public async Task<Product> CreateNew(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }
        public async Task<Product> Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
        public async Task<Product> Delete(Product product)
        {
            _context.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
