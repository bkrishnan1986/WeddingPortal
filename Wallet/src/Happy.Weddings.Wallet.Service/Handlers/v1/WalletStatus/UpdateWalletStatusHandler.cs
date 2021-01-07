#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS  | Created and implemented. 
//              |                      | UpdateWalletStatusHandler --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using Happy.Weddings.Wallet.Core.Entity;
using Happy.Weddings.Wallet.Core.Repository;
using Happy.Weddings.Wallet.Service.Commands.v1.WalletStatus;
using MediatR;
using Serilog;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.Wallet.Service.Handlers.v1.WalletStatus
{
    /// <summary>
    /// Handler for updating a Wallet Status
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.Wallet.Service.Commands.v1.WalletStatus.UpdateWalletStatusCommand, Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}" />
    public class UpdateWalletStatusHandler : IRequestHandler<UpdateWalletStatusCommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="UpdateWalletStatusHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public UpdateWalletStatusHandler(
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
        public async Task<APIResponse> Handle(UpdateWalletStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var WalletStatus = await repository.WalletStatus.GetWalletStatusById(request.WalletStatusId);

                if (WalletStatus == null) return new APIResponse(HttpStatusCode.NotFound);

                var WalletStatusRequest = mapper.Map(request.Request, WalletStatus);
                repository.WalletStatus.UpdateWalletStatus(WalletStatusRequest);

                await repository.SaveAsync();

                return new APIResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateWalletStatusHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
