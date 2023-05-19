namespace RestaurantOrderApp.Application.QuerySide.Queries.Order.GetOrders
{
    public record GetOrdersQuery(Guid? Id = null) : IQuery<IList<Domain.Entities.Order>>;
}
