#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | UpdateUserProfilePortionRequest class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

#endregion

namespace Happy.Weddings.Identity.Core.DTO.Requests.Profile
{
    /// <summary>
    /// Request/class for update user profile portion.
    /// </summary>
    public class UpdateUserProfilePortionRequest
    {
        /// <summary>
        /// Gets or sets the approval status.
        /// </summary>
        /// <value>
        /// The approval status.
        /// </value>
        public int ApprovalStatus { get; set; }

        /// <summary>
        /// Gets or sets the profile status.
        /// </summary>
        /// <value>
        /// The profile status.
        /// </value>
        public int ProfileStatus { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>
        /// The updated by.
        /// </value>
        public int UpdatedBy { get; set; }
    }
}