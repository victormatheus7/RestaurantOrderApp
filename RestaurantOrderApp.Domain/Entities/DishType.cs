namespace RestaurantOrderApp.Domain.Entities
{
    public class DishType : BaseEntity
    {
        public DishType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }

        public string Name { get; }
    }
}
