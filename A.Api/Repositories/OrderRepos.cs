using Book.Api.Context;
using Book.Api.Entities;
using Book.Api.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Book.Api.Repositories
{
    public class OrderRepos : IOrderRepos
    {
        public BookDbContext _db;

        public OrderRepos(BookDbContext db)
        {
            _db = db;
        }

        public async Task<List<Order>> GetAll()
        {
            return await _db.Orders
                //.Include(x => x.User)
                .ToListAsync();
            
        }

        public async Task<Order> GetById(Guid OrderId)
        {
            return await _db.Orders
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.OrderId == OrderId);
        }

        public async Task<Order> CreateNew(Order Order)
        {
            await _db.Orders.AddAsync(Order);
            await _db.SaveChangesAsync();
            return Order;
        }
        public async Task<Order> Update(Order Order)
        {
            _db.Orders.Update(Order);
            await _db.SaveChangesAsync();
            return Order;
        }

        public async Task<Order> Delete(Order Order)
        {
            _db.Orders.Update(Order);
            await _db.SaveChangesAsync();
            return Order;
        }
    }
}
