using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Happy.Weddings.Gateway.Core.DTO.ECommerce.Order;
using Happy.Weddings.Gateway.Core.Services.v1.ECommerce;
using Microsoft.AspNetCore.Mvc;

namespace Happy.Weddings.Gateway.API.Controllers.v1.ECommerce
{
    /// <summary>
    /// Subscriptions operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("/api/v1/E-Commerce-Management/orders")]
    [ApiController]
    public class OrdersController : Controller
    {
        /// <summary>
        /// The orders service
        /// </summary>
        private readonly IOrderService orderService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CartsController"/> class.
        /// </summary>
        /// <param name="orderService">The orders service.</param>
        public OrdersController(
            IOrderService orderService)
        {
            this.orderService = orderService;
        }

        /// <summary>
        /// Gets the Order
        /// </summary>
        /// <param name="orderParameters">The Orders Parameters.</param>
        /// <returns></returns> 
        [HttpGet]
        public async Task<IActionResult> GetOrders([FromQuery] OrderParameters orderParameters)
        {
            var result = await orderService.GetOrders(orderParameters);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the order.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        [Route("{orderId}")]
        [HttpGet]
        public async Task<IActionResult> GetOrderById(int orderId)
        {
            var result = await orderService.GetOrderById(orderId);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Creates the orders.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateOrders([FromBody] CreateOrderRequest request)
        {
            var result = await orderService.CreateOrders(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the orders.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{orderId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateOrders(int orderId, [FromBody] UpdateOrderRequest request)
        {
            var result = await orderService.UpdateOrders(orderId, request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the orders.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        [Route("{orderId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteOrders(int orderId)
        {
            var result = await orderService.DeleteOrders(orderId);
            return StatusCode((int)result.Code, result.Value);
        }

    }
}
