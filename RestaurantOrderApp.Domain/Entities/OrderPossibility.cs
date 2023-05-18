namespace RestaurantOrderApp.Domain.Entities
{
    public class OrderPossibility : BaseEntity
    {
        public int TimeOfDayId { get; set; }
        public TimeOfDay TimeOfDay { get; set; }

        public int DishTypeId { get; set; }
        public DishType DishType { get; set; }

        public int DishId { get; set; }
        public Dish Dish { get; set; }
    }
}
