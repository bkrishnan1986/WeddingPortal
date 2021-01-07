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

namespace Happy.Weddings.Gateway.API.Controllers.v1
{
    /// <summary>
    /// Vendors multicode operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("vendormultidetails")]
    [ApiController]
    public class MultiDetailsController : ControllerBase
    {
        /// <summary>
        /// The branch service
        /// </summary>
        private readonly IMultiDetailService multiDetailService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiDetailsController"/> class.
        /// </summary>
        /// <param name="multiDetailService">The branch service.</param>
        public MultiDetailsController(
            IMultiDetailService multiDetailService)
        {
            this.multiDetailService = multiDetailService;
        }  

        /// <summary>
        /// Gets the multidetail.
        /// </summary>
        /// <param name="multiDetailParameters">The multidetail parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetMultiDetails([FromQuery] MultiDetailParameters multiDetailParameters)
        {
            var result = await multiDetailService.GetMultiDetails(multiDetailParameters);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the multidetails
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [Route("{code}")]
        [HttpGet]
        public async Task<IActionResult> GetMultiDetailsById(string code)
        {

            var result = await multiDetailService.GetMultiDetailsById(code);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Creates the multidetail.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateMultiDetails([FromBody] CreateMultiDetailsRequest request)
        {
            var result = await multiDetailService.CreateMultiDetails(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates MultiDetail.
        /// </summary>
        /// <param name="multidetailId">The multidetail identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{multidetailId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateMultiDetails(int multidetailId, [FromBody] UpdateMultiDetailsRequest request)
        {
            var result = await multiDetailService.UpdateMultiDetails(multidetailId, request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the MultiDetail.
        /// </summary>
        /// <param name="multidetailId">The Multidetail identifier.</param>
        /// <returns></returns>
        [Route("{multidetailId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteMultiDetails(int multidetailId)
        {
            var result = await multiDetailService.DeleteMultiDetails(multidetailId);
            return StatusCode((int)result.Code, result.Value);
        }
    }
}