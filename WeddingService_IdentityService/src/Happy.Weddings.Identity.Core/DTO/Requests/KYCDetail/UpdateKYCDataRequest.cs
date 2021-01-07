#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  26-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | UpdateKYCDataRequest class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

#endregion

using System;
using System.Collections.Generic;

namespace Happy.Weddings.Identity.Core.DTO.Requests.KYCDetail
{
    /// <summary>
    /// Requset class/model for update KYC.
    /// </summary>
    public class UpdateKYCDataRequest
    {
        /// <summary>
        /// Gets or sets the update data.
        /// </summary>
        /// <value>
        /// The update data.
        /// </value>
        public List<KYCUpdateData> UpdateData { get; set; }
    }

    /// <summary>
    /// KYCUpdateData
    /// </summary>
    public class KYCUpdateData
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the kycid.
        /// </summary>
        /// <value>
        /// The kycid.
        /// </value>
        public int Kycid { get; set; }

        /// <summary>
        /// Gets or sets the vendor identifier.
        /// </summary>
        /// <value>
        /// The vendor identifier.
        /// </value>
        public int VendorId { get; set; }

        /// <summary>
        /// Gets or sets the kycstatus.
        /// </summary>
        /// <value>
        /// The kycstatus.
        /// </value>
        public int Kycstatus { get; set; }

        /// <summary>
        /// Gets or sets the name of the father.
        /// </summary>
        /// <value>
        /// The name of the father.
        /// </value>
        public string FatherName { get; set; }

        /// <summary>
        /// Gets or sets the dob.
        /// </summary>
        /// <value>
        /// The dob.
        /// </value>
        public DateTime? Dob { get; set; }

        /// <summary>
        /// Gets or sets the document identifier.
        /// </summary>
        /// <value>
        /// The document identifier.
        /// </value>
        public string DocumentId { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>
        /// The updated by.
        /// </value>
        public int? UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the kyc details.
        /// </summary>
        /// <value>
        /// The kyc details.
        /// </value>
        public List<UpdateKYCDetails> KYCDetails { get; set; }

        /// <summary>
        /// Gets or sets the GST details.
        /// </summary>
        /// <value>
        /// The GST details.
        /// </value>
        public UpdateGSTDetails GSTDetails { get; set; }
    }

    /// <summary>
    /// UpdateKYCDetails
    /// </summary>
    /// <seealso cref="Happy.Weddings.Identity.Core.DTO.Requests.KYCDetail.KYCDetails" />
    public class UpdateKYCDetails : KYCDetails
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
    }

    /// <summary>
    /// UpdateKYCDetails
    /// </summary>
    /// <seealso cref="Happy.Weddings.Identity.Core.DTO.Requests.KYCDetail.GSTDetails" />
    public class UpdateGSTDetails : GSTDetails
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
    }
}