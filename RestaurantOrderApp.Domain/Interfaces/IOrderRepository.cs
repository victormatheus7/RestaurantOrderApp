using RestaurantOrderApp.Domain.Entities;

namespace RestaurantOrderApp.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task SaveOrders(IList<Order> orders);
    }
}
