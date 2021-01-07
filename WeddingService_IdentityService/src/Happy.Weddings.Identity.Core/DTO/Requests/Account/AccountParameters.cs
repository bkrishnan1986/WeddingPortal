#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | AccountParameters class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces


#endregion

namespace Happy.Weddings.Identity.Core.DTO.Requests.Account
{
    /// <summary>
    /// Filters for getting account details.
    /// </summary>
    public class AccountParameters
    {
        /// <summary>
        /// Gets or sets the username keyword.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password keyword.
        /// </summary>
        public string Password { get; set; }
    }
}
