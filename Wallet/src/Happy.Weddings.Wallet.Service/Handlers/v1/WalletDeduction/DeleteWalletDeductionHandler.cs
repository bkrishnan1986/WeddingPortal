﻿#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS  | Created and implemented. 
//              |                      | DeleteWalletDeductionHandler --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.Repository;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using Happy.Weddings.Wallet.Service.Commands.v1.WalletDeduction;
using MediatR;
using Serilog;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.Wallet.Service.Handlers.v1.WalletDeduction
{
    /// <summary>
    /// Handler for Deleting a WalletDeduction
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.Wallet.Service.Commands.v1.WalletDeduction.DeleteWalletDeductionCommand, Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}" />
    public class DeleteWalletDeductionHandler : IRequestHandler<DeleteWalletDeductionCommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="DeleteWalletDeductionHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        public DeleteWalletDeductionHandler(
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
        public async Task<APIResponse> Handle(DeleteWalletDeductionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var walletDeduction = await repository.WalletDeduction.GetWalletDeductionById(request.WalletDeductionId);

                if (walletDeduction == null) return new APIResponse(HttpStatusCode.NotFound);

                walletDeduction.Active = 0;
                repository.WalletDeduction.UpdateWalletDeduction(walletDeduction);
                await repository.SaveAsync();

                return new APIResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'DeleteWalletDeductionHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
