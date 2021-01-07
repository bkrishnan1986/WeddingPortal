using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Identity.KYCData
{
    // <summary>
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
    /// Kyc create form data
    /// </summary>
    public class KYCFormData
    {
        /// <summary>
        /// Gets or sets the kyc datas.
        /// </summary>
        /// <value>
        /// The kyc data.
        /// </value>
        public string KYCData { get; set; }

        /// <summary>
        /// Gets or sets the kyc document.
        /// </summary>
        /// <value>
        /// The kyc document.
        /// </value>
        public IFormFileCollection KycDoc { get; set; }

        /// <summary>
        /// Gets or sets the GST document.
        /// </summary>
        /// <value>
        /// The GST document.
        /// </value>
        public IFormFileCollection GstDoc { get; set; }

        /// <summary>
        /// Gets or sets the proof document.
        /// </summary>
        /// <value>
        /// The proof document.
        /// </value>
        public IFormFileCollection ProofDoc { get; set; }

    }

    /// <summary>
    /// KYCCreateData class.
    /// </summary>
    public class KYCCreateData : KYCDataAttribute
    {

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

    public class KYCDataAttribute
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
        /// Gets or sets the kyc details.
        /// </summary>
        /// <value>
        /// The kyc details.
        /// </value>
        public string KYCDetailString { get; set; }

        /// <summary>
        /// Gets or sets the GST details.
        /// </summary>
        /// <value>
        /// The GST details.
        /// </value>
        public string GSTDetailString { get; set; }

        /// <summary>
        /// Gets or sets the kyc document.
        /// </summary>
        /// <value>
        /// The kyc document.
        /// </value>
        public IFormFileCollection Kycdoc { get; set; }

        /// <summary>
        /// Gets or sets the gstdocument.
        /// </summary>
        /// <value>
        /// The gstdocument.
        /// </value>
        public IFormFileCollection Gstdocument { get; set; }

        /// <summary>
        /// Gets or sets the proofdocument.
        /// </summary>
        /// <value>
        /// The proofdocument.
        /// </value>
        public IFormFileCollection Proofdocument { get; set; }
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
        /// Gets or sets the gstdocument path.
        /// </summary>
        /// <value>
        /// The gstdocument path.
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
