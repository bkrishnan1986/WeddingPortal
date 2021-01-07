#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | CreateUserRoleHandler class.
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
using Happy.Weddings.Identity.Service.Commands.v1.UserRole;
using Happy.Weddings.Identity.Core.Entity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

#endregion

namespace Happy.Weddings.Identity.Service.Handlers.v1.UserRole
{
    /// <summary>
    /// Handler for creating user role.
    /// </summary>
    public class CreateUserRoleHandler : IRequestHandler<CreateUserRoleCommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="CreateUserRoleHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public CreateUserRoleHandler(
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
        public async Task<APIResponse> Handle(CreateUserRoleCommand createCommand, CancellationToken cancellationToken)
        {
            try
            {
                var roleRequest = mapper.Map<Rolesettings>(createCommand.Request);
                repository.UserRolesRepository.CreateUserRole(roleRequest);
                await repository.SaveAsync();
                //var profileResponse = mapper.Map<UserProfileOutResponse>(profileRequest);
                return new APIResponse(roleRequest, HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateUserRoleHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
