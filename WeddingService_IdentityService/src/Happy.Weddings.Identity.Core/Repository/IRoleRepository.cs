#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | IRoleRepository interface.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System.Threading.Tasks;
using Happy.Weddings.Identity.Core.Domain;
using Happy.Weddings.Identity.Core.Entity;
using Happy.Weddings.Identity.Core.DTO.Requests.Role;
using System.Collections.Generic;

#endregion

namespace Happy.Weddings.Identity.Core.Repository
{
    /// <summary>
    /// Repository interface for role operations.
    /// </summary>
    public interface IRoleRepository : IRepositoryBase<Profilepermission>
    {
        /// <summary>
        /// Gets the role settings by profile identifier.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <returns></returns>
        Task<Profilepermission> GetUserPermissonsByProfileId(int profileId);
    }
}
