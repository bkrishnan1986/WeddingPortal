#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  14-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | Common constants class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

#endregion

namespace Happy.Weddings.Identity.Core.Constants
{
    /// <summary>
    /// 
    /// </summary>
    public class Permission
    {
        /// <summary>
        /// The add
        /// </summary>
        public const string Create = "64";

        /// <summary>
        /// The edit
        /// </summary>
        public const string Edit = "32";

        /// <summary>
        /// The delete
        /// </summary>
        public const string Delete = "16";

        /// <summary>
        /// The view
        /// </summary>
        public const string View = "8";

        /// <summary>
        /// The export
        /// </summary>
        public const string Approve = "4";

        /// <summary>
        /// The import
        /// </summary>
        public const string Authorise = "2";

        /// <summary>
        /// The reports
        /// </summary>
        public const string Reports = "1";


        public const string PemissionMultiCodeId = "test";
    }

    /// <summary>
    /// TokenClaims
    /// </summary>
    public class TokenClaims
    {
        /// <summary>
        /// The user identifier
        /// </summary>
        public const string UserId = "UserIdClaim";

        /// <summary>
        /// The first name
        /// </summary>
        public const string FirstName = "FirstNameClaim";

        /// <summary>
        /// The last name
        /// </summary>
        public const string LastName = "LastNameClaim";

        /// <summary>
        /// The permission/
        /// </summary>
        public const string Permission = "Permission";
    }

    /// <summary>
    /// KYCStatus
    /// </summary>
    public class KYCStatus
    {
        /// <summary>
        /// The verified
        /// </summary>
        public const int Verified = 15;

        /// <summary>
        /// The rejected
        /// </summary>
        public const int Rejected = 16;
    }
}
