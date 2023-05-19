using Microsoft.EntityFrameworkCore;
using RestaurantOrderApp.Domain.Interfaces;
using RestaurantOrderApp.Infrastructure.Database;

namespace RestaurantOrderApp.Infrastructure.Domain.OrderPossibility
{
    public class OrderPossibilityRepository : IOrderPossibilityRepository
    {
        private readonly RestaurantOrderAppContext _context;

        public OrderPossibilityRepository(RestaurantOrderAppContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IList<RestaurantOrderApp.Domain.Entities.OrderPossibility>> ListAsync(string timeOfDayName)
        {
            var orderPossibilities = (
                from op in _context.OrderPossibilities
                join td in _context.TimesOfDay on op.TimeOfDayId equals td.Id
                join dt in _context.DishTypes on op.DishTypeId equals dt.Id
                join d in _context.Dishes on op.DishId equals d.Id
                where td.Name == timeOfDayName || timeOfDayName == null
                select new RestaurantOrderApp.Domain.Entities.OrderPossibility(td, dt, d)
            );

            return await orderPossibilities.ToListAsync();
        }
    }
}
