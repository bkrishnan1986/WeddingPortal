#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  14-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | APIAuthorizeAttribute class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;
using System.Net;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Authorization;
using Happy.Weddings.Identity.Service.Extensions;

#endregion

namespace Happy.Weddings.Identity.API.Filters
{
    /// <summary>
    /// AuthorizeFilter Class.
    /// </summary>
    public class APIAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        /// <summary>
        /// Gets or sets permission.
        /// </summary>
        public string Permission { get; set; }

        /// <summary>
        /// OnAuthorization method.
        /// </summary>
        /// <param name="context"></param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var isAuthorizedUser = false;
            if (!string.IsNullOrWhiteSpace(Permission))
            {
                string permission = this.Permission.ToBinary();
                var accessToken = context.HttpContext.Request.Headers?.FirstOrDefault(x => x.Key == "Authorization").Value;
                if (!string.IsNullOrWhiteSpace(accessToken))
                {
                    var jwtToken = new JwtSecurityToken(accessToken.ToString().Replace("Bearer ", string.Empty));
                    if (jwtToken != null)
                    {
                        var claims = jwtToken.Claims;
                        var userPermission = claims.FirstOrDefault(x => x.Type.Equals("Permission", StringComparison.OrdinalIgnoreCase))?.Value;
                        if (!string.IsNullOrWhiteSpace(userPermission))
                        {
                            string uPermission = userPermission.ToBinary();
                            for (int i = 0; i < permission.Length; i++)
                            {
                                if (permission[i] == '1')
                                {
                                    isAuthorizedUser = uPermission[i] == '1';
                                }
                            }

                        }
                    }
                }
            }

            if(!isAuthorizedUser)
                context.Result = new ContentResult() { StatusCode = (int)HttpStatusCode.Unauthorized };
        }
    }
}
