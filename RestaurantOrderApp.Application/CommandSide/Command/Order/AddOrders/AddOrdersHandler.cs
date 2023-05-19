using MediatR;
using RestaurantOrderApp.Application.QuerySide.Queries.OrderPossibility.GetOrderPossibilities;
using RestaurantOrderApp.Domain.Interfaces;

namespace RestaurantOrderApp.Application.CommandSide.Command.Order.AddOrders
{
    public class AddOrdersHandler : ICommandHandler<AddOrdersCommand>
    {
        private readonly IMediator _mediator;

        private readonly IOrderRepository _orderRepository;

        public AddOrdersHandler(IMediator mediator, IOrderRepository orderRepository)
        {
            _mediator = mediator;

            _orderRepository = orderRepository;
        }

        public async Task Handle(AddOrdersCommand request, CancellationToken cancellationToken)
        {
            var orderPossibilities = await _mediator.Send(new GetOrderPossibilitiesQuery(request.TimeOfDayName));

            if (!orderPossibilities.Any())
                throw new Exception($"No order possibilities were found for '{request.TimeOfDayName}'.");

            var orders = Domain.Entities.Order.CreateOrders(orderPossibilities, request.Id, orderPossibilities.First().TimeOfDay.Id, request.DishTypeIds);

            await _orderRepository.SaveAsync(orders);
        }
    }
}
