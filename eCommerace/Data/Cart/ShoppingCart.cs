using eCommerace.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerace.Data.Cart
{
    public class ShoppingCart
    {
        public AppDBContext _context { get; set; }

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(AppDBContext context)
        {
            _context = context;
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }


        public void AddItemToCart(Movie movie)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(s => s.Movie.Id == movie.Id && s.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Movie = movie,
                    Amount = 1
                };
                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _context.SaveChanges();
        }

        public void RemoveItemFromCart(Movie movie)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(s => s.Movie.Id == movie.Id && s.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            _context.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems
                .Where(n => n.ShoppingCartId == ShoppingCartId)
                .Include(n => n.Movie).ToList());
        }

        public double GetShoppingCartTotal() => _context.ShoppingCartItems .Where(s => s.ShoppingCartId == ShoppingCartId) .Select(m => m.Movie.Price * m.Amount).Sum();

        public async Task ClearShoppingCart()
        {
            var items = _context.ShoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId).ToList();
            _context.ShoppingCartItems.RemoveRange(items);
            await _context.SaveChangesAsync();

            ShoppingCartItems = new List<ShoppingCartItem>();
        }

    }
}
