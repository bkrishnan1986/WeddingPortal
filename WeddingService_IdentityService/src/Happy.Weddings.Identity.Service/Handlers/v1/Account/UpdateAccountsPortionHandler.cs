#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | UpdateAccountsPortionHandler class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;
using MediatR;
using Serilog;
using AutoMapper;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Happy.Weddings.Identity.Core.Repository;
using Happy.Weddings.Identity.Core.DTO.Responses;
using Happy.Weddings.Identity.Service.Commands.v1.Account;
using Happy.Weddings.Identity.Core.DTO.Requests.Account;

#endregion

namespace Happy.Weddings.Identity.Service.Handlers.v1.Account
{
    /// <summary>
    /// Handler for updating account portion.
    /// </summary>
    public class UpdateAccountsPortionHandler : IRequestHandler<UpdateAccountPortionCommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="UpdateAccountsPortionHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public UpdateAccountsPortionHandler(
            IRepositoryWrapper repository,
            IMapper mapper,
            ILogger logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        /// <summary>
        /// Handler to update login password.
        /// </summary>
        /// <param name="updateCommand"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<APIResponse> Handle(UpdateAccountPortionCommand updateCommand, 
            CancellationToken cancellationToken)
        {
            try
            {
                AccountParameters loginParameters = new AccountParameters
                {
                    Password = updateCommand.Request.OldPassword,
                    UserName = updateCommand.Request.UserName
                };

                var profile = await repository.AccountRepository.GetAccountDetails(loginParameters);
                if (profile == null)
                {
                    return new APIResponse(HttpStatusCode.NotFound);
                }
                profile.Password = updateCommand.Request.NewPassword;
                profile.UpdatedBy = updateCommand.Request.UpdatedBy;
                var profileRequest = mapper.Map(updateCommand.Request, profile);
                repository.ProfileRepository.UpdateUserProfile(profileRequest);

                await repository.SaveAsync();

                return new APIResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateAccountsPortionHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}

