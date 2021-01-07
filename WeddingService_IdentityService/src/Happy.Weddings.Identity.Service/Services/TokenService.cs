#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  12-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | TokenService class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System.Threading.Tasks;
using Happy.Weddings.Identity.Core.Services;
using Happy.Weddings.Identity.Core.DTO.Responses;
using Happy.Weddings.Identity.Core.Services.Providers;
using Happy.Weddings.Identity.Core.DTO.Responses.Profile;
using Happy.Weddings.Identity.Core.Infrastructure.Authorization;

#endregion

namespace Happy.Weddings.Identity.Service.Services
{
    public class TokenService : ITokenService
    {
        /// <summary>
        /// The token provider
        /// </summary>
        private readonly ITokenProvider tokenProvider;

        /// <summary>
        /// The authirization config.
        /// </summary>
        private readonly AuthorizationConfig authorizationConfig;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="tokenProvider"></param>
        /// <param name="authorizationConfig"></param>
        public TokenService(ITokenProvider tokenProvider,
            AuthorizationConfig authorizationConfig)
        {
            this.authorizationConfig = authorizationConfig;
            this.tokenProvider = tokenProvider;
        }

        /// <summary>
        /// Generate token method.
        /// </summary>
        /// <param name="userProfile"></param>
        /// <returns></returns>
        public async Task<TokenResponse> GenerateToken(UserProfile userProfile)
        {
            var token = await tokenProvider.GetToken(userProfile);
            return token;
        }
    }
}
