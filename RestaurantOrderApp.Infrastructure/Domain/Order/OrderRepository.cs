using Microsoft.EntityFrameworkCore;
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

        public async Task SaveAsync(IList<RestaurantOrderApp.Domain.Entities.Order> orders)
        {
            _context.Orders.AddRange(orders);

            await _context.SaveChangesAsync();
        }

        public async Task<IList<RestaurantOrderApp.Domain.Entities.Order>> ListAsync(Guid? id = null)
        {
            var orders = (
                from o in _context.Orders
                join d in _context.Dishes on o.DishId equals d.Id into lj
                from subd in lj.DefaultIfEmpty() 
                where o.Id == id || id == null
                select new RestaurantOrderApp.Domain.Entities.Order(
                    o.Id, 
                    o.Sequence, 
                    null,
                    new RestaurantOrderApp.Domain.Entities.DishType(o.DishTypeId, null), 
                    subd
                )
            );

            return await orders.ToListAsync();
        }
    }
}
