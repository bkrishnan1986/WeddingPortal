#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 03-Aug-2020 | Reji Salooja B S  | Created and implemented.
// | | MultiDetailController controller.
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Gateway.Core.Services.v1.Vendor;
using Happy.Weddings.Gateway.Core.DTO.Vendor.MultiDetail;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Happy.Weddings.Gateway.Core.DTO.Vendor.Utility;

namespace Happy.Weddings.Gateway.API.Controllers.v1
{
    /// <summary>
    /// Vendors multicode operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("​api​/v1​/vendor-management​/utility")]
    [ApiController]
    public class UtilityController : ControllerBase
    {
        /// <summary>
        /// The branch service
        /// </summary>
        private readonly IUtilityService utilityService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UtilityController"/> class.
        /// </summary>
        /// <param name="utilityService">The utility service.</param>
        public UtilityController(
            IUtilityService utilityService)
        {
            this.utilityService = utilityService;
        }

        /// <summary>
        /// Gets the utilitys.
        /// </summary>
        /// <param name="utilityParameter">The utility parameter.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetUtilitys([FromQuery] UtilityParameter utilityParameter)
        {
            var result = await utilityService.GetUtilitys(utilityParameter);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the utility by identifier.
        /// </summary>
        /// <param name="utilityId">The utility identifier.</param>
        /// <returns></returns>
        [Route("{utilityId}")]
        [HttpGet]
        public async Task<IActionResult> GetUtilityById(int utilityId)
        {

            var result = await utilityService.GetUtility(utilityId);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Creates the utility.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateUtility([FromBody] CreateUtilityRequest request)
        {
            var result = await utilityService.CreateUtility(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the utility.
        /// </summary>
        /// <param name="utilityId">The utility identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{utilityId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateUtility(int utilityId, [FromBody] UpdateUtilityRequest request)
        {
            var result = await utilityService.UpdateUtility(utilityId, request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the utility.
        /// </summary>
        /// <param name="utilityId">The utility identifier.</param>
        /// <returns></returns>
        [Route("{utilityId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUtility(int utilityId)
        {
            var result = await utilityService.DeleteUtility(utilityId);
            return StatusCode((int)result.Code, result.Value);
        }
    }
}