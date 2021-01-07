#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | UpdateBenefitRequest
//----------------------------------------------------------------------------------------------

#endregion File Header

namespace Happy.Weddings.Vendor.Core.DTO.Requests.Benefits
{
    /// <summary>
    /// This Class is used to map Update Benefit Request 
    /// </summary>
    public class UpdateBenefitRequest
    {
        /// <summary>
        /// Gets or sets the benefit.
        /// </summary>
        /// <value>
        /// The benefit.
        /// </value>
        public string Benefit { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public decimal Value { get; set; }

        /// <summary>
        /// Gets or sets the benefit unit.
        /// </summary>
        /// <value>
        /// The benefit unit.
        /// </value>
        public int BenefitUnit { get; set; }

        /// <summary>
        /// Gets or sets the Updated by.
        /// </summary>
        public int UpdatedBy { get; set; }
    }
}
