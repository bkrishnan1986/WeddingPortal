using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Happy.Weddings.Gateway.Core.DTO.ECommerce.Productquantity;
using Happy.Weddings.Gateway.Core.Services.v1.ECommerce;
using Microsoft.AspNetCore.Mvc;

namespace Happy.Weddings.Gateway.API.Controllers.v1.ECommerce
{
    /// <summary>
    /// Subscriptions operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("/api/v1/E-Commerce-Management/productquantity")]
    [ApiController]
    public class ProductQuantityController : Controller
    {
        /// <summary>
        /// The ProductQuantity service
        /// </summary>
        private readonly IProductquantityService productquantityService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CartsController"/> class.
        /// </summary>
        /// <param name="productquantityService">The ProductQuantity service.</param>
        public ProductQuantityController(
            IProductquantityService productquantityService)
        {
            this.productquantityService = productquantityService;
        }
        /// <summary>
        /// Gets the productquantitys.
        /// </summary>
        /// <param name="productquantityParameters">The productquantity parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetProductquantitys([FromQuery] ProductquantityParameters productquantityParameters)
        {
            var result = await productquantityService.GetProductquantitys(productquantityParameters);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the productquantity.
        /// </summary>
        /// <param name="productquantityId">The productquantity identifier.</param>
        /// <returns></returns>
        [Route("{productquantityId}")]
        [HttpGet]
        public async Task<IActionResult> GetProductquantity(int productquantityId)
        {
            var result = await productquantityService.GetProductquantityById(productquantityId);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Creates the productquantitys.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateProductquantitys([FromBody] CreateProductquantitysRequest request)
        {
            var result = await productquantityService.CreateProductquantity(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the productquantity.
        /// </summary>
        /// <param name="productquantityId">The productquantity identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{productquantityId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateProductquantity(int productquantityId, [FromBody] UpdateProductquantityRequest request)
        {
            var result = await productquantityService.UpdateProductquantity(productquantityId, request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the productquantity.
        /// </summary>
        /// <param name="productquantityId">The productquantity identifier.</param>
        /// <returns></returns>
        [Route("{productquantityId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProductquantity(int productquantityId)
        {
            var result = await productquantityService.DeleteProductquantity(productquantityId);
            return StatusCode((int)result.Code, result.Value);
        }

    }
}
