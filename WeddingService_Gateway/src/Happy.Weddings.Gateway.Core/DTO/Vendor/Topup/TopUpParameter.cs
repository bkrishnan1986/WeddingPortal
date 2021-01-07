using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Vendor.Topup
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
            //OrderBy = "Subscription";
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
