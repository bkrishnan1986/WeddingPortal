#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | UpdateUserProfileHandler class.
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
using System.Linq;

#endregion

namespace Happy.Weddings.Identity.Service.Handlers.v1.Profile
{
    /// <summary>
    /// Handler for updating user profile.
    /// </summary>
    public class UpdateUserProfileHandler : IRequestHandler<UpdateUserProfileCommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="CreateUserProfileHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public UpdateUserProfileHandler(
            IRepositoryWrapper repository,
            IMapper mapper,
            ILogger logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }
        public async Task<APIResponse> Handle(UpdateUserProfileCommand updateCommand, CancellationToken cancellationToken)
        {
            try
            {
                var profile = await repository.ProfileRepository.GetUserProfileById(updateCommand.Id);
                if (profile == null)
                {
                    return new APIResponse(HttpStatusCode.NotFound);
                }

                var profileRequest = mapper.Map(updateCommand.Request, profile);
                profileRequest.Profilepermission.ToList().ForEach(x =>
                {
                    x.CreatedBy = profileRequest.CreatedBy;
                    x.CreatedAt = profileRequest.CreatedAt;
                    x.RoleId = profileRequest.Role;
                    x.UpdatedBy = profileRequest.UpdatedBy;
                    x.UpdatedAt = DateTime.UtcNow;
                });

                profileRequest.Companydistricts.ToList().ForEach(x =>
                {
                    if (x.Id == 0)
                    {
                        x.CreatedBy = profileRequest.UpdatedBy.GetValueOrDefault();
                        x.CreatedAt = DateTime.UtcNow;
                    }
                    else
                    {
                        x.UpdatedBy = profileRequest.UpdatedBy;
                        x.UpdatedAt = DateTime.UtcNow;
                    }
                });

                if(profile.ApprovalStatus != profileRequest.ApprovalStatus)
                {
                    profileRequest.Profileapprovalstatus.Add(new Core.Entity.Profileapprovalstatus
                    {
                        ProfileId=profile.Id,
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
                        ProfileId = profile.Id,
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
                logger.Error(ex, "Exception in method 'UpdateProfileHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
