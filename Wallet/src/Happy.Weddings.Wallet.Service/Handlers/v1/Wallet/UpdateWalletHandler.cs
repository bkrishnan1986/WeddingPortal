
#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS  | Created and implemented. 
//              |                      | UpdateWalletHandler --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using Happy.Weddings.Wallet.Core.Entity;
using Happy.Weddings.Wallet.Core.Repository;
using Happy.Weddings.Wallet.Service.Commands.v1.Wallet;
using MediatR;
using Serilog;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.Wallet.Service.Handlers.v1.Wallet
{
    /// <summary>
    /// Handler for updating a Wallet
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.Wallet.Service.Commands.v1.Wallet.UpdateWalletCommand, Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}" />
    public class UpdateWalletHandler : IRequestHandler<UpdateWalletCommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="UpdateWalletHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public UpdateWalletHandler(
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
        public async Task<APIResponse> Handle(UpdateWalletCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var Wallet = await repository.Wallets.GetWalletById(request.WalletId);

                if (Wallet == null) return new APIResponse(HttpStatusCode.NotFound);

                int OldStatusId = Wallet.Status;

                if (request.IsPaused == true || request.IsReleased == true || request.IsChurned == true)
                {
                    string status = string.Empty;

                    if (request.IsPaused) status = "PAUSED";
                    else if (request.IsReleased) status = "RELEASED";
                    else if (request.IsChurned) status = "CHURNED";

                    var WalletStatus = await repository.MultiDetails.GetMultiDetailsByCode("WALLET STATUS");

                    if (WalletStatus != null && WalletStatus.Count > 0)
                    {
                        foreach (var type in WalletStatus)
                        {
                            if (type.Value.ToUpper() == status)
                            {
                                Wallet.Status = type.Id;
                                break;
                            }
                        }
                    }

                    if (Wallet.Status != OldStatusId)
                    {
                        Walletstatus walletstatus = new Walletstatus();
                        walletstatus.WalletId = Wallet.Id;
                        walletstatus.Action = "WALLET " + status;
                        walletstatus.Status = Wallet.Status;
                        walletstatus.Reason = "WALLET UPDATED - " + status;
                        walletstatus.StatusDate = DateTime.UtcNow;
                        walletstatus.Active = 1;
                        walletstatus.CreatedBy = request.Request.UpdatedBy;
                        walletstatus.CreatedAt = DateTime.UtcNow;
                        repository.Wallets.UpdateWallet(Wallet);
                        repository.WalletStatus.CreateWalletStatus(walletstatus);
                    }
                }
                else
                {
                    var WalletRequest = mapper.Map(request.Request, Wallet);

                    if (WalletRequest.Status != OldStatusId)
                    {
                        Walletstatus walletstatus = new Walletstatus();
                        walletstatus.WalletId = WalletRequest.Id;
                        walletstatus.Action = "Status Updated";
                        walletstatus.Status = WalletRequest.Status;
                        walletstatus.Reason = "Status Updated";
                        walletstatus.StatusDate = DateTime.UtcNow;
                        walletstatus.Active = 1;
                        walletstatus.CreatedBy = WalletRequest.CreatedBy;
                        walletstatus.CreatedAt = DateTime.UtcNow;
                        repository.WalletStatus.CreateWalletStatus(walletstatus);
                    }

                    repository.Wallets.UpdateWallet(WalletRequest);
                }

                await repository.SaveAsync();

                return new APIResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateWalletHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
