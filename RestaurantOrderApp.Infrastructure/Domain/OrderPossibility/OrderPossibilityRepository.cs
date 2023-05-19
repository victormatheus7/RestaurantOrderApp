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

        public async Task<List<RestaurantOrderApp.Domain.Entities.OrderPossibility>> ListAllAsync()
        {
            var orderPossibilities = (
                from op in _context.OrderPossibilities
                join td in _context.TimesOfDay on op.TimeOfDayId equals td.Id
                join dt in _context.DishTypes on op.DishTypeId equals dt.Id
                join d in _context.Dishes on op.DishId equals d.Id
                select new RestaurantOrderApp.Domain.Entities.OrderPossibility(
                    new RestaurantOrderApp.Domain.Entities.TimeOfDay(td.Id, td.Name),
                    new RestaurantOrderApp.Domain.Entities.DishType(dt.Id, dt.Name),
                    new RestaurantOrderApp.Domain.Entities.Dish(d.Id, d.Name)
                )
            );

            return await orderPossibilities.ToListAsync();
        }
    }
}
