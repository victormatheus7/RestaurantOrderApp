using RestaurantOrderApp.Domain.Entities;

namespace RestaurantOrderApp.API.Controllers.v1._0.Orders
{
    public record OrderViewModel(Guid Id, string TimeOfDayName, IList<int> DishTypesRequested, IList<string?> DishesDelivered)
    {
        public static IList<OrderViewModel> ToViewModel(IList<Order> orders)
        {
            return orders.GroupBy(o => o.Id)
                .Select(g => new OrderViewModel(
                    g.Key,
                    g.First().TimeOfDay.Name,
                    g.OrderBy(o => o.Sequence).Select(o => o.DishType.Id).ToList(),
                    g.OrderBy(o => o.DishType.Id).Select(o => o.Dish?.Name).ToList()
                )).ToList();
        }
    }
}
