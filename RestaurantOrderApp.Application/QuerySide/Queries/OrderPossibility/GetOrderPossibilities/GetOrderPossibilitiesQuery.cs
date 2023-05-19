namespace RestaurantOrderApp.Application.QuerySide.Queries.OrderPossibility.GetOrderPossibilities
{
    public record GetOrderPossibilitiesQuery(string? TimeOfDayName = null) : IQuery<IList<Domain.Entities.OrderPossibility>>;
}
