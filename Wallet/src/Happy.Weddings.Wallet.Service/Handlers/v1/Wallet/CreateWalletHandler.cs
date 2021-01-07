#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  25-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | CreateWalletHandler --class
//----------------------------------------------------------------------------------------------

#endregion

using AutoMapper;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using Happy.Weddings.Wallet.Core.DTO.Responses.Wallet;
using Happy.Weddings.Wallet.Core.Entity;
using Happy.Weddings.Wallet.Core.Repository;
using Happy.Weddings.Wallet.Service.Commands.v1.Wallet;
using MediatR;
using Serilog;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.Wallet.Service.Handlers.v1.Wallet
{
    /// <summary>
    /// Handler for creating a Wallet
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.Wallet.Service.Commands.v1.Wallet.CreateWalletCommand, Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}" />
    public class CreateWalletHandler : IRequestHandler<CreateWalletCommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="CreateWalletHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public CreateWalletHandler(
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
        public async Task<APIResponse> Handle(CreateWalletCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var walletRequest = mapper.Map<Wallets>(request.Request);
                repository.Wallets.CreateWallet(walletRequest);
                await repository.SaveAsync();

                Walletstatus walletstatus = new Walletstatus();
                walletstatus.WalletId = walletRequest.Id;
                walletstatus.Action = "Wallet Created";
                walletstatus.Status = walletRequest.Status;
                walletstatus.Reason = "Wallet Created";
                walletstatus.StatusDate = DateTime.UtcNow;
                walletstatus.Active = 1;
                walletstatus.CreatedBy = walletRequest.CreatedBy;
                walletstatus.CreatedAt = DateTime.UtcNow;
                repository.WalletStatus.CreateWalletStatus(walletstatus);
                await repository.SaveAsync();

                return new APIResponse(new WalletDetails { WalletId = walletRequest.Id, WalletStatusId = walletstatus.Id }, HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateWalletHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
