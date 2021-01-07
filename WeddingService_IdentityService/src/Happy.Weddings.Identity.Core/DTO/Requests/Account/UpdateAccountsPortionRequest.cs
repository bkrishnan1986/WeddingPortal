#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | UpdateAccountsPortionRequest class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

#endregion

namespace Happy.Weddings.Identity.Core.DTO.Requests.Account
{
    /// <summary>
    /// Request class/model for update account portion.
    /// </summary>
    public class UpdateAccountsPortionRequest
    {
        /// <summary>
        /// Gets or sets UserName.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets OldPassword.
        /// </summary>
        public string OldPassword { get; set; }

        /// <summary>
        /// Gets or sets NewPassword.
        /// </summary>
        public string NewPassword { get; set; }

        /// <summary>
        /// Gets or sets UpdatedBy.
        /// </summary>
        public int UpdatedBy { get; set; }
    }
}