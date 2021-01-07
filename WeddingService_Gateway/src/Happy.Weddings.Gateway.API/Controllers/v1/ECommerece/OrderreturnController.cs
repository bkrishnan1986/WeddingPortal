using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Happy.Weddings.Gateway.Core.DTO.ECommerce.Orderreturn;
using Happy.Weddings.Gateway.Core.Services.v1.ECommerce;
using Microsoft.AspNetCore.Mvc;

namespace Happy.Weddings.Gateway.API.Controllers.v1.ECommerce
{
    /// <summary>
    /// OrderreturnController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("/api/v1/E-Commerce-Management/orderreturn")]
    [ApiController]
    public class OrderreturnController : Controller
    {

        private readonly IOrderreturnService orderreturnService;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderreturnController"/> class.
        /// </summary>
        /// <param name="orderreturnService">The orderreturn service.</param>
        public OrderreturnController(
            IOrderreturnService orderreturnService)
        {
            this.orderreturnService = orderreturnService;
        }

        /// <summary>
        /// Gets the orderreturns.
        /// </summary>
        /// <param name="orderreturnParameters">The orderreturn parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetOrderreturns([FromQuery] OrderreturnParameters orderreturnParameters)
        {
            var result = await orderreturnService.GetOrderreturns(orderreturnParameters);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the orderreturn.
        /// </summary>
        /// <param name="orderreturnId">The order identifier.</param>
        /// <returns></returns>
        [Route("{orderreturnId}")]
        [HttpGet]
        public async Task<IActionResult> GetOrderreturn(int orderreturnId)
        {
            var result = await orderreturnService.GetOrderreturnById(orderreturnId);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Creates the orderreturns.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateOrderreturns([FromBody] CreateOrderreturnRequest request)
        {
            var result = await orderreturnService.CreateOrderreturns(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the orderreturns.
        /// </summary>
        /// <param name="orderreturnId">The order identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{orderreturnId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateOrderreturns(int orderreturnId, [FromBody] UpdateOrderreturnRequest request)
        {
            var result = await orderreturnService.UpdateOrderreturns(orderreturnId, request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the orderreturns.
        /// </summary>
        /// <param name="orderreturnId">The order identifier.</param>
        /// <returns></returns>
        [Route("{orderreturnId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteOrderreturns(int orderreturnId)
        {
            var result = await orderreturnService.DeleteOrderreturns(orderreturnId);
            return StatusCode((int)result.Code, result.Value);
        }

    }
}
