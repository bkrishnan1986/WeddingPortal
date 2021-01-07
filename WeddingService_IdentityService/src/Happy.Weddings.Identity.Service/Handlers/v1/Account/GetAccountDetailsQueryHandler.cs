#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | Handler class for getting account details.
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
using Happy.Weddings.Identity.Service.Queries.v1.Account;
using Happy.Weddings.Identity.Service.Extensions;
using Happy.Weddings.Identity.Core.Services.Providers;
using Happy.Weddings.Identity.Core.DTO.Responses.Profile;
using AutoMapper;
using Happy.Weddings.Identity.Core.Entity;
using Happy.Weddings.Identity.Core.Constants;
using System.Linq;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

#endregion

namespace Happy.Weddings.Identity.Service.Handlers.v1.Account
{
    /// <summary>
    /// Handler for getting login details.
    /// </summary>
    public class GetAccountDetailsQueryHandler : IRequestHandler<GetAccountDetailsQuery, APIResponse>
    {
        /// <summary>
        /// The repository
        /// </summary>
        private IRepositoryWrapper repository;

        private ITokenProvider tokenProvider;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger logger;

        private IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAccountDetailsQueryHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        public GetAccountDetailsQueryHandler(
            IRepositoryWrapper repository,
            ILogger logger,
            ITokenProvider tokenProvider,
            IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.tokenProvider = tokenProvider;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="getAccountQuery">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        public async Task<APIResponse> Handle(GetAccountDetailsQuery getAccountQuery, CancellationToken cancellationToken)
        {
            try
            {
                var profile = await repository.AccountRepository.GetAccountDetails(getAccountQuery.AccountParameters);
                if (null == profile)
                {
                    return new APIResponse(HttpStatusCode.NotFound);
                }
                var role = await repository.MultiDetails.GetMultiDetailByMultiDetailId(profile.Role);
                var RolePermissions = await repository.MultiDetails.GetMultiDetailsByCode(Permission.PemissionMultiCodeId);
                var permissions = RolePermissions.ToList().Select(x => x.Value).ToList();
                var roleData = profile.Profilepermission.FirstOrDefault().ProfilePermissions;
                var permissionDic = new Dictionary<string, int>();
                if (!string.IsNullOrEmpty(roleData))
                {
                    var roleObject = JObject.Parse(roleData);
                    foreach (var permission in permissions)
                    {
                        Int32.TryParse(roleObject[permission].ToString(), out int userRole);
                        permissionDic.Add(permission, userRole);
                    }
                }
                
                var permissionBinary = string.Join("", permissionDic.Select(x => x.Value).ToList()).ToDecimal();
                var userProfile = mapper.Map<UserProfile>(profile);
                userProfile.RoleName = role.Value;
                userProfile.Permission = permissionBinary.ToString();
                //userProfile.Permission = GetRolePermission(roleData);

                var token = await tokenProvider.GetToken(userProfile);
                return new APIResponse(token, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetAllProfilesHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        //private int GetRolePermission(string rolesettings)
        //{
        //    string permission = rolesettings.ProfilePermissions;
        //    string roleBinary = $"{rolesettings.Create ?? 0}{rolesettings.Edit ?? 0}" +
        //        $"{rolesettings.Delete ?? 0}{rolesettings.View ?? 0}{rolesettings.Approve ?? 0}{rolesettings.Authorise ?? 0}{rolesettings.Reports ?? 0}";
        //    return roleBinary.ToDecimal();
        //}
    }
}
