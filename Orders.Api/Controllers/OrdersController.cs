using Microsoft.AspNetCore.Mvc;
using Orders.BusinessLogic.Services.Orders.Interfaces;
using Orders.BusinessLogic.Services.Orders.Models;

namespace Orders.Api.Controllers
{
    [Route("orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(
            IOrdersService ordersService
            )
        {
            _ordersService = ordersService;
        }

        [HttpGet("{orderId}")]
        public IActionResult GetOrder(int orderId)
        {
            var order = _ordersService.GetOrder(orderId);
            if (order == null)
                return NotFound();

            return Ok(order);
        }

        [Route("")]
        [HttpPut]
        public void UpdateOrder(UpdateOrderRequest orderDto)
        {
            _ordersService.UpdateOrder(orderDto);
        }

        [Route("")]
        [HttpPost]
        public void CreateOrder(CreateOrderRequest orderDto)
        {
            _ordersService.CreateOrder(orderDto);
        }

        [HttpDelete("{orderId}")]
        public void CancelOrder(int orderId)
        {
            _ordersService.CancelOrder(orderId);
        }
    }
}
