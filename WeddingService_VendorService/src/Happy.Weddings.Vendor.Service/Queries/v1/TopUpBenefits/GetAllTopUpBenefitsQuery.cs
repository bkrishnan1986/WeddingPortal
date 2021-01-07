
#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | GetAllTopUpBenefitsQuery --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.TopUpBenefit;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.TopUpBenefits
{
    /// <summary>
    /// Query for getting TopUpBenefit
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}}" />
    public class GetAllTopUpBenefitsQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the TopUpBenefit parameters.
        /// </summary>
        public TopUpBenefitParameter TopUpBenefitParameter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllTopUpQuery"/> class.
        /// </summary>
        /// <param name="topUpBenefitParameter">The TopUpBenefit parameters.</param>
        public GetAllTopUpBenefitsQuery(TopUpBenefitParameter topUpBenefitParameter)
        {
            TopUpBenefitParameter = topUpBenefitParameter;
        }
    }
}
