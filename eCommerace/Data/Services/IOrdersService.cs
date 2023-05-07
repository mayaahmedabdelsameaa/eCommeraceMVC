using eCommerace.Models;

namespace eCommerace.Data.Services
{
    public interface IOrdersService
    {
        Task StoreOrder(List<ShoppingCartItem> items, string userId, string userEmailAddress);
        Task<List<Order>> GetOrdersByUserIdAndRole(string userId, string userRole);
    }
}
