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
            return await _context.OrderPossibilities.ToListAsync();
        }
    }
}
