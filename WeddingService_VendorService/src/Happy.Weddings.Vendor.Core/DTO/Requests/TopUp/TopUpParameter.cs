#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  22-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | TopUpParameter --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using System;
using Happy.Weddings.Vendor.Core.Domain;

namespace Happy.Weddings.Vendor.Core.DTO.Requests.TopUp
{
    /// <summary>
    /// This Class is used to map TopUp
    /// </summary>
    public class TopUpParameter : QueryStringParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BenefitsParameter"/> class.
        /// </summary>
        public TopUpParameter()
        {
            OrderBy = "Subscription";
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is for single top up.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is for single top up; otherwise, <c>false</c>.
        /// </value>
        public bool IsForSingleTopUp { get; set; }


        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public decimal Value { get; set; }
    }
}


