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

using Happy.Weddings.Vendor.Core.Domain;
using System;

namespace Happy.Weddings.Vendor.Core.DTO.Requests.MultiCode
{
    /// <summary>
    ///  This class is used to map MultiCode Parameters
    /// </summary>
    /// <seealso cref="Happy.Weddings.Vendor.Core.Domain.QueryStringParameters" />
    public class MultiCodeParameters 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiCodeParameters" /> class.
        /// </summary>
        
        /// <value>
        /// The code.
        /// </value>  
        public string Code { get; set; }
    }
}
