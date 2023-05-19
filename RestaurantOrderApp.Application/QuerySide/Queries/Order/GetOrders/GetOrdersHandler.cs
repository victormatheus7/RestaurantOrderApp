using RestaurantOrderApp.Domain.Interfaces;

namespace RestaurantOrderApp.Application.QuerySide.Queries.Order.GetOrders
{
    public class GetOrdersHandler : IQueryHandler<GetOrdersQuery, IList<Domain.Entities.Order>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrdersHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IList<Domain.Entities.Order>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.ListAsync(request.Id);
        }
    }
}
