#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | DeleteSubscriptionBenefitCommand --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;
using System;

namespace Happy.Weddings.Vendor.Service.Commands.v1.SubscriptionBenefits
{
    /// <summary>
    /// Command for deleting a Subscription Benefits
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class DeleteSubscriptionBenefitCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Subscription Plan identifier.
        /// </summary>
        public int SubscriptionBenefitId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteSubscriptionPlanCommand"/> class.
        /// </summary>
        /// <param name="storyId">The Subscription Plan identifier.</param>
        public DeleteSubscriptionBenefitCommand(int subscriptionBenefitRequestId)
        {
            SubscriptionBenefitId = subscriptionBenefitRequestId;
        }
    }
}

