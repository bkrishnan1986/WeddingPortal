using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Happy.Weddings.Wallet.Core.DTO.Requests.Transactions;
using Happy.Weddings.Wallet.Service.Commands.v1.Transactions;
using Happy.Weddings.Wallet.Service.Queries.v1.Transactions;
using Happy.Weddings.Wallet.Core.Domain;
using MediatR;
using System.Net;

namespace Happy.Weddings.Wallet.API.Controllers.v1
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
        #region Variables

        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator mediator;

        #endregion

        #region Constructor Overloading

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionsController" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public TransactionsController(
            IMediator mediator)
        {
            this.mediator = mediator;
        }

        #endregion

        #region Transactions

        /// <summary>
        /// Gets All Transactions
        /// </summary>
        /// <param name="transactionsParameter">The Transactions Parameter.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllTransactions([FromQuery] TransactionsParameter transactionsParameter)
        {
            var transactions = new GetAllTransactionsQuery(transactionsParameter);

            var result = await mediator.Send(transactions);

            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Get the Transactions
        /// </summary>
        /// <param name="transactionId">The Transactions identifier.</param>
        /// <returns></returns>
        [Route("{transactionId}")]
        [HttpGet]
        public async Task<IActionResult> GetTransactionsById(int transactionId)
        {
            var transactions = new GetTransactionsQuery(transactionId);

            var result = await mediator.Send(transactions);

            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Create the Transactions
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreatePaymentBook([FromBody] CreateTransactionsRequest request)
        {
            var transactions = new CreateTransactionsCommand(request);
            var result = await mediator.Send(transactions);
            return StatusCode((int)result.Code, result.Value);
        }

        #endregion
    }
}
