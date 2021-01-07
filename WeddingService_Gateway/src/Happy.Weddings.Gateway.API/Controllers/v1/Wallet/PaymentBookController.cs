using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Happy.Weddings.Gateway.API.Filters;
using Happy.Weddings.Gateway.Core.DTO.Wallet.PaymentBook;
using Happy.Weddings.Gateway.Core.Services.v1.Wallet;
using Microsoft.AspNetCore.Authorization;

namespace Happy.Weddings.Gateway.API.Controllers.v1.Wallet
{
    /// <summary>
    /// Wallet operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("paymentBook")]
    [ApiController]
    public class PaymentBookController : ControllerBase
    {
        /// <summary>
        /// The PaymentBook service
        /// </summary>
        private readonly IPaymentBookService paymentBookService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentBookController"/> class.
        /// </summary>
        /// <param name="paymentBookService">The PaymentBook service.</param>
        public PaymentBookController(
            IPaymentBookService paymentBookService)
        {
            this.paymentBookService = paymentBookService;
        }

        /// <summary>
        /// Gets the PaymentBook.
        /// </summary>
        /// <param name="paymentBookParameter">The PaymentBook parameters request.</param>
        /// <returns></returns>
        [HttpGet]
        [RequestRateLimit(Name = "Limit Request Number", Seconds = 1)]
        public async Task<IActionResult> GetAllPaymentBook([FromQuery] PaymentBookParameter paymentBookParameter)
        {
            var result = await paymentBookService.GetAllPaymentBook(paymentBookParameter);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the PaymentBook.
        /// </summary>
        /// <param name="paymentBookId">The PaymentBook identifier.</param>
        /// <returns></returns>
        [Route("{paymentBookId}")]
        [HttpGet]
        public async Task<IActionResult> GetPaymentBookDetails(int paymentBookId)
        {
            var result = await paymentBookService.GetPaymentBookDetails(new PaymentBookIdDetails(paymentBookId));
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Creates the PaymentBook.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        //[Authorize(Roles = "Admin, Vendor")]
        public async Task<IActionResult> CreatePaymentBook([FromBody] PaymentBookRequest request)
        {
            var result = await paymentBookService.CreatePaymentBook(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the PaymentBook.
        /// </summary>
        /// <param name="paymentBookId">The PaymentBook identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{paymentBookId}")]
        [HttpPut]
        //[Authorize(Roles = "Admin, Vendor")]
        public async Task<IActionResult> UpdatePaymentBook(int paymentBookId, [FromBody] UpdatePaymentBookRequest request)
        {
            var result = await paymentBookService.UpdatePaymentBook(new PaymentBookIdDetails(paymentBookId), request);
            return StatusCode((int)result.Code, result.Value);
        }
    }
}
