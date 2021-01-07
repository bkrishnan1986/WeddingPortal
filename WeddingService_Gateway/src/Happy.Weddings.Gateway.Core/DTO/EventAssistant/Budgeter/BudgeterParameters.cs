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

using Happy.Weddings.Gateway.Core.DTO;
using System;

namespace Happy.Weddings.Gateway.Core.DTO.EventAssistant.Budgeter
{
    /// <summary>
    /// This class is used to map MultiDetail Parameters
    /// </summary>
    /// <seealso cref="Happy.Weddings.Vendor.Core.Domain.QueryStringParameters" />
    public class BudgeterParameters : QueryStringParameters
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public decimal Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is for user identifier.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is for user identifier; otherwise, <c>false</c>.
        /// </value>
        public bool IsForUserId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is for budgeter.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is for budgeter; otherwise, <c>false</c>.
        /// </value>
        public bool IsForBudgeter { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is for category.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is for category; otherwise, <c>false</c>.
        /// </value>
        public bool IsForCategory { get; set; }
    }

}
