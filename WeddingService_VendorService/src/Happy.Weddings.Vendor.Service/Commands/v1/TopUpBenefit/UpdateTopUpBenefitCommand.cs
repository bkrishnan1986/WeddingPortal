#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | UpdateVendorSubscriptionCommand --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.TopUpBenefit;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.TopUpBenefit
{
    /// <summary>
    /// Command for updating a TopUpBenefit
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class UpdateTopUpBenefitCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the TopUpBenefit identifier.
        /// </summary>
        /// <value>
        /// The story identifier.
        /// </value>
        public int TopupBenefitId { get; set; }

        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public UpdateTopUpBenefitRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSubscriptionBenefitCommand" /> class.
        /// </summary>
        /// <param name="topupBenefitId">The TopUpBenefit identifier.</param>
        /// <param name="request">The request.</param>
        public UpdateTopUpBenefitCommand(int topupBenefitId, UpdateTopUpBenefitRequest request)
        {
            TopupBenefitId = topupBenefitId;
            Request = request;
        }
    }
}
