#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 03-Aug-2020 | Reji Salooja B S | Created and implemented.
//                                | MultiDetailParameters 
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.LeadManagement.Core.Domain;
using System;

namespace Happy.Weddings.LeadManagement.Core.DTO.Requests.MultiDetail
{
    /// <summary>
    /// This class is used to map MultiDetail Parameters
    /// </summary>
    /// <seealso cref="QueryStringParameters" />
    public class MultiDetailParameters 
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public int Id { get; set; }
    }
}
