namespace RestaurantOrderApp.Domain.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        { }

        public BaseEntity(DateTime modifiedDate)
        {
            ModifiedDate = modifiedDate;
        }

        public DateTime ModifiedDate { get; }
    }
}
