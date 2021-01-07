#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  24-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | CreateKYCDataRequest class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;
using System.Collections.Generic;

#endregion

namespace Happy.Weddings.Identity.Core.DTO.Requests.KYCDetail
{
    /// <summary>
    /// Request class/model for CreateKYCDataRequest.
    /// </summary>
    public class CreateKYCDataRequest
    {
        /// <summary>
        /// Gets or sets the kyc datas.
        /// </summary>
        /// <value>
        /// The kyc data.
        /// </value>
        public List<KYCCreateData> KYCData { get; set; }
    }

    /// <summary>
    /// KYCCreateData class.
    /// </summary>
    public class KYCCreateData
    {
        /// <summary>
        /// Gets or sets the kycid.
        /// </summary>
        /// <value>
        /// The kycid.
        /// </value>
        public int Kycid { get; set; }

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
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the kyc details.
        /// </summary>
        /// <value>
        /// The kyc details.
        /// </value>
        public List<KYCDetails> KYCDetails { get; set; }

        /// <summary>
        /// Gets or sets the GST details.
        /// </summary>
        /// <value>
        /// The GST details.
        /// </value>
        public List<GSTDetails> GSTDetails { get; set; }
        
    }

    /// <summary>
    /// GSTDetails
    /// </summary>
    public class GSTDetails
    {
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
        /// Gets or sets the gstcity.
        /// </summary>
        /// <value>
        /// The gstcity.
        /// </value>
        public int Gstcity { get; set; }

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
    }

    /// <summary>
    /// KYCDetails
    /// </summary>
    public class KYCDetails
    {
        /// <summary>
        /// Gets or sets the kycdoc path.
        /// </summary>
        /// <value>
        /// The kycdoc path.
        /// </value>
        public string KycdocPath { get; set; }
    }

}

