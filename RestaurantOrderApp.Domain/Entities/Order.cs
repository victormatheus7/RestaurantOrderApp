namespace RestaurantOrderApp.Domain.Entities
{
    public class Order : BaseEntity
    {
        public static IList<Order> CreateOrders(IEnumerable<OrderPossibility> orderPossibilities, Guid id, int timeOfDayId, IList<int> dishTypeIds)
        {
            var orders = new List<Order>();
            var dishIds = new HashSet<int>();

            for (int i = 0; i < dishTypeIds.Count; i++)
            {
                var orderPossibility = orderPossibilities.FirstOrDefault(op =>
                    op.TimeOfDay.Id == timeOfDayId && op.DishType.Id == dishTypeIds[i]);

                var dishId = orderPossibility?.Dish.Id;
                FilterDishId(timeOfDayId, dishIds, ref dishId);

                var order = new Order(id, i, timeOfDayId, dishTypeIds[i], dishId);
                orders.Add(order);
            }

            return orders;
        }

        private static void FilterDishId(int timeOfDayId, HashSet<int> dishIds, ref int? dishId)
        {
            if (dishId != null)
            {
                if (dishIds.Contains(dishId.Value))
                {
                    if (!ItCanHasMultiple(timeOfDayId, dishId.Value))
                        dishId = null;
                }
                else
                    dishIds.Add(dishId.Value);
            }
        }

        private static bool ItCanHasMultiple(int timeOfDayId, int dishId)
        {
            return (timeOfDayId == 0 && dishId == 2) || (timeOfDayId == 1 && dishId == 4);
        }

        public Order(Guid id, int sequence, int timeOfDayId, int dishTypeId, int? dishId)
        {
            Id = id;
            Sequence = sequence;
            TimeOfDayId = timeOfDayId;
            DishTypeId = dishTypeId;
            DishId = dishId;
        }

        public Order(Guid id, int sequence, TimeOfDay timeOfDay, DishType dishType, Dish dish, DateTime modifiedDate) : base(modifiedDate)
        {
            Id = id;
            Sequence = sequence;
            TimeOfDay = timeOfDay;
            DishType = dishType;
            Dish = dish;
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
