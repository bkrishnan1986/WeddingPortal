#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | GetUserRoleHandler class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;
using MediatR;
using Serilog;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Happy.Weddings.Identity.Core.DTO.Responses;
using Happy.Weddings.Identity.Core.Repository;
using Happy.Weddings.Identity.Service.Queries.v1.Profile;
using Happy.Weddings.Identity.Service.Queries.v1.UserRole;

#endregion

namespace Happy.Weddings.Identity.Service.Handlers.v1.Profile
{
    /// <summary>
    /// Handler for getting a role.
    /// </summary>
    public class GetUserRoleHandler : IRequestHandler<GetUserRoleQuery, APIResponse>
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
        /// Initializes a new instance of the <see cref="GetUserRoleHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        public GetUserRoleHandler(
            IRepositoryWrapper repository,
            ILogger logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        /// <summary>
        /// Handles the specified get role query.
        /// </summary>
        /// <param name="getRoleQuery">The get role query.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<APIResponse> Handle(GetUserRoleQuery getRoleQuery, CancellationToken cancellationToken)
        {
            try
            {
                var roleData = await repository.UserRolesRepository.GetUserRole(getRoleQuery.Id);
                if (roleData == null)
                {
                    return new APIResponse(HttpStatusCode.NotFound);
                }

                return new APIResponse(roleData, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetUserRoleHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
