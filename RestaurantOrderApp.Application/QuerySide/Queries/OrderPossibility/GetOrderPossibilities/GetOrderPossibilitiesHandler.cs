using RestaurantOrderApp.Domain.Interfaces;

namespace RestaurantOrderApp.Application.QuerySide.Queries.OrderPossibility.GetOrderPossibilities
{
    public class GetOrderPossibilitiesHandler : IQueryHandler<GetOrderPossibilitiesQuery, IList<Domain.Entities.OrderPossibility>>
    {
        private readonly IOrderPossibilityRepository _orderPossibilityRepository;

        public GetOrderPossibilitiesHandler(IOrderPossibilityRepository orderPossibilityRepository)
        {
            _orderPossibilityRepository = orderPossibilityRepository;
        }

        public async Task<IList<Domain.Entities.OrderPossibility>> Handle(GetOrderPossibilitiesQuery request, CancellationToken cancellationToken)
        {
            return await _orderPossibilityRepository.ListAsync(request.TimeOfDayName?.Trim().ToLower());
        }
    }
}
