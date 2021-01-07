using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Vendor.TopupBenefit
{
    /// <summary>
    /// This Class is used to map CreateTopUpBenefitRequest
    /// </summary>
    public class CreateTopUpBenefitRequest
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
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public int CreatedBy { get; set; }
    }
}
