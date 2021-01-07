#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  25-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | GetWalletHandler --class
//----------------------------------------------------------------------------------------------

#endregion 

using Happy.Weddings.Wallet.Core.DTO.Responses;
using Happy.Weddings.Wallet.Core.Repository;
using Happy.Weddings.Wallet.Service.Queries.v1.Wallet;
using MediatR;
using Serilog;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.Wallet.Service.Handlers.v1.Wallet
{
    /// <summary>
    /// Handler for getting a Wallets
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.Wallet.Service.Queries.v1.Wallet.GetWalletQuery, Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}" />
    public class GetWalletHandler : IRequestHandler<GetWalletQuery, APIResponse>
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
        /// Initializes a new instance of the <see cref="GetWalletHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        public GetWalletHandler(
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
        public async Task<APIResponse> Handle(GetWalletQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var wallet = await repository.Wallets.GetWalletsById(request.WalletId);

                if (wallet == null) return new APIResponse(HttpStatusCode.NotFound);

                return new APIResponse(wallet, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetWalletHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}

