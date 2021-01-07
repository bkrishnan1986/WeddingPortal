#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | DeleteUserProfileHandler class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;
using MediatR;
using Serilog;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Happy.Weddings.Identity.Core.Repository;
using Happy.Weddings.Identity.Core.DTO.Responses;
using Happy.Weddings.Identity.Service.Commands.v1.Profile;
using System.Linq;

#endregion

namespace Happy.Weddings.Identity.Service.Handlers.v1.Profile
{
    /// <summary>
    /// Handler for deleting profile (deactivating profile).
    /// </summary>
    public class DeleteUserProfileHandler:IRequestHandler<DeleteUserProfileCommand,APIResponse>
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
        /// Initializes a new instance of the <see cref="DeleteUserProfileHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        public DeleteUserProfileHandler(
            IRepositoryWrapper repository,
            ILogger logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="deleteCommand">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        public async Task<APIResponse> Handle(DeleteUserProfileCommand deleteCommand, CancellationToken cancellationToken)
        {
            try
            {
                var profile = await repository.ProfileRepository.GetUserProfileById(deleteCommand.Id);
                if (profile == null)
                {
                    return new APIResponse(HttpStatusCode.NotFound);
                }
                profile.Active = 0;
                profile.Profilepermission.ToList().ForEach(x => x.Active = 0);
                profile.Companydistricts.ToList().ForEach(x => x.Active = 0);
                repository.ProfileRepository.UpdateUserProfile(profile);
                await repository.SaveAsync();

                return new APIResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'DeleteProfileHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
