#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | CreateWalletRuleHandler --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using Happy.Weddings.Wallet.Core.Entity;
using Happy.Weddings.Wallet.Core.Repository;
using Happy.Weddings.Wallet.Service.Commands.v1.WalletRule;
using MediatR;
using Serilog;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.Wallet.Service.Handlers.v1.WalletRule
{
    /// <summary>
    /// Handler for creating a WalletRule
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.Wallet.Service.Commands.v1.WalletRule.CreateWalletRuleCommand, Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}" />
    public class CreateWalletRuleHandler : IRequestHandler<CreateWalletRuleCommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="CreateWalletRuleHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public CreateWalletRuleHandler(
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
        public async Task<APIResponse> Handle(CreateWalletRuleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var walletRuleRequest = mapper.Map<Walletrule>(request.Request);

                Core.DTO.Requests.WalletRule.WalletRuleParameter WP = new Core.DTO.Requests.WalletRule.WalletRuleParameter();
                WP.Value = walletRuleRequest.ServiceCategoryId;
                WP.IsForServiceCategory = true;
                var walletRule = await repository.WalletRule.GetAllWalletRule(WP);

                if(walletRule == null || walletRule.Count == 0)
                {
                    repository.WalletRule.CreateWalletRule(walletRuleRequest);
                    await repository.SaveAsync();

                    return new APIResponse(walletRuleRequest, HttpStatusCode.Created);
                }
                else
                {
                    return new APIResponse(HttpStatusCode.NoContent);
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateWalletRuleHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
