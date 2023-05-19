using RestaurantOrderApp.Domain.Entities;

namespace RestaurantOrderApp.UnitTests.Domain
{
    public class OrderTests
    {
        private readonly IDictionary<int, TimeOfDay> _timesOfDay;
        private readonly IDictionary<int, DishType> _dishTypes;
        private readonly IDictionary<int, Dish> _dishes;

        public OrderTests()
        {
            _timesOfDay = new Dictionary<int, TimeOfDay>() 
            { 
                { 0, new TimeOfDay(0, "morning") },
                { 1, new TimeOfDay(1, "night") },
            };

            _dishTypes = new Dictionary<int, DishType>()
            {
                { 1, new DishType(1, "entrée") },
                { 2, new DishType(2, "side") },
                { 3, new DishType(3, "drink") },
                { 4, new DishType(4, "dessert") },
            };

            _dishes = new Dictionary<int, Dish>()
            {
                { 0, new Dish(0, "eggs") },
                { 1, new Dish(1, "Toast") },
                { 2, new Dish(2, "coffee") },
                { 3, new Dish(3, "steak") },
                { 4, new Dish(4, "potato") },
                { 5, new Dish(5, "wine") },
                { 6, new Dish(6, "cake") },
            };
        }

        [Fact]
        public void CreateOrder_WithNoDuplicateDishTypes_AllDishIdsSaved()
        {
            var orderPossibilities = new List<OrderPossibility>()
            {
                new OrderPossibility(_timesOfDay[1], _dishTypes[1], _dishes[3]),
                new OrderPossibility(_timesOfDay[1], _dishTypes[2], _dishes[4]),
                new OrderPossibility(_timesOfDay[1], _dishTypes[3], _dishes[5]),
                new OrderPossibility(_timesOfDay[1], _dishTypes[4], _dishes[6]),
            };

            var guid = new Guid();
            var dishTypes = new List<int>() { 1, 2, 3, 4 };
            var timeOfDay = 1;

            var orders = Order.CreateOrders(orderPossibilities, guid, timeOfDay, dishTypes);

            Assert.Equal(dishTypes.Count, orders.Count);
            Assert.True(orders.All(o => o.DishId.HasValue));
        }

        [Fact]
        public void CreateOrder_WithDishTypeThatAllowDuplicates_AllDishIdsSaved()
        {
            var orderPossibilities = new List<OrderPossibility>()
            {
                new OrderPossibility(_timesOfDay[0], _dishTypes[1], _dishes[0]),
                new OrderPossibility(_timesOfDay[0], _dishTypes[2], _dishes[1]),
                new OrderPossibility(_timesOfDay[0], _dishTypes[3], _dishes[2])
            };

            var guid = new Guid();
            var dishTypes = new List<int>() { 3, 3, 1, 2, 3 };
            var timeOfDay = 0;

            var orders = Order.CreateOrders(orderPossibilities, guid, timeOfDay, dishTypes);

            Assert.Equal(dishTypes.Count, orders.Count);
            Assert.True(orders.All(o => o.DishId.HasValue));
        }

        [Fact]
        public void CreateOrder_WithDishTypeThatDontAllowDuplicates_EachDishIdSavedJustOnce()
        {
            var orderPossibilities = new List<OrderPossibility>()
            {
                new OrderPossibility(_timesOfDay[0], _dishTypes[1], _dishes[0]),
                new OrderPossibility(_timesOfDay[0], _dishTypes[2], _dishes[1]),
                new OrderPossibility(_timesOfDay[0], _dishTypes[3], _dishes[2])
            };

            var guid = new Guid();
            var duplicatedDishTypesAllowed = new List<int>() { 1, 2, 3, 3, 3 };
            var duplicatedDishTypesNotAllowed = new List<int>() { 1, 1, 2, 2, 2 };
            var timeOfDay = 0;

            var dishTypes = new List<int>();
            dishTypes.AddRange(duplicatedDishTypesAllowed);
            dishTypes.AddRange(duplicatedDishTypesNotAllowed);

            var orders = Order.CreateOrders(orderPossibilities, guid, timeOfDay, dishTypes);

            Assert.Equal(dishTypes.Count, orders.Count);
            Assert.Equal(duplicatedDishTypesAllowed.Count, orders.Count(o => o.DishId.HasValue));
            Assert.Equal(duplicatedDishTypesNotAllowed.Count, orders.Count(o => !o.DishId.HasValue));
        }

        [Fact]
        public void CreateOrder_WithDishTypeNotRegistered_NoneDishIdSaved()
        {
            var orderPossibilities = new List<OrderPossibility>()
            {
                new OrderPossibility(_timesOfDay[1], _dishTypes[1], _dishes[3]),
                new OrderPossibility(_timesOfDay[1], _dishTypes[2], _dishes[4]),
                new OrderPossibility(_timesOfDay[1], _dishTypes[3], _dishes[5]),
                new OrderPossibility(_timesOfDay[1], _dishTypes[4], _dishes[6]),
            };

            var guid = new Guid();
            var registeredDishTypes = new List<int>() { 1, 2, 3, 4 };
            var dishTypesNotRegistered = new List<int>() { 5, 8, 20, 100 };
            var timeOfDay = 1;

            var dishTypes = new List<int>();
            dishTypes.AddRange(registeredDishTypes);
            dishTypes.AddRange(dishTypesNotRegistered);

            var orders = Order.CreateOrders(orderPossibilities, guid, timeOfDay, dishTypes);

            Assert.Equal(dishTypes.Count, orders.Count);
            Assert.Equal(registeredDishTypes.Count, orders.Count(o => o.DishId.HasValue));
            Assert.Equal(dishTypesNotRegistered.Count, orders.Count(o => !o.DishId.HasValue));
        }
    }
}
