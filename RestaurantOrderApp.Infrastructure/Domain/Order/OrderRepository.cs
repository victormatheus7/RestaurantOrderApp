using RestaurantOrderApp.Domain.Interfaces;
using RestaurantOrderApp.Infrastructure.Database;

namespace RestaurantOrderApp.Infrastructure.Domain.Order
{
    public class OrderRepository : IOrderRepository
    {
        private readonly RestaurantOrderAppContext _context;

        public OrderRepository(RestaurantOrderAppContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task SaveOrders(IList<RestaurantOrderApp.Domain.Entities.Order> orders)
        {
            _context.Orders.AddRange(orders);

            await _context.SaveChangesAsync();
        }
    }
}
