using System;
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
    /// Handler for getting all Transactions
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.Wallet.Service.Queries.v1.Transactions.GetAllTransactionsQuery, Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}" />
    public class GetAllTransactionsHandler : IRequestHandler<GetAllTransactionsQuery, APIResponse>
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
        /// Initializes a new instance of the <see cref="GetAllTransactionsHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        public GetAllTransactionsHandler(
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
        public async Task<APIResponse> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.TransactionsParameter.IsForVendor)
                {
                    Core.DTO.Requests.Wallet.WalletsParameter WP = new Core.DTO.Requests.Wallet.WalletsParameter();
                    WP.VendorId = request.TransactionsParameter.Value;
                    var walletResponse = await repository.Wallets.GetAllWallets(WP);

                    if (walletResponse != null && walletResponse.Count > 0) request.TransactionsParameter.Value = walletResponse[0].Id;
                }

                var transactions = await repository.Transactions.GetAllTransactions(request.TransactionsParameter);
                return new APIResponse(transactions, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetAllTransactionsHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
