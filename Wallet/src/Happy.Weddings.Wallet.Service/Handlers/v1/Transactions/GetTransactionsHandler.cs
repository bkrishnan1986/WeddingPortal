﻿using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using Happy.Weddings.Wallet.Core.Repository;
using Happy.Weddings.Wallet.Service.Queries.v1.Transactions;
using MediatR;
using Serilog;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.Wallet.Service.Handlers.v1.Transactions
{
    /// <summary>
    /// Handler for getting a Transactions
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.Wallet.Service.Queries.v1.Transactions.GetTransactionsQuery, Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}" />
    public class GetTransactionsHandler : IRequestHandler<GetTransactionsQuery, APIResponse>
    {
        /// <summary>
        /// The repository
        /// </summary>
        private IRepositoryWrapper repository;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetTransactionsHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        public GetTransactionsHandler(
            IRepositoryWrapper repository,
            ILogger logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        public async Task<APIResponse> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var transactions = await repository.Transactions.GetTransactionsById(request.TransactionId);

                if (transactions == null) return new APIResponse(HttpStatusCode.NotFound);

                return new APIResponse(transactions, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetTransactionsHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
