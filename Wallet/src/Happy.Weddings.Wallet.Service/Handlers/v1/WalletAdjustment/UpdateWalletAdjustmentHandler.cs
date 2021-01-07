#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS  | Created and implemented. 
//              |                      | UpdateWalletAdjustmentHandler --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using Happy.Weddings.Wallet.Core.Entity;
using Happy.Weddings.Wallet.Core.Repository;
using Happy.Weddings.Wallet.Service.Commands.v1.WalletAdjustment;
using MediatR;
using Serilog;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.Wallet.Service.Handlers.v1.WalletAdjustment
{
    /// <summary>
    /// Handler for updating a WalletAdjustment
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.Wallet.Service.Commands.v1.WalletAdjustment.UpdateWalletAdjustmentCommand, Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}" />
    public class UpdateWalletAdjustmentHandler : IRequestHandler<UpdateWalletAdjustmentCommand, APIResponse>
    {
        /// <summary>
        /// The repository
        /// </summary>
        private IRepositoryWrapper repository;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWalletAdjustmentHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public UpdateWalletAdjustmentHandler(
            IRepositoryWrapper repository,
            IMapper mapper,
            ILogger logger)
        {
            this.repository = repository;
            this.mapper = mapper;
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
        public async Task<APIResponse> Handle(UpdateWalletAdjustmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var WalletAdjustment = await repository.WalletAdjustment.GetWalletAdjustmentById(request.WalletAdjustmentId);

                if (WalletAdjustment == null) return new APIResponse(HttpStatusCode.NotFound);

                var WalletAdjustmentRequest = mapper.Map(request.Request, WalletAdjustment);
                repository.WalletAdjustment.UpdateWalletAdjustment(WalletAdjustmentRequest);

                await repository.SaveAsync();

                return new APIResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateWalletAdjustmentHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
