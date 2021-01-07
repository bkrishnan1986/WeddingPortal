#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  03-Aug-2020 |    REJI SALOOJA B S    | Created and implemented. 
//              |                         | MultiDetailResponse --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Newtonsoft.Json;
using System;

namespace Happy.Weddings.Vendor.Core.DTO.Responses.MultiDetail
{
    /// <summary>
    ///   This class is used to map MultiDetail Response
    /// </summary>
    public class MultiDetailResponse
    {
        /// <summary>
        /// Gets or sets the MultiDetail identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public int MultiCodeId { get; set; }

        /// <summary>
        /// Gets or sets the value.
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
        /// Gets or sets the created by.
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated on.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime UpdatedDate { get; set; }
    }
}
