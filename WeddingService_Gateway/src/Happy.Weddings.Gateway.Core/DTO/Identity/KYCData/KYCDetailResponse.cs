#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  24-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | KYCDetailResponse class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#endregion

namespace Happy.Weddings.Gateway.Core.DTO.Identity.KYCDetail
{
    /// <summary>
    /// GSTDetails
    /// </summary>
    public class GSTDetails
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
        /// Gets or sets the gstnumber.
        /// </summary>
        /// <value>
        /// The gstnumber.
        /// </value>
        public string Gstnumber { get; set; }

        /// <summary>
        /// Gets or sets the gststate.
        /// </summary>
        /// <value>
        /// The gststate.
        /// </value>
        public int Gststate { get; set; }

        /// <summary>
        /// Gets or sets the gststate name.
        /// </summary>
        public string GststateName { get; set; }

        /// <summary>
        /// Gets or sets the gstcity.
        /// </summary>
        /// <value>
        /// The gstcity.
        /// </value>
        public int Gstcity { get; set; }

        /// <summary>
        /// Gets or sets the gstcity name.
        /// </summary>
        public string GstcityName { get; set; }


        /// <summary>
        /// Gets or sets the gstdocument.
        /// </summary>
        /// <value>
        /// The gstdocument.
        /// </value>
        public string Gstdocument { get; set; }

        /// <summary>
        /// Gets or sets the name of the business.
        /// </summary>
        /// <value>
        /// The name of the business.
        /// </value>
        public string BusinessName { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address { get; set; }

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
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>
        /// The created at.
        /// </value>
        public DateTime CreatedAt { get; set; }

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

    /// <summary>
    /// KYCDetails
    /// </summary>
    public class KYCDetails
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
        /// Gets or sets the kycdoc path.
        /// </summary>
        /// <value>
        /// The kycdoc path.
        /// </value>
        public string KycdocPath { get; set; }

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
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>
        /// The created at.
        /// </value>
        public DateTime CreatedAt { get; set; }

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

    public class KYCDetailResponse : KYCDataResponse
    {
        /// <summary>
        /// Gets or sets the kycdetails.
        /// </summary>
        /// <value>
        /// The kycdetails.
        /// </value>
        public List<KYCDetails> Kycdetails { get; set; }


        /// <summary>
        /// Gets or sets the gstdetails.
        /// </summary>
        /// <value>
        /// The gstdetails.
        /// </value>
        public List<GSTDetails> Gstdetails { get; set; }
    }
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
        /// Gets or sets the kycname
        /// </summary>
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
        /// Gets or sets the kycstatus name.
        /// </summary>
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

