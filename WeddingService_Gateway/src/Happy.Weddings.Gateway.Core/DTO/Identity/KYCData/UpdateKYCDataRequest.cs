using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Identity.KYCData
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
    /// KYCCreateData class.
    /// </summary>
    public class KYCUpdateData : KYCDataAttribute
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

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
        public List<UpdateGSTDetails> GSTDetails { get; set; }
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
