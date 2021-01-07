#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  24-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | KYCDataResponse class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;

#endregion

namespace Happy.Weddings.Identity.Core.DTO.Responses.KYCDetail
{
    /// <summary>
    /// KYCResponse class.
    /// </summary>
    public class KYCDataResponse
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
        /// Gets or sets the name of the kyc.
        /// </summary>
        /// <value>
        /// The name of the kyc.
        /// </value>
        public string KycName { get; set; }

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
        /// Gets or sets the name of the kyc status.
        /// </summary>
        /// <value>
        /// The name of the kyc status.
        /// </value>
        public string KycStatusName { get; set; }

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
        /// Gets or sets the active.
        /// </summary>
        /// <value>
        /// The active.
        /// </value>
        public short Active { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public int? CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>
        /// The created at.
        /// </value>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>
        /// The updated by.
        /// </value>
        public int? UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated at.
        /// </summary>
        /// <value>
        /// The updated at.
        /// </value>
        public DateTime? UpdatedAt { get; set; }
    }
}
