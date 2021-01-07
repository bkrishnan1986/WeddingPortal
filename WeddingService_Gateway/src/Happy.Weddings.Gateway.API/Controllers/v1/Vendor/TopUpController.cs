using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Happy.Weddings.Gateway.Core.DTO.Vendor.Topup;
using Happy.Weddings.Gateway.Core.DTO.Vendor.TopupBenefit;
using Happy.Weddings.Gateway.Core.Services.v1.Vendor;
using Microsoft.AspNetCore.Mvc;

namespace Happy.Weddings.Gateway.API.Controllers.v1.Vendor
{
    /// <summary>
    /// TopUp operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("topups")]
    [ApiController]
    public class TopUpController : Controller
    {
        /// <summary>
        /// The top up service
        /// </summary>
        private readonly ITopupService topUpService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TopUpController"/> class.
        /// </summary>
        /// <param name="topUpService">The top up service.</param>
        public TopUpController(
            ITopupService topUpService)
        {
            this.topUpService = topUpService;
        }

        /// <summary>
        /// Gets the Top Up 
        /// </summary>
        /// <param name="topupsParameters">The Vendor subcription  Parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetTopUps([FromQuery] TopUpParameter topupsParameters)
        {
            var result = await topUpService.GetTopUps(topupsParameters);
            return StatusCode((int)result.Code, result.Value);
        }
        /// <summary>
        /// Gets the top up by identifier.
        /// </summary>
        /// <param name="topupId">The topup identifier.</param>
        /// <returns></returns>
        [Route("{topupId}")]
        [HttpGet]
        public async Task<IActionResult> GetTopUpById(int topupId)
        {
            var result = await topUpService.GetTopUpById(topupId);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Create the Top Up
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateTopUp([FromBody] CreateTopUpRequest request)
        {
            var result = await topUpService.CreateTopUp(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Update the Top Up
        /// </summary>
        /// <param name="topupId">The topup identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{topupId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateTopUp(int topupId, [FromBody] UpdateTopUpRequest request)
        {
            var result = await topUpService.UpdateTopUp(topupId, request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Delete the Top up
        /// </summary>
        /// <param name="topupId">The topup identifier.</param>
        /// <returns></returns>
        [Route("{topupId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTopUp(int topupId)
        {
            var result = await topUpService.DeleteTopUp(topupId);
            return StatusCode((int)result.Code, result.Value);
        }


        /// <summary>
        /// Gets the Top Up Benefit
        /// </summary>
        /// <param name="topupBenefitsParameters">The Vendor subcription  Parameters.</param>
        /// <returns></returns>
        [Route("topupbenefit")]
        [HttpGet]
        public async Task<IActionResult> GetTopUpBenefits([FromQuery] TopUpBenefitParameter topupBenefitsParameters)
        {
            var result = await topUpService.GetTopUpBenefits(topupBenefitsParameters);
            return StatusCode((int)result.Code, result.Value);
        }
        /// <summary>
        /// Gets the top up Benefit by identifier.
        /// </summary>
        /// <param name="topupbenefitId">The topup identifier.</param>
        /// <returns></returns>
        [Route("{topupId}/topupbenefit/{topupbenefitId}")]
        [HttpGet]
        public async Task<IActionResult> GetTopupBenefitById(int topupbenefitId)
        {
            var result = await topUpService.GetTopupBenefitById(topupbenefitId);
            return StatusCode((int)result.Code, result.Value);
        }
        /// <summary>
        /// Create the Top Up Benefit
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// 
        [Route("{topupId}/topupbenefit")]
        [HttpPost]
        public async Task<IActionResult> CreateTopUpBenefit([FromBody] CreateTopUpBenefitRequest request)
        {
            var result = await topUpService.CreateTopUpBenefit(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Update the Top Up Benefit
        /// </summary>
        /// <param name="topupId">The topup Benefit identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{topupId}/topupbenefit/{topupbenefitId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateTopUpBenefit(int topupId, [FromBody] UpdateTopUpBenefitRequest request)
        {
            var result = await topUpService.UpdateTopUpBenefit(topupId,request);
            return StatusCode((int)result.Code, result.Value);
        }
    }
}
