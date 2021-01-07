﻿#region File Header

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

namespace Happy.Weddings.Gateway.Core.DTO.ECommerce.Orderreturn
{
    /// <summary>
    /// OrderreturnParameters
    /// </summary>
    /// <seealso cref="Happy.Weddings.Gateway.Core.DTO.QueryStringParameters" />
    public class OrderreturnParameters : QueryStringParameters
    {

        /// <summary>
        /// Gets or sets a value indicating whether this instance is for product.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is for product; otherwise, <c>false</c>.
        /// </value>
        public bool IsForOrderReturn { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether this instance is for cart list.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is for cart list; otherwise, <c>false</c>.
        /// </value>
        public bool IsForOrder { get; set; }




        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public decimal Value { get; set; }
    }

}
