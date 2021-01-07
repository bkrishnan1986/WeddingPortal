using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Vendor.TopupBenefit
{
    /// <summary>
    /// This Class is used to map Benefits Response
    /// </summary>
    public class TopUpBenefitParameter : QueryStringParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BenefitsParameter"/> class.
        /// </summary>
        public TopUpBenefitParameter()
        {
            //OrderBy = "Subscription";
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is for single data.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is for single data; otherwise, <c>false</c>.
        /// </value>
        public bool IsForSingleData { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is for top up.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is for top up; otherwise, <c>false</c>.
        /// </value>
        public bool IsForTopUp { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is for benefit.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is for benefit; otherwise, <c>false</c>.
        /// </value>
        public bool IsForBenefit { get; set; }

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
    }
}
