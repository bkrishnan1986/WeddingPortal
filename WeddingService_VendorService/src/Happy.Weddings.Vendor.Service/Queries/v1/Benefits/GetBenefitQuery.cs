#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | GetBenefitsQuery --class
//----------------------------------------------------------------------------------------------

#endregion File Header
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.Benefits
{
    /// <summary>
    /// Query for getting a Benefits
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}}" />
    public class GetBenefitsQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Benefits identifier.
        /// </summary>
        public int BenefitId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetBenefitsQuery"/> class.
        /// </summary>
        /// <param name="SubscriptionPlanId">The benefit identifier.</param>
        public GetBenefitsQuery(int benefitId)
        {
            BenefitId = benefitId;
        }
    }
}
