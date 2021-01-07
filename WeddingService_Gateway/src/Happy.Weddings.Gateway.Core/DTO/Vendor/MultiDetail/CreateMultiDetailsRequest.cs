#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 03-Aug-2020 | Reji Salooja B S | Created and implemented.
// |                              | CreateMultiDetailsRequest 
//----------------------------------------------------------------------------------------------

#endregion File Header

namespace Happy.Weddings.Gateway.Core.DTO.Vendor.MultiDetail
{
    /// <summary>
    ///  This class is used to map Create MultiDetail Request
    /// </summary>
    public class CreateMultiDetailsRequest
    {
        /// <summary>
        /// Gets or sets the multi code identifier.
        /// </summary>
        /// <value>
        /// The multi code identifier.
        /// </value>
        public int MultiCodeId { get; set; }

        /// <summary>
        /// Gets or sets the Value.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        public int CreatedBy { get; set; }
    }
}
