#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | GetVendorSubscriptionQuery --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.TopUpBenefits
{
    /// <summary>
    /// Query for getting a TopUpBenefits
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}}" />
    public class GetTopUpBenefitQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the TopUpBenefits identifier.
        /// </summary>
        public int TopupBenefitId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetTopUpBenefitQuery"/> class.
        /// </summary>
        /// <param name="topupBenefitId">The TopUpBenefits identifier.</param>
        public GetTopUpBenefitQuery(int topupBenefitId)
        {
            TopupBenefitId = topupBenefitId;
        }
    }
}
