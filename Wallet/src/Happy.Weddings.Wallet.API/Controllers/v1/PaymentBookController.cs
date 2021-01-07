#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | PaymentBookController-- Controller.
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Happy.Weddings.Wallet.Core.DTO.Requests.PaymentBook;
using Happy.Weddings.Wallet.Service.Commands.v1.PaymentBook;
using Happy.Weddings.Wallet.Service.Queries.v1.PaymentBook;
using Happy.Weddings.Wallet.Core.Domain;
using MediatR;
using System.Net;

namespace Happy.Weddings.Wallet.API.Controllers.v1
{
    /// <summary>
    /// PaymentBook operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("paymentBook")]
    [ApiController]
    public class PaymentBookController : ControllerBase
    {
        #region Variables

        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator mediator;

        #endregion

        #region Constructor Overloading

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentBookController" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public PaymentBookController(
            IMediator mediator)
        {
            this.mediator = mediator;
        }

        #endregion

        #region PaymentBook

        /// <summary>
        /// Gets the PaymentBook
        /// </summary>
        /// <param name="paymentBookSearchParameter">The PaymentBook Search Parameter.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllPaymentBook([FromQuery] PaymentBookSearchParameter paymentBookSearchParameter)
        {
            var getAllPaymentBookQuery = new GetAllPaymentBookQuery(paymentBookSearchParameter);

            var result = await mediator.Send(getAllPaymentBookQuery);

            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Get the PaymentBook
        /// </summary>
        /// <param name="paymentBookId">The PaymentBook identifier.</param>
        /// <returns></returns>
        [Route("{paymentBookId}")]
        [HttpGet]
        public async Task<IActionResult> GetPaymentBookDetails(int paymentBookId)
        {
            var getPaymentBookQuery = new GetPaymentBookQuery(paymentBookId);

            var result = await mediator.Send(getPaymentBookQuery);

            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Create the PaymentBook
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreatePaymentBook([FromBody] CreatePaymentBookRequest request)
        {
            var createPaymentBookCommand = new CreatePaymentBookCommand(request);
            var result = await mediator.Send(createPaymentBookCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates PaymentBook.
        /// </summary>
        /// <param name="paymentBookId">The PaymentBook identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{paymentBookId}")]
        [HttpPut]
        public async Task<IActionResult> UpdatePaymentBook(int paymentBookId, [FromBody] UpdatePaymentBookRequest request)
        {
            var updatePaymentBookCommand = new UpdatePaymentBookCommand(paymentBookId, request);
            var result = await mediator.Send(updatePaymentBookCommand);

            return StatusCode((int)result.Code, result.Value);
        }

        #endregion
    }
}
