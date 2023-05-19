namespace RestaurantOrderApp.Domain.Entities
{
    public class OrderPossibility : BaseEntity
    {
        public OrderPossibility(TimeOfDay timeOfDay, DishType dishType, Dish dish)
        {
            TimeOfDay = timeOfDay;
            DishType = dishType;
            Dish = dish;
        }

        public OrderPossibility(int timeOfDayId, int dishTypeId, int dishId)
        {
            TimeOfDayId = timeOfDayId;
            DishTypeId = dishTypeId;
            DishId = dishId;
        }

        public int TimeOfDayId { get; }
        public TimeOfDay TimeOfDay { get; private set; }

        public int DishTypeId { get; }
        public DishType DishType { get; private set; }

        public int DishId { get; }
        public Dish Dish { get; private set; }
    }
}
