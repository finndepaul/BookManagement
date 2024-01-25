using Book.Api.Context;
using Book.Api.Entities;
using Book.Api.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Book.Api.Repositories
{
    public class OrderDetailRepos : IOrderDetailRepos
    {
        public BookDbContext _db;

        public OrderDetailRepos(BookDbContext db)
        {
            _db = db;
        }

        public async Task<List<OrderDetail>> GetAll(Guid orderId)
        {
            var result = await _db.OrderDetails
                 .Include(x => x.Product)
                 .Include(x => x.Order)
                 .Where(x => x.OrderId == orderId)
                 .ToListAsync();              
            return result;
        }


        public async Task<OrderDetail> GetById(Guid orderDetailId)
        {
            var result = await _db.OrderDetails
                .Include(x => x.Product)
                .Include(x => x.Order)
                .FirstOrDefaultAsync(x => x.OrderDetailId == orderDetailId);
            return result;
        }
        public async Task<OrderDetail> CreateNew(OrderDetail orderDetai)
        {
            await _db.OrderDetails.AddAsync(orderDetai);
            await _db.SaveChangesAsync();
            return orderDetai;
        }

        public async Task<OrderDetail> Delete(OrderDetail orderDetai)
        {
            _db.Remove(orderDetai);
            await _db.SaveChangesAsync();
            return orderDetai;
        }
        public async Task<OrderDetail> Update(OrderDetail orderDetai)
        {
            _db.Update(orderDetai);
            await _db.SaveChangesAsync();
            return orderDetai;
        }
    }
}
