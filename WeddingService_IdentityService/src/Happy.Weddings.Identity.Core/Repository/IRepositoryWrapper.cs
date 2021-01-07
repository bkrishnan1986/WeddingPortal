#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | IRepositoryWrapper interface.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System.Threading.Tasks;

#endregion

namespace Happy.Weddings.Identity.Core.Repository
{
    public interface IRepositoryWrapper
    {
        /// <summary>
        /// RpoleRepository instance
        /// </summary>
        IRoleRepository RoleRepository { get; }

        /// <summary>
        /// ProfileRepository instance
        /// </summary>
        IUserProfileRepository ProfileRepository { get; }

        /// <summary>
        /// Gets the account repository.
        /// </summary>
        /// <value>
        /// The account repository.
        /// </value>
        IAccountRepository AccountRepository { get; }

        /// <summary>
        /// Gets the multicodes.
        /// </summary>
        IMultiCodeRepository MultiCodes { get; }

        /// <summary>
        /// Gets the multidetails.
        /// </summary>
        IMultiDetailRepository MultiDetails { get; }

        /// <summary>
        /// Gets the kyc data repository.
        /// </summary>
        /// <value>
        /// The kyc data repository.
        /// </value>
        IKYCDataRepository KYCDataRepository { get; }

        /// <summary>
        /// Gets the user roles repository.
        /// </summary>
        /// <value>
        /// The user roles repository.
        /// </value>
        IUserRoleRepository UserRolesRepository { get; }

        /// <summary>
        /// Saves the asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<bool> SaveAsync();
    }
}
