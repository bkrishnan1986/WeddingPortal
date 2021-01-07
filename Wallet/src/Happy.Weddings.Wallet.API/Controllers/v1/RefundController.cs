#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | RefundController-- Controller.
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Happy.Weddings.Wallet.Core.DTO.Requests.Refund;
using Happy.Weddings.Wallet.Service.Commands.v1.Refund;
using Happy.Weddings.Wallet.Service.Queries.v1.Refund;
using Happy.Weddings.Wallet.Core.Domain;
using MediatR;
using System.Net;
using Happy.Weddings.Wallet.Core.DTO.Requests.PaymentBook;

namespace Happy.Weddings.Wallet.API.Controllers.v1
{
    /// <summary>
    /// Refund operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("refund")]
    [ApiController]
    public class RefundController : ControllerBase
    {
        #region Variables

        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator mediator;

        #endregion

        #region Constructor Overloading

        /// <summary>
        /// Initializes a new instance of the <see cref="RefundController" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public RefundController(
            IMediator mediator)
        {
            this.mediator = mediator;
        }

        #endregion

        #region Refund

        /// <summary>
        /// Gets the Refund
        /// </summary>
        /// <param name="refundParameter">The Refund Parameter.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllRefund([FromQuery] RefundParameter refundParameter)
        {
            var getAllRefundQuery = new GetAllRefundQuery(refundParameter);

            var result = await mediator.Send(getAllRefundQuery);

            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Get the Refund
        /// </summary>
        /// <param name="refundId">The Refund identifier.</param>
        /// <returns></returns>
        [Route("{refundId}")]
        [HttpGet]
        public async Task<IActionResult> GetRefundDetails(int refundId)
        {
            var getRefundQuery = new GetRefundQuery(refundId);

            var result = await mediator.Send(getRefundQuery);

            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Create the Refund
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateRefund([FromBody] CreateRefundRequest request)
        {
            var createRefundCommand = new CreateRefundCommand(request);
            var result = await mediator.Send(createRefundCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates PaymentBook.
        /// </summary>
        /// <param name="refundId">The Refund identifier.</param>
        /// <param name="request">The request.</param>
        /// <param name="IsApproved">IsApproved status.</param>
        /// <param name="IsRejected">IsRejected status.</param>
        /// <returns></returns>
        [Route("{refundId}/{IsApproved}/{IsRejected}")]
        [HttpPut]
        public async Task<IActionResult> UpdateRefund(int refundId, bool IsApproved, bool IsRejected, [FromBody] UpdateRefundRequest request)
        {
            var updateRefundCommand = new UpdateRefundCommand(refundId, request, IsApproved, IsRejected);
            var result = await mediator.Send(updateRefundCommand);

            return StatusCode((int)result.Code, result.Value);
        }

        #endregion
    }
}
