#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 03-Aug-2020 | Reji Salooja B S  | Created and implemented.
// | | MultiCodeController controller.
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Gateway.Core.Services.v1.Vendor;
using Happy.Weddings.Gateway.Core.DTO.Vendor.MultiCode;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Happy.Weddings.Gateway.API.Filters;

namespace Happy.Weddings.Gateway.API.Controllers.v1
{
    /// <summary>
    /// Vendors multicode operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("vendormulticodes")]
    [ApiController]
    public class MultiCodesController : ControllerBase
    {
        /// <summary>
        /// The kyc detail service
        /// </summary>
        private readonly IMultiCodeService multiCodeService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiCodesController"/> class.
        /// </summary>
        /// <param name="multiCodeService">The kyc detail service.</param>
        public MultiCodesController(
            IMultiCodeService multiCodeService)
        {
            this.multiCodeService = multiCodeService;
        }

        /// <summary>
        /// Gets the MultiCodes.
        /// </summary>
        /// <param name="multiCodeParameters">The multicode parameters.</param>
        /// <returns></returns>
        [HttpGet]
        [RequestRateLimit(Name = "Limit Request Number", Seconds = 1)]
        public async Task<IActionResult> GetMultiCodes([FromQuery] MultiCodeParameters multiCodeParameters)
        {
            var result = await multiCodeService.GetMultiCodes(multiCodeParameters);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the Multicode.
        /// </summary>
        /// <param name="code">System Code.</param>
        /// <returns></returns>
        [Route("{code}")]
        [HttpGet]
        public async Task<IActionResult> GetMultiCodeById(string code)
        {
            var result = await multiCodeService.GetMultiCodeById(code);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Creates the Multicode.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("createmulticode")]
        [HttpPost]
        public async Task<IActionResult> CreateMultiCode([FromBody] CreateMultiCodeVendorRequest request)
        {
            var result = await multiCodeService.CreateMultiCode(request);
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
        public async Task<IActionResult> UpdateMultiCode(string code, [FromBody] UpdateMultiCodeVendorRequest request)
        {
            var result = await multiCodeService.UpdateMultiCode(code, request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the Multicode.
        /// </summary>
        /// <param name="code">System Code.</param>
        /// <returns></returns>
        [Route("{code}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteMultiCode(string code)
        {
            var result = await multiCodeService.DeleteMultiCode(code);
            return StatusCode((int)result.Code, result.Value);
        }
    }
}