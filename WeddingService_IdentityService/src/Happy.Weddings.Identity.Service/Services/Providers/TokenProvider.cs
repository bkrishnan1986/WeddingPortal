#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  12-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | TokenProvider class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Happy.Weddings.Identity.Core.Constants;
using Happy.Weddings.Identity.Core.DTO.Responses;
using Happy.Weddings.Identity.Core.Infrastructure;
using System.Security.Cryptography.X509Certificates;
using Happy.Weddings.Identity.Core.Services.Providers;
using Happy.Weddings.Identity.Core.DTO.Responses.Profile;
using Happy.Weddings.Identity.Core.Infrastructure.Authorization;

#endregion

namespace Happy.Weddings.Identity.Service.Services.Providers
{
    /// <summary>
    /// TokenProvider class.
    /// </summary>
    public class TokenProvider : ITokenProvider
    {

        /// <summary>
        /// The configuration manager
        /// </summary>
        private readonly IConfigurationManager configurationManager;

        /// <summary>
        /// The authorization configuration
        /// </summary>
        private readonly AuthorizationConfig authorizationConfig;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="configurationManager"></param>
        /// <param name="authorizationConfig"></param>
        public TokenProvider(
            IConfigurationManager configurationManager,
            AuthorizationConfig authorizationConfig)
        {
            this.configurationManager = configurationManager;
            this.authorizationConfig = authorizationConfig;
        }

        /// <summary>
        /// Method to generate access token.
        /// </summary>
        /// <param name="userProfile"></param>
        /// <returns></returns>
        public async Task<TokenResponse> GetToken(UserProfile userProfile)
        {
            var claims = new[] {
                    new Claim(TokenClaims.UserId, userProfile.Id.ToString()),
                    new Claim(ClaimTypes.Role, userProfile.RoleName.ToString()),
                    new Claim(TokenClaims.FirstName, userProfile.FirstName),
                    new Claim(TokenClaims.LastName, userProfile.LastName),
                    new Claim(TokenClaims.Permission, userProfile.Permission)
                };
            var certificatePath = configurationManager.WebRootPath + authorizationConfig.KeyFilePath;
            var certificate = new X509Certificate2(certificatePath, authorizationConfig.ConvertToUnsecureString
                (authorizationConfig.SigningPassword), X509KeyStorageFlags.EphemeralKeySet);
            var signingKey = new X509SecurityKey(certificate);
            var creds = new SigningCredentials(signingKey, SecurityAlgorithms.RsaSha256);
            var token = new JwtSecurityToken(
                              issuer: authorizationConfig.Issuer,
                              audience: authorizationConfig.Audience,
                              claims: claims,
                              expires: DateTime.Now.AddMinutes(authorizationConfig.TokenExpiryInMinutes),
                              signingCredentials: creds);
            var accessToken = new TokenResponse
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                ExpiresIn = authorizationConfig.SessionInMinutes * 60 * 1000
            };
            return await Task.FromResult(accessToken);
        }
    }
}
