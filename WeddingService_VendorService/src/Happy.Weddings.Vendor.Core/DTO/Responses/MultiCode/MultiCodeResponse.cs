#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  03-Aug-2020 |    REJI SALOOJA B S    | Created and implemented. 
//              |                         | MultiCodeResponse --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Happy.Weddings.Vendor.Core.DTO.Responses.MultiCode
{
    /// <summary>
    /// This class is used to map MultiCode Response
    /// </summary>
    public class MultiCodeResponse
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the SystemCode.
        /// </summary>
        /// <value>
        /// The SystemCode.
        /// </value>
        public string SystemCode { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets IsRequired.
        /// </summary>
        /// <value>
        /// The IsRequired.
        /// </value>
        public short IsRequired { get; set; }

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

        public virtual ICollection<Multidetail> Multidetail { get; set; }
    }
}
