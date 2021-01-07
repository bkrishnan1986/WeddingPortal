#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | CreateUserProfileHandler class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using MediatR;
using Serilog;
using System;
using System.Net;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Happy.Weddings.Identity.Core.Repository;
using Happy.Weddings.Identity.Core.DTO.Responses;
using Happy.Weddings.Identity.Service.Commands.v1.Profile;
using Happy.Weddings.Identity.Core.DTO.Responses.Profile;
using AutoMapper.Internal;
using System.Linq;
using Happy.Weddings.Identity.Core.DTO.Requests.Profile;
using Happy.Weddings.Identity.Service.Helpers;

#endregion

namespace Happy.Weddings.Identity.Service.Handlers.v1.Profile
{
    /// <summary>
    /// Handler for creating user profile.
    /// </summary>
    public class CreateUserProfileHandler : IRequestHandler<CreateUserProfileCommand, APIResponse>
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
        public CreateUserProfileHandler(
            IRepositoryWrapper repository,
            IMapper mapper,
            ILogger logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        /// <summary>
        /// Handle method for create profile.
        /// </summary>
        /// <param name="createCommand"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<APIResponse> Handle(CreateUserProfileCommand createCommand, CancellationToken cancellationToken)
        {
            try
            {
                var profileRequest = mapper.Map<Core.Entity.Profile>(createCommand.Request);
                profileRequest.Password = RandomPasswordGenerator.GeneratePassword(true, true, true, true, 8);
                profileRequest.UserName = profileRequest.Email;

                profileRequest.Profilepermission?.ToList().ForEach(x =>
                {
                    x.CreatedBy = profileRequest.CreatedBy;
                    x.RoleId = profileRequest.Role;
                });

                profileRequest.Profileapprovalstatus?.ToList().ForEach(x =>
                {
                    x.Date = DateTime.UtcNow;
                    x.CreatedBy = profileRequest.CreatedBy;
                    x.CreatedAt = DateTime.UtcNow;
                });

                profileRequest.Profilestatuses?.ToList().ForEach(x =>
                {
                    x.Date = DateTime.UtcNow;
                    x.CreatedBy = profileRequest.CreatedBy;
                    x.CreatedAt = DateTime.UtcNow;
                });

                profileRequest.Companydistricts?.ToList().ForEach(x =>
                {
                    x.CreatedBy = profileRequest.CreatedBy;
                });

                repository.ProfileRepository.CreateUserProfile(profileRequest);
                await repository.SaveAsync();
                return new APIResponse(new UserIdDetails { ProfileId = profileRequest.Id, UserId = profileRequest.UserId }, HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateProfileHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
