using RestaurantOrderApp.Domain.Interfaces;

namespace RestaurantOrderApp.Application.QuerySide.Queries.OrderPossibility.ListAllOrderPossibilities
{
    public class ListAllOrderPossibilitiesHandler : IQueryHandler<ListAllOrderPossibilitiesQuery, List<Domain.Entities.OrderPossibility>>
    {
        private readonly IOrderPossibilityRepository _orderPossibilityRepository;

        public ListAllOrderPossibilitiesHandler(IOrderPossibilityRepository orderPossibilityRepository)
        {
            _orderPossibilityRepository = orderPossibilityRepository;
        }

        public async Task<List<Domain.Entities.OrderPossibility>> Handle(ListAllOrderPossibilitiesQuery request, CancellationToken cancellationToken)
        {
            return await _orderPossibilityRepository.ListAllAsync();
        }
    }
}
