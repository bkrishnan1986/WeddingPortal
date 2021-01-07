using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Happy.Weddings.Gateway.Core.DTO.ECommerce.Product;
using Happy.Weddings.Gateway.Core.Services.v1.ECommerce;
using Microsoft.AspNetCore.Mvc;

namespace Happy.Weddings.Gateway.API.Controllers.v1.ECommerce
{
    /// <summary>
    /// Subscriptions operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    //[Consumes("application/json")]
    [Route("/api/v1/E-Commerce-Management/products")]
    [ApiController]
    public class ProductsController : Controller
    {
        /// <summary>
        /// The subscription service
        /// </summary>
        private readonly IProductService productService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController"/> class.
        /// </summary>
        /// <param name="productService">The subscription service.</param>
        public ProductsController(
            IProductService productService)
        {
            this.productService = productService;
        }

        /// <summary>
        /// Gets the Carts
        /// </summary>
        /// <param name="productParameters">The subcription Plans Parameters.</param>
        /// <returns></returns> 
        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] ProductParameters productParameters)
        {
            var result = await productService.GetProducts(productParameters);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Get the Carts.
        /// </summary>
        /// <param name="productId">The Carts identifier.</param>
        /// <returns></returns>
        [Route("{productId}")]
        [HttpGet]
        public async Task<IActionResult> GetProduct(int productId)
        {
            var result = await productService.GetProductById(productId);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Create the Carts.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateProducts([FromForm] CreateProductsRequest request)
        {
            var result = await productService.CreateProducts(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Update the Product.
        /// </summary>
        /// <param name="productId">The subcriptionplan identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{productId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(int productId, [FromForm] UpdateProductRequest request)
        {
            var result = await productService.UpdateProducts(productId, request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Delete the Product.
        /// </summary>
        /// <param name="productId">The subcriptionplan identifier.</param>
        /// <returns></returns>
        [Route("{productId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var result = await productService.DeleteProducts(productId);
            return StatusCode((int)result.Code, result.Value);
        }

    }
}
