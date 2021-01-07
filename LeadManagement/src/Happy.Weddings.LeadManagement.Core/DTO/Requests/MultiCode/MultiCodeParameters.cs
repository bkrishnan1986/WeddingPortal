#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  03-Aug-2020 |    Reji Salooja B S    | Created and implemented. 
//              |                         | MultiCodeParameters
//----------------------------------------------------------------------------------------------

#endregion File Header

using System;
using Happy.Weddings.LeadManagement.Core.Domain;

namespace Happy.Weddings.LeadManagement.Core.DTO.Requests.MultiCode
{
    /// <summary>
    ///  This class is used to map MultiCode Parameters
    /// </summary>
    /// <seealso cref="QueryStringParameters" />
    public class MultiCodeParameters
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Code { get; set; }
    }
}
