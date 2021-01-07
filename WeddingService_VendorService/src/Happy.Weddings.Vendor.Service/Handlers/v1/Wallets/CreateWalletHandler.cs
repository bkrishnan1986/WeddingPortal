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

#endregion File Header
using AutoMapper;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using Happy.Weddings.Vendor.Core.Entity;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Service.Commands.v1.Wallet;
using MediatR;
using Serilog;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Service.Handlers.v1.Wallets
{
    /// <summary>
    /// Handler for creating a SubscriptionBenefits
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.Vendor.Service.v1.Commands.CreateStoryCommand, Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
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
        /// Initializes a new instance of the <see cref="CreateStoryHandler" /> class.
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
                var walletRequest = mapper.Map<Wallet>(request.Request);

                //TODO : 26/08/2020

                var walletDetails = await repository.Wallets.GetWalletByVendorId(walletRequest.VendorId);
                if(walletDetails == null)
                {
                    if(walletRequest.TransactionType ==18)
                    {
                        walletRequest.Balance = walletRequest.Amount;
                        repository.Wallets.CreateWallet(walletRequest);
                        await repository.SaveAsync();
                        return new APIResponse(walletRequest, HttpStatusCode.Created);
                    }
                    else
                    {
                        return new APIResponse(HttpStatusCode.NotAcceptable);
                    }
        
                }
                else
                {
                    decimal walletBalance = 0;
                    walletBalance = walletDetails.Balance;
                    if (walletRequest.TransactionType == 19)
                    {
                        if(walletBalance>walletRequest.Amount)
                        {
                            walletRequest.Balance = walletBalance - walletRequest.Amount;
                        }
                        else
                        {
                            return new APIResponse(HttpStatusCode.NotAcceptable);
                        }
             
                    }
                    else if (walletRequest.TransactionType == 18)
                    {
                        walletRequest.Balance = walletBalance + walletRequest.Amount;
                    }
                    repository.Wallets.CreateWallet(walletRequest);
                    await repository.SaveAsync();
                    return new APIResponse(walletRequest, HttpStatusCode.Created);
                }
         
                // return null;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreatesubscriptionBenefitHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
