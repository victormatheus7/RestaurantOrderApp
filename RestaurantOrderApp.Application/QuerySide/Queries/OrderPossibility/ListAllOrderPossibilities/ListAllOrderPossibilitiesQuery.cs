namespace RestaurantOrderApp.Application.QuerySide.Queries.OrderPossibility.ListAllOrderPossibilities
{
    public record ListAllOrderPossibilitiesQuery(string? TimeOfDayName = null) : IQuery<List<Domain.Entities.OrderPossibility>>;
}
