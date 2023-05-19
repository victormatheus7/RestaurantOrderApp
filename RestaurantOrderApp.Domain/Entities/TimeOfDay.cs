namespace RestaurantOrderApp.Domain.Entities
{
    public class TimeOfDay : BaseEntity
    {
        public TimeOfDay(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }

        public string Name { get; }
    }
}
