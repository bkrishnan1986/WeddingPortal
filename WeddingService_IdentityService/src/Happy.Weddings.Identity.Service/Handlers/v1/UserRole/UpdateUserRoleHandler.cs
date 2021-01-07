#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | UpdateUserRoleHandler class.
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
using Happy.Weddings.Identity.Service.Commands.v1.UserRole;

#endregion

namespace Happy.Weddings.Identity.Service.Handlers.v1.Profile
{
    /// <summary>
    /// Handler for updating user role.
    /// </summary>
    public class UpdateUserRoleHandler : IRequestHandler<UpdateUserRoleCommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="UpdateUserRoleHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public UpdateUserRoleHandler(
            IRepositoryWrapper repository,
            IMapper mapper,
            ILogger logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }
        public async Task<APIResponse> Handle(UpdateUserRoleCommand updateCommand, CancellationToken cancellationToken)
        {
            try
            {
                var roleData = await repository.UserRolesRepository.GetUserRole(updateCommand.Id);
                if (roleData == null)
                {
                    return new APIResponse(HttpStatusCode.NotFound);
                }

                var roleRequest = mapper.Map(updateCommand.Request, roleData);

                repository.UserRolesRepository.UpdateUserRole(roleRequest);

                await repository.SaveAsync();

                return new APIResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateUserRoleHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
