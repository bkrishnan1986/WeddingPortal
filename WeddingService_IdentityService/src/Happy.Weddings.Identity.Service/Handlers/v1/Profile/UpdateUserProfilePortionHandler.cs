#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | UpdateUserProfilePortionHandler class.
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
using Happy.Weddings.Identity.Core.DTO.Responses;
using Happy.Weddings.Identity.Core.Repository;
using Happy.Weddings.Identity.Service.Commands.v1.Profile;

#endregion

namespace Happy.Weddings.Identity.Service.Handlers.v1.Profile
{
    /// <summary>
    /// Handler for updating user profile portion.
    /// </summary>
    public class UpdateUserProfilePortionHandler : IRequestHandler<UpdateUserProfilePortionCommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="UpdateUserProfilePortionHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public UpdateUserProfilePortionHandler(
            IRepositoryWrapper repository,
            IMapper mapper,
            ILogger logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }
        public async Task<APIResponse> Handle(UpdateUserProfilePortionCommand updateCommand, CancellationToken cancellationToken)
        {
            try
            {
                var profile = await repository.ProfileRepository.GetUserProfileById(updateCommand.Id);
                if (profile == null)
                {
                    return new APIResponse(HttpStatusCode.NotFound);
                }

                var profileRequest = mapper.Map(updateCommand.Request, profile);

                if (profile.ApprovalStatus != profileRequest.ApprovalStatus)
                {
                    profileRequest.Profileapprovalstatus.Add(new Core.Entity.Profileapprovalstatus
                    {
                        ApprovalStatusId = profileRequest.ProfileStatus.GetValueOrDefault(),
                        Date = DateTime.UtcNow,
                        CreatedBy = profileRequest.CreatedBy,
                        CreatedAt = DateTime.UtcNow
                    });
                }

                if (profile.ProfileStatus != profileRequest.ProfileStatus)
                {
                    profileRequest.Profilestatuses.Add(new Core.Entity.Profilestatus
                    {
                        ProfileStatusId = profileRequest.ProfileStatus.GetValueOrDefault(),
                        Date = DateTime.UtcNow,
                        CreatedBy = profileRequest.CreatedBy,
                        CreatedAt = DateTime.UtcNow
                    });
                }

                repository.ProfileRepository.UpdateUserProfile(profileRequest);

                await repository.SaveAsync();

                return new APIResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateUserProfilePortionHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
