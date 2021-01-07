using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.VendorQuestionAnswer
{
    public class GetAllVendorQuestionAnswersByIdQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the question identifier.
        /// </summary>
        /// <value>
        /// The question identifier.
        /// </value>
        public string VendorLeadId { get; set; }
        public bool IsForVendor { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllVendorQuestionAnswersByIdQuery"/> class.
        /// </summary>
        /// <param name="vendorleadId">The question identifier.</param>
        public GetAllVendorQuestionAnswersByIdQuery(string vendorleadId, bool isForVendor)
        {
            VendorLeadId = vendorleadId;
            IsForVendor = isForVendor;
        }
    }
}
