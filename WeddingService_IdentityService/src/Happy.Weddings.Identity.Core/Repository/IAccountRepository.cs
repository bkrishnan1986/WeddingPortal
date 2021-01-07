#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | IAccountRepository interface.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System.Threading.Tasks;
using Happy.Weddings.Identity.Core.DTO.Requests.Account;

#endregion

namespace Happy.Weddings.Identity.Core.Repository
{
    /// <summary>
    /// Repository interface for account operations.
    /// </summary>
    public interface IAccountRepository : IRepositoryBase<Entity.Profile>
    {
        /// <summary>
        /// Gets the login details by identifier.
        /// </summary>
        /// <param name="loginParameters">Login parameters.</param>
        /// <returns></returns>
        Task<Entity.Profile> GetAccountDetails(AccountParameters loginParameters);
    }
}
