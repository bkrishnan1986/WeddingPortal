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

using Happy.Weddings.Gateway.Core.DTO;
using System;

namespace Happy.Weddings.Gateway.Core.DTO.Vendor.MultiCode
{
    /// <summary>
    ///  This class is used to map MultiCode Parameters
    /// </summary>
    /// <seealso cref="Happy.Weddings.Vendor.Core.Domain.QueryStringParameters" />
    public class MultiCodeParameters 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiCodeParameters"/> class.
        /// </summary>

        /// <summary>
        /// Gets or sets the Code.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Code { get; set; }
    }
}
