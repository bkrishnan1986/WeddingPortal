#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 03-Aug-2020 | Reji Salooja B S | Created and implemented.
//                                | UpdateMultiDetailsRequest 
//----------------------------------------------------------------------------------------------

#endregion File Header

namespace Happy.Weddings.Gateway.Core.DTO.ECommerce.MultiDetail
{
    /// <summary>
    /// This class is used to map UpdateMultiDetailRequest
    /// </summary>
    public class UpdateMultiDetailsRequests
    {
        /// <summary>
        /// Gets or sets the Value.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public short Active { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        public int UpdatedBy { get; set; }
    }
}
