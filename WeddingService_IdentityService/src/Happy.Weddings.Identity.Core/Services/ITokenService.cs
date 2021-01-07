#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  12-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | ITokenService interface.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System.Threading.Tasks;
using Happy.Weddings.Identity.Core.DTO.Responses;
using Happy.Weddings.Identity.Core.DTO.Responses.Profile;

#endregion

namespace Happy.Weddings.Identity.Core.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// Generate token method.
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        Task<TokenResponse> GenerateToken(UserProfile profile);
    }
}
