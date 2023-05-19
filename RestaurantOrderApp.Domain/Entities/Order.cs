namespace RestaurantOrderApp.Domain.Entities
{
    public class Order : BaseEntity
    {
        public static IList<Order> CreateOrders(IEnumerable<OrderPossibility> orderPossibilities, Guid id, int timeOfDayId, IList<int> dishTypes)
        {
            var orders = new List<Order>();

            for(int i = 0; i < dishTypes.Count; i++)
            {
                var orderPossibility = orderPossibilities.FirstOrDefault(op => 
                    op.TimeOfDay.Id == timeOfDayId && op.DishType.Id == dishTypes[i]);

                var order = new Order(id, i, timeOfDayId, dishTypes[i], orderPossibility?.Dish.Id);
                orders.Add(order);
            }

            return orders;
        }

        public Order(Guid id, int sequence, int timeOfDayId, int dishTypeId, int? dishId)
        {
            Id = id;
            Sequence = sequence;
            TimeOfDayId = timeOfDayId;
            DishTypeId = dishTypeId;
            DishId = dishId;
        }

        public Guid Id { get; }

        public int Sequence { get; }

        public int TimeOfDayId { get; }
        public TimeOfDay TimeOfDay { get; private set; }

        public int DishTypeId { get; }
        public DishType DishType { get; private set; }

        public int? DishId { get; }
        public Dish Dish { get; private set; }
    }
}
