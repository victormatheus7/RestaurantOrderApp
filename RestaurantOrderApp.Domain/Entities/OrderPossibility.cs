namespace RestaurantOrderApp.Domain.Entities
{
    public class OrderPossibility : BaseEntity
    {
        public TimeOfDay TimeOfDay { get; set; }

        public DishType DishType { get; set; }

        public Dish Dish { get; set; }
    }
}
