using RestaurantOrderApp.Domain.Entities;

namespace RestaurantOrderApp.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task SaveAsync(IList<Order> orders);

        Task<IList<Order>> ListAsync(Guid? id = null);
    }
}
