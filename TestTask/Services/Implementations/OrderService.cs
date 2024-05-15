using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _db;

        public OrderService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Order> GetOrder()
        {
            return await _db.Orders.Where(o => o.Quantity > 1).OrderByDescending(o => o.CreatedAt).FirstAsync();
        }

        public async Task<List<Order>> GetOrders()
        {
            return await _db.Orders.Where(u => u.User.Status == UserStatus.Active)
                .OrderByDescending(o => o.CreatedAt).ToListAsync();
        }
    }
}
