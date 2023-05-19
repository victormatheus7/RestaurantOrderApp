using RestaurantOrderApp.Domain.Entities;

namespace RestaurantOrderApp.Domain.Interfaces
{
    public interface IOrderPossibilityRepository
    {
        Task<List<OrderPossibility>> ListAllAsync(string timeOfDayName = null);
    }
}
