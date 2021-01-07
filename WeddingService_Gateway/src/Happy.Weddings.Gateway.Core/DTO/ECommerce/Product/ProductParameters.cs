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

namespace Happy.Weddings.Gateway.Core.DTO.ECommerce.Product
{
    /// <summary>
    /// This class is used to map MultiDetail Parameters
    /// </summary>
    /// <seealso cref="Happy.Weddings.Vendor.Core.Domain.QueryStringParameters" />
    public class ProductParameters : QueryStringParameters
    {

        /// <summary>
        /// Gets or sets a value indicating whether this instance is for check list.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is for check list; otherwise, <c>false</c>.
        /// </value>
        public bool IsForProduct { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether this instance is for category.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is for category; otherwise, <c>false</c>.
        /// </value>
        public bool IsForCategory { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public decimal Value { get; set; }

        /// <summary>
        /// Gets or sets the approval status.
        /// </summary>
        /// <value>
        /// The approval status.
        /// </value>
        public int ApprovalStatus { get; set; }

        public string SearchKeyword { get; set; }
    }

}
