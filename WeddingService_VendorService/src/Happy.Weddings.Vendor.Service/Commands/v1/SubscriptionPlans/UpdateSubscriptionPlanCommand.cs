#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | UpdateSubscriptionPlanCommand --class
//----------------------------------------------------------------------------------------------

#endregion File Header


using Happy.Weddings.Vendor.Core.DTO.Requests.SubscriptionPlans;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.SubscriptionPlans
{
    /// <summary>
    /// Command for updating a story
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class UpdateSubscriptionPlanCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the story identifier.
        /// </summary>
        /// <value>
        /// The story identifier.
        /// </value>
        public int SubscriptionPlanId { get; set; }

        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public UpdateSubscriptionPlanRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSubscriptionPlanCommand" /> class.
        /// </summary>
        /// <param name="subscriptionPlanIdId">The story identifier.</param>
        /// <param name="Request">The request.</param>
        public UpdateSubscriptionPlanCommand(int subscriptionPlanIdId, UpdateSubscriptionPlanRequest request)
        {
            SubscriptionPlanId = subscriptionPlanIdId;
            Request = request;
        }
    }
}
