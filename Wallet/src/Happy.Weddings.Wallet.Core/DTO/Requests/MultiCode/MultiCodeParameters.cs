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

#endregion

using Happy.Weddings.Wallet.Core.Domain;
using System;

namespace Happy.Weddings.Wallet.Core.DTO.Requests.MultiCode
{
    /// <summary>
    ///  This class is used to map MultiCode Parameters
    /// </summary>
    /// <seealso cref="Happy.Weddings.Wallet.Core.Domain.QueryStringParameters" />
    public class MultiCodeParameters
    {
        /// <summary>
        /// Gets or sets the Code.
        /// </summary>
        /// <value>
        /// The Code.
        /// </value>
        public string Code { get; set; }
    }
}
