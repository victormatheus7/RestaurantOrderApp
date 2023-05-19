namespace RestaurantOrderApp.Application.CommandSide.Command.Order.AddOrders
{
    public record AddOrdersCommand(Guid Id, string TimeOfDayName, IList<int> DishTypes) : ICommand;
}
