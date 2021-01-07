using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Identity.KYCData
{
    /// <summary>
    /// Class for update KYC portion.
    /// </summary>
    public class UpdateKYCPortionRequest
    {
        /// <summary>
        /// Gets or sets the kyc portion data.
        /// </summary>
        /// <value>
        /// The kyc portion datas.
        /// </value>
        public List<KYCPortionData> KYCPortionData { get; set; }
    }

    /// <summary>
    /// KYCPortion class.
    /// </summary>
    public class KYCPortionData
    {
        /// <summary>
        /// Gets or sets the kyc ids.
        /// </summary>
        /// <value>
        /// The kyc ids.
        /// </value>
        public int KycId { get; set; }

        /// <summary>
        /// Gets or sets the kyc status.
        /// </summary>
        /// <value>
        /// The kyc status.
        /// </value>
        public int KYCStatus { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>
        /// The updated by.
        /// </value>
        public int UpdatedBy { get; set; }
    }
}
