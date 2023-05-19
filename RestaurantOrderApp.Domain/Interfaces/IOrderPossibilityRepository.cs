using RestaurantOrderApp.Domain.Entities;

namespace RestaurantOrderApp.Domain.Interfaces
{
    public interface IOrderPossibilityRepository
    {
        Task<IList<OrderPossibility>> ListAsync(string timeOfDayName = null);
    }
}
