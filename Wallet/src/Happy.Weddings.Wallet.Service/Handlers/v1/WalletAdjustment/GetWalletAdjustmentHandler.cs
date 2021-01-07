#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | GetWalletAdjustmentHandler --class
//----------------------------------------------------------------------------------------------

#endregion 

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using Happy.Weddings.Wallet.Core.Repository;
using Happy.Weddings.Wallet.Service.Queries.v1.WalletAdjustment;
using MediatR;
using Serilog;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.Wallet.Service.Handlers.v1.WalletAdjustment
{
    /// <summary>
    /// Handler for getting a WalletAdjustment
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.Wallet.Service.Queries.v1.WalletAdjustment.GetWalletAdjustmentQuery, Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}" />
    public class GetWalletAdjustmentHandler : IRequestHandler<GetWalletAdjustmentQuery, APIResponse>
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
        /// Initializes a new instance of the <see cref="GetWalletAdjustmentHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        public GetWalletAdjustmentHandler(
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
        public async Task<APIResponse> Handle(GetWalletAdjustmentQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var walletAdjustment = await repository.WalletAdjustment.GetWalletAdjustmentsById(request.WalletAdjustmentId);

                if (walletAdjustment == null) return new APIResponse(HttpStatusCode.NotFound);

                return new APIResponse(walletAdjustment, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetWalletAdjustmentHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
