using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Happy.Weddings.Gateway.Core.DTO.ECommerce.Orderlocation;
using Happy.Weddings.Gateway.Core.Services.v1.ECommerce;
using Microsoft.AspNetCore.Mvc;

namespace Happy.Weddings.Gateway.API.Controllers.v1.ECommerce
{
    /// <summary>
    /// OrderlocationController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("/api/v1/E-Commerce-Management/orderlocations")]
    [ApiController]
    public class OrderlocationController : Controller
    {
        /// <summary>
        /// The orderlocation service
        /// </summary>
        private readonly IOrderlocationService orderlocationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderlocationController"/> class.
        /// </summary>
        /// <param name="orderlocationService">The orderlocation service.</param>
        public OrderlocationController(
            IOrderlocationService orderlocationService)
        {
            this.orderlocationService = orderlocationService;
        }

        /// <summary>
        /// Gets the orderlocations.
        /// </summary>
        /// <param name="orderlocationParameters">The orderlocation parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetOrderlocations([FromQuery] OrderlocationParameters orderlocationParameters)
        {
            var result = await orderlocationService.GetOrderlocations(orderlocationParameters);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the orderlocation.
        /// </summary>
        /// <param name="orderlocationId">The orderlocation identifier.</param>
        /// <returns></returns>
        [Route("{orderlocationId}")]
        [HttpGet]
        public async Task<IActionResult> GetOrderlocation(int orderlocationId)
        {
            var result = await orderlocationService.GetOrderlocationById(orderlocationId);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Creates the orderlocations.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateOrderlocations([FromBody] CreateOrderlocationRequest request)
        {
            var result = await orderlocationService.CreateOrderlocation(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the orderlocations.
        /// </summary>
        /// <param name="orderlocationId">The orderlocation identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{orderlocationId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateOrderlocations(int orderlocationId, [FromBody] UpdateOrderlocationRequest request)
        {
            var result = await orderlocationService.UpdateOrderlocations(orderlocationId, request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the orderlocations.
        /// </summary>
        /// <param name="orderlocationId">The orderlocation identifier.</param>
        /// <returns></returns>
        [Route("{orderlocationId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteOrderlocations(int orderlocationId)
        {
            var result = await orderlocationService.DeleteOrderlocations(orderlocationId);
            return StatusCode((int)result.Code, result.Value);
        }

    }
}
