using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Happy.Weddings.Gateway.Core.DTO.ECommerce.Cart;
using Happy.Weddings.Gateway.Core.Services.v1.ECommerce;
using Microsoft.AspNetCore.Mvc;

namespace Happy.Weddings.Gateway.API.Controllers.v1.ECommerce
{
    /// <summary>
    /// carts operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("/api/v1/E-Commerce-Management/carts")]
    [ApiController]
    public class CartsController : Controller
    {
        /// <summary>
        /// The carts service
        /// </summary>
        private readonly ICartService cartService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CartsController"/> class.
        /// </summary>
        /// <param name="cartService">The carts service.</param>
        public CartsController(
            ICartService cartService)
        {
            this.cartService = cartService;
        }

        /// <summary>
        /// Gets the Carts
        /// </summary>
        /// <param name="cartParameters">The carts Parameters.</param>
        /// <returns></returns> 
        [HttpGet]
        public async Task<IActionResult> GetCarts([FromQuery] CartParameters cartParameters)
        {
            var result = await cartService.GetCarts(cartParameters);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Get the Carts.
        /// </summary>
        /// <param name="cartId">The Carts identifier.</param>
        /// <returns></returns>
        [Route("{cartId}")]
        [HttpGet]
        public async Task<IActionResult> GetCart(int cartId)
        {
            var result = await cartService.GetCartById(cartId);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Get the Carts.
        /// </summary>
        /// <param name="userId">The Carts identifier.</param>
        /// <returns></returns>
        [Route("TotPrice/{userId}")]
        [HttpGet]
        public async Task<IActionResult> GetCartByUserId(int userId)
        {
            var result = await cartService.GetCartByUserId(userId);
            return StatusCode((int)result.Code, result.Value);
        }
        /// <summary>
        /// Create the Carts.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateCarts([FromBody] CreateCartsRequest request)
        {
            var result = await cartService.CreateCarts(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Update the Carts.
        /// </summary>
        /// <param name="cartId">The Carts identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{cartId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateCart(int cartId, [FromBody] UpdateCartRequest request)
        {
            var result = await cartService.UpdateCarts(cartId, request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Delete the Cart.
        /// </summary>
        /// <param name="cartId">The Carts identifier.</param>
        /// <returns></returns>
        [Route("{cartId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCart(int cartId)
        {
            var result = await cartService.DeleteCarts(cartId);
            return StatusCode((int)result.Code, result.Value);
        }

    }
}
