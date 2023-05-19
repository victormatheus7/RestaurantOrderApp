namespace RestaurantOrderApp.Domain.Entities
{
    public class Dish : BaseEntity
    {
        public Dish(int id, string name)
        {
            Id = id; 
            Name = name;
        }

        public int Id { get; }

        public string Name { get; }
    }
}
