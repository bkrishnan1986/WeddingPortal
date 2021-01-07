#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  26-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | UpdateKYCPortionRequest class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

#endregion

using System.Collections.Generic;

namespace Happy.Weddings.Identity.Core.DTO.Requests.KYCDetail
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