#region Namespaces

using Happy.Weddings.LeadManagement.Core.DTO.Requests.Lead;
using Happy.Weddings.LeadManagement.Core.DTO.Responses;
using MediatR;

#endregion

namespace Happy.Weddings.LeadManagement.Service.Queries.v1.Lead
{
    public class GetAllLeadTotalAmountQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the lead status parameter.
        /// </summary>
        /// <value>
        /// The lead status parameter.
        /// </value>
        public LeadCountTotAmtParameter LeadCountTotAmt { get; set; }
        public string VendorId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllLeadCountQuery"/> class.
        /// </summary>
        /// <param name="leadCountParameter">The lead count parameter.</param>
        /// <param name="leadId">The lead identifier.</param>
        public GetAllLeadTotalAmountQuery(LeadCountTotAmtParameter leadCountTotAmt, string vendorId)
        {
            LeadCountTotAmt = leadCountTotAmt;
            VendorId = vendorId;
        }
    }
}
