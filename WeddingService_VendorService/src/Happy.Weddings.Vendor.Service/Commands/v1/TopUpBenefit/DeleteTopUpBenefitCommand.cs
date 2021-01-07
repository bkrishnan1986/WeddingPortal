#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | DeleteVendorSubscriptionCommand --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.TopUpBenefit
{
    /// <summary>
    /// Command for deleting a TopUpBenefit
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class DeleteTopUpBenefitCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the TopUpBenefit identifier.
        /// </summary>
        public int TopUpBenefitId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteTopUpCommand"/> class.
        /// </summary>
        /// <param name="storyId">The TopUpBenefit identifier.</param>
        public DeleteTopUpBenefitCommand(int topUpBenefitId)
        {
            TopUpBenefitId = topUpBenefitId;
        }
    }
}

