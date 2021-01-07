using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Happy.Weddings.Gateway.API.Filters;
using Happy.Weddings.Gateway.Core.Services.v1.ECommerce;
using Happy.Weddings.Gateway.Core.DTO.ECommerce.MultiCode;
using Happy.Weddings.Gateway.Core.DTO.ECommerce.Multicode;

namespace Happy.Weddings.Gateway.API.Controllers.v1.ECommerce
{
    /// <summary>
    /// Blog operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("/api/v1/E-Commerce-Management/multicodes")]
    [ApiController]
    public class MulticodeController : ControllerBase
    {
        /// <summary>
        /// The Multicode service
        /// </summary>
        private readonly IMulticodeService multicodeService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MulticodeController"/> class.
        /// </summary>
        /// <param name="multicodeService">The Multicode service.</param>
        public MulticodeController(
            IMulticodeService multicodeService)
        {
            this.multicodeService = multicodeService;
        }

        /// <summary>
        /// Gets all multi codes.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [RequestRateLimit(Name = "Limit Request Number", Seconds = 1)]
        public async Task<IActionResult> GetAllMultiCodes()
        {
            MulticodeParameter multicodeParameter = new MulticodeParameter();
            var result = await multicodeService.GetAllMultiCodes(multicodeParameter);
            return StatusCode((int)result.Code, result.Value);
        }


        /// <summary>
        /// Gets the Multicode.
        /// </summary>
        /// <param name="code">System Code.</param>
        /// <returns></returns>
        [Route("{code}")]
        [HttpGet]
        public async Task<IActionResult> GetMultiCode(string code)
        {
            var result = await multicodeService.GetMultiCode(new MulticodeIdDetail(code));
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Creates the Multicode.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        //[Authorize(Roles = "Admin, Vendor")]
        public async Task<IActionResult> CreateMultiCode([FromBody] CreateMulticodeEcommerceRequest request)
        {
            var result = await multicodeService.CreateMultiCode(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the Multicode.
        /// </summary>
        /// <param name="code">System Code.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{code}")]
        [HttpPut]
        //[Authorize(Roles = "Admin, Vendor")]
        public async Task<IActionResult> UpdateMultiCode(string code, [FromBody] UpdateMulticodeEcommerceRequest request)
        {
            var result = await multicodeService.UpdateMultiCode(new MulticodeIdDetail(code), request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the Multicode.
        /// </summary>
        /// <param name="code">System Code.</param>
        /// <returns></returns>
        [Route("{code}")]
        [HttpDelete]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteMultiCode(string code)
        {
            var result = await multicodeService.DeleteMultiCode(new MulticodeIdDetail(code));
            return StatusCode((int)result.Code, result.Value);
        }
    }
}
