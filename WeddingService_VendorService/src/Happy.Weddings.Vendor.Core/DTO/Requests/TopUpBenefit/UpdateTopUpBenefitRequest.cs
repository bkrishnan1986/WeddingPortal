﻿#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | UpdateTopUpBenefitRequest --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using System;

namespace Happy.Weddings.Vendor.Core.DTO.Requests.TopUpBenefit
{
    /// <summary>
    /// This Class is used to map UpdateTopUpBenefitRequest
    /// </summary>
    public class UpdateTopUpBenefitRequest
    {

        /// <summary>
        /// Gets or sets the top up identifier.
        /// </summary>
        /// <value>
        /// The top up identifier.
        /// </value>
        public int TopUpId { get; set; }

        /// <summary>
        /// Gets or sets the benefit.
        /// </summary>
        /// <value>
        /// The benefit.
        /// </value>
        public int Benefit { get; set; }

        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public int? Count { get; set; }

        /// <summary>
        /// Gets or sets the approval status.
        /// </summary>
        /// <value>
        /// The approval status.
        /// </value>
        public int ApprovalStatus { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>
        /// The updated by.
        /// </value>
        public int? UpdatedBy { get; set; }
    }
}
