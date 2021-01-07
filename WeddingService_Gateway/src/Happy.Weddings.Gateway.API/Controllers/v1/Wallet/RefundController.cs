using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Happy.Weddings.Gateway.API.Filters;
using Happy.Weddings.Gateway.Core.DTO.Wallet.Refund;
using Happy.Weddings.Gateway.Core.Services.v1.Wallet;
using Microsoft.AspNetCore.Authorization;

namespace Happy.Weddings.Gateway.API.Controllers.v1.Wallet
{
    /// <summary>
    /// Wallet operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("refund")]
    [ApiController]
    public class RefundController : ControllerBase
    {
        /// <summary>
        /// The Refund service
        /// </summary>
        private readonly IRefundService refundService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RefundController"/> class.
        /// </summary>
        /// <param name="refundService">The Refund service.</param>
        public RefundController(
            IRefundService refundService)
        {
            this.refundService = refundService;
        }

        /// <summary>
        /// Gets the Refund.
        /// </summary>
        /// <param name="refundParameter">The Refund parameters request.</param>
        /// <returns></returns>
        [HttpGet]
        [RequestRateLimit(Name = "Limit Request Number", Seconds = 1)]
        public async Task<IActionResult> GetAllRefund([FromQuery] RefundParameter refundParameter)
        {
            var result = await refundService.GetAllRefund(refundParameter);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the Refund.
        /// </summary>
        /// <param name="refundId">The Refund identifier.</param>
        /// <returns></returns>
        [Route("{refundId}")]
        [HttpGet]
        public async Task<IActionResult> GetRefundDetails(int refundId)
        {
            var result = await refundService.GetRefundDetails(new RefundIdDetails(refundId));
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Creates the Refund.
        /// </summary>
        /// 
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        //[Authorize(Roles = "Admin, Vendor")]
        public async Task<IActionResult> CreateRefund([FromBody] CreateRefundRequest request)
        {
            var result = await refundService.CreateRefund(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the Refund.
        /// </summary>
        /// <param name="refundId">The Refund identifier.</param>
        /// <param name="IsApproved">IsApproved status.</param>
        /// <param name="IsRejected">IsRejected status.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{refundId}/{IsApproved}/{IsRejected}")]
        [HttpPut]
        //[Authorize(Roles = "Admin, Vendor")]
        public async Task<IActionResult> UpdateRefund(int refundId, bool IsApproved, bool IsRejected, [FromBody] UpdateRefundRequest request)
        {
            var result = await refundService.UpdateRefund(new RefundIdDetails(refundId, IsApproved, IsRejected), request);
            return StatusCode((int)result.Code, result.Value);
        }
    }
}
