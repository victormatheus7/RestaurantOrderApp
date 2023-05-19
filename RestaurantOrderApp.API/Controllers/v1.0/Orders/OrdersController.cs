using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantOrderApp.Application.CommandSide.Command.Order.AddOrders;

namespace RestaurantOrderApp.API.Controllers.v1._0.Orders
{
    [ApiController]
    [Route("api/v1.0/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IMediator _mediator;

        public OrdersController(ILogger<OrdersController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> AddOrders([FromBody]AddOrdersCommand command)
        {
            try
            {
                await _mediator.Send(command);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}