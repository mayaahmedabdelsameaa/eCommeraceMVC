using eCommerace.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerace.Data.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly AppDBContext _context;

        public OrdersService(AppDBContext context)
        {
            _context = context;
        }
        public async Task<List<Order>> GetOrdersByUserIdAndRole(string userId, string userRole)
        {
            var orders = await _context.Orders
                        .Include(i => i.OrderItems)
                        .ThenInclude(m => m.Movie)
                        .Include(u=>u.User)
                        .ToListAsync();
            if(userRole != "Admin")
            {
                orders = orders.Where(u => u.UserId == userId).ToList();
            }
            return orders;
        }

        public async Task StoreOrder(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            //store shopping cart items into database
            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    MovieId = item.Movie.Id,
                    OrderId = order.Id,
                    Price = item.Movie.Price
                };
                await _context.OrderItems.AddAsync(orderItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}
