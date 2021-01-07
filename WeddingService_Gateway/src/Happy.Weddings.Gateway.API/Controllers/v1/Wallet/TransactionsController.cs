using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Happy.Weddings.Gateway.API.Filters;
using Happy.Weddings.Gateway.Core.DTO.Wallet.Transactions;
using Happy.Weddings.Gateway.Core.Services.v1.Wallet;
using Microsoft.AspNetCore.Authorization;

namespace Happy.Weddings.Gateway.API.Controllers.v1.Wallet
{
    /// <summary>
    /// Transactions operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("transactions")]
    [ApiController]
    public class TransactionsController : Controller
    {
        /// <summary>
        /// The Transactions service
        /// </summary>
        private readonly ITransactionsService transactionsService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionsController"/> class.
        /// </summary>
        /// <param name="transactionsService">The Transactions service.</param>
        public TransactionsController(
            ITransactionsService transactionsService)
        {
            this.transactionsService = transactionsService;
        }

        /// <summary>
        /// Gets the Transactions.
        /// </summary>
        /// <param name="transactionsParameter">The Transactions parameters request.</param>
        /// <returns></returns>
        [HttpGet]
        [RequestRateLimit(Name = "Limit Request Number", Seconds = 1)]
        public async Task<IActionResult> GetAllTransactions([FromQuery] TransactionsParameter transactionsParameter)
        {
            var result = await transactionsService.GetAllTransactions(transactionsParameter);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the Transactions.
        /// </summary>
        /// <param name="transactionsId">The Transactions identifier.</param>
        /// <returns></returns>
        [Route("{transactionsId}")]
        [HttpGet]
        public async Task<IActionResult> GetTransactionsDetails(int transactionsId)
        {
            var result = await transactionsService.GetTransactionsDetails(new TransactionsIdDetails(transactionsId));
            return StatusCode((int)result.Code, result.Value);
        }
    }
}
